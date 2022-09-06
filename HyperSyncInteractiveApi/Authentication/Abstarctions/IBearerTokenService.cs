using System.Threading.Tasks;

namespace HyperSyncInteractiveApi.Authentication.Abstarctions
{
  public interface IBearerTokenService
  {
    /// <summary>
    /// Get the bearer token.
    /// </summary>
    /// <param name="clientId">The client identifier.</param>
    /// <param name="clientSecret">The client secret.</param>
    /// <param name="uid">The user identifier.</param>
    /// <param name="pwd">The password.</param>
    /// <param name="mpin">The mpin.</param>
    /// <returns>The bearer token.</returns>
    Task<string> GetBearerTokenAsync(string clientId, string clientSecret, string uid, string pwd, string mpin);
  }
}
