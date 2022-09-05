using HyperSyncInteractiveApi.Authentication.Models.Authorization;
using HyperSyncInteractiveApi.Authentication.Models.Login;
using System.Threading.Tasks;

namespace HyperSyncInteractiveApi.Authentication.Abstarctions
{
  public interface IHsAuthentication
  {
    /// <summary>
    /// Authorize the client in hs API.
    /// </summary>
    /// <param name="clientId">The client id.</param>
    /// <returns>The authorization response.</returns>
    Task<AuthorizationResponse> AuthorizeAsync(string clientId);

    /// <summary>
    /// Login to the HS API.
    /// </summary>
    /// <param name="loginRequest">The login request informations.</param>
    /// <returns>The login response.</returns>
    Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
  }
}
