using HyperSyncInteractiveApi.Authentication;
using HyperSyncInteractiveApi.Authentication.Models.Authorization;
using HyperSyncInteractiveApi.Authentication.Models.Consent;
using HyperSyncInteractiveApi.Authentication.Models.Login;
using HyperSyncInteractiveApi.Authentication.Models.MpinLogin;
using HyperSyncInteractiveApi.Authentication.Models.Token;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HyperSyncIntercativeApiEntry
{
  internal class Program
  {
    static async Task Main(string[] args)
    {
      var keys = args.ToDictionary(k => k.Substring(0, k.IndexOf(':')), v => v.Substring(v.IndexOf(':') + 1));

      HsAuthentication hsAuthentication = new HsAuthentication();

      //Authorize
      AuthorizationResponse authorizationResponse = await hsAuthentication.AuthorizeAsync(keys["client_id"]);

      //Login
      LoginResponse loginResponse = await hsAuthentication.LoginAsync(new LoginRequest
      {
        BrokerId = authorizationResponse.Data.BrokerId,
        LoginChallenge = authorizationResponse.Data.LoginChallenge,
        Uid = keys["uid"],
        Pwd = keys["pwd"],
        DeviceInfo = $"{keys["uid"]}-{authorizationResponse.Data.BrokerId}_{DateTimeOffset.Now.ToUnixTimeMilliseconds()}",
        Source = "Web",
        DeviceName = "Chrome"
      });

      //Mpin login
      MpinLoginResponse mpinLoginResponse = await hsAuthentication.MpinLoginAsync(new MpinLoginRequest
      {
        BrokerId = authorizationResponse.Data.BrokerId,
        LoginChallenge = authorizationResponse.Data.LoginChallenge,
        Uid = keys["uid"],
        DeviceInfo = $"{keys["uid"]}-{authorizationResponse.Data.BrokerId}_{DateTimeOffset.Now.ToUnixTimeMilliseconds()}",
        Source = "Web",
        DeviceName = "Chrome",
        Devicempinkey = loginResponse.Data.Devicempinkey,
        Mpin = keys["mpin"]
      });
      
      //Authorize login verifier.
      AuthorizationResponse secondAuthorizationResponse = await hsAuthentication.AuthorizeAsync(keys["client_id"], loginVerifier: mpinLoginResponse.Data.LoginVerifier);
     
      //consent
      ConsentResponse consentResponse = await hsAuthentication.ConsentAsync(new ConsentRequest
      {
        ClientId = keys["client_id"],
        ConsentChallenge = secondAuthorizationResponse.Data.ConsentChallenge,
        Consent = "true"
      });
      
      //Authorization code.
      string authorizationCode = await hsAuthentication.GetAuthorizationCodeAsync(keys["client_id"], consentResponse.Data.ConsentVerifier);

      //Generate token.
      TokenData token = await hsAuthentication.GenerateTokenAsync(keys["client_id"], authorizationCode, keys["client_secret"]);
    }
  }
}
