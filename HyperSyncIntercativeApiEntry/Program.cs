using HyperSyncInteractiveApi.Authentication;
using HyperSyncInteractiveApi.Authentication.Models.Authorization;
using HyperSyncInteractiveApi.Authentication.Models.Login;
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
      AuthorizationResponse authorizationResponse = await hsAuthentication.AuthorizeAsync(keys["client_id"]);
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
    }
  }
}
