using HyperSyncInteractiveApi.Authentication;
using HyperSyncInteractiveApi.Trading;
using HyperSyncInteractiveApi.Trading.Models.User;
using System.Linq;
using System.Threading.Tasks;

namespace HyperSyncIntercativeApiEntry
{
  internal class Program
  {
    static async Task Main(string[] args)
    {
      var keys = args.ToDictionary(k => k.Substring(0, k.IndexOf(':')), v => v.Substring(v.IndexOf(':') + 1));

      // token generator
      BearerTokenService bearerTokenService = new BearerTokenService();
      string token = await bearerTokenService.GetBearerTokenAsync(keys["client_id"], keys["client_secret"], keys["uid"], keys["pwd"], keys["mpin"]);

      // trade api

      HsInteractiveApi hsInteractiveApi = new HsInteractiveApi(token);

      // user
      AccountDetails accountDetails = await hsInteractiveApi.GetUserDetailsAsync();
      ResetUserResponse resetUserResponse = await hsInteractiveApi.ResetUserAsync();
      UserDetails userDetails = await hsInteractiveApi.GetDefaultLoginAsync();

      // books
    }
  }
}
