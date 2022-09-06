using HyperSyncInteractiveApi.Authentication.Abstarctions;
using HyperSyncInteractiveApi.Authentication.Models.Authorization;
using HyperSyncInteractiveApi.Authentication.Models.Consent;
using HyperSyncInteractiveApi.Authentication.Models.Login;
using HyperSyncInteractiveApi.Authentication.Models.MpinLogin;
using HyperSyncInteractiveApi.Authentication.Models.Token;
using System;
using System.Threading.Tasks;

namespace HyperSyncInteractiveApi.Authentication
{
  public class BearerTokenService : IBearerTokenService
  {
    private readonly IHsAuthentication _hsAuthentication;
    public BearerTokenService()
    {
      _hsAuthentication = new HsAuthentication();
    }

    /// <inheritdoc />
    public async Task<string> GetBearerTokenAsync(string clientId, string clientSecret, string uid, string pwd, string mpin)
    {
      //Authorize
      AuthorizationResponse authorizationResponse = await _hsAuthentication.AuthorizeAsync(clientId);

      //Login
      LoginRequest loginRequest = new LoginRequest
      {
        BrokerId = authorizationResponse.Data.BrokerId,
        LoginChallenge = authorizationResponse.Data.LoginChallenge,
        Uid = uid,
        Pwd = pwd,
        DeviceInfo = $"{uid}-{authorizationResponse.Data.BrokerId}_{DateTimeOffset.Now.ToUnixTimeMilliseconds()}",
        Source = Constants.Authentication.Source,
        DeviceName = Constants.Authentication.DeviceName
      };
      LoginResponse loginResponse = await _hsAuthentication.LoginAsync(loginRequest);

      //Mpin login
      MpinLoginResponse mpinLoginResponse = await _hsAuthentication.MpinLoginAsync(new MpinLoginRequest(loginRequest, loginResponse.Data.Devicempinkey, mpin));

      //Authorize login verifier.
      AuthorizationResponse secondAuthorizationResponse = await _hsAuthentication.AuthorizeAsync(clientId, loginVerifier: mpinLoginResponse.Data.LoginVerifier);

      //consent
      ConsentResponse consentResponse = await _hsAuthentication.ConsentAsync(new ConsentRequest
      {
        ClientId = clientId,
        ConsentChallenge = secondAuthorizationResponse.Data.ConsentChallenge,
        Consent = "true"
      });

      //Authorization code.
      string authorizationCode = await _hsAuthentication.GetAuthorizationCodeAsync(clientId, consentResponse.Data.ConsentVerifier);

      //Generate token.
      TokenData token = await _hsAuthentication.GenerateTokenAsync(clientId, authorizationCode, clientSecret);

      return token?.AccessToken;
    }
  }
}
