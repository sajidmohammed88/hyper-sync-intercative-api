using HyperSyncInteractiveApi.Authentication.Models.Authorization;
using HyperSyncInteractiveApi.Authentication.Models.Consent;
using HyperSyncInteractiveApi.Authentication.Models.Login;
using HyperSyncInteractiveApi.Authentication.Models.MpinLogin;
using HyperSyncInteractiveApi.Authentication.Models.Token;
using System.Threading.Tasks;

namespace HyperSyncInteractiveApi.Authentication.Abstarctions
{
  public interface IHsAuthentication
  {
    /// <summary>
    /// Authorize the client in hs API.
    /// </summary>
    /// <param name="clientId">The client id.</param>
    /// <param name="loginVerifier">The login verifier.</param>
    /// <returns>The authorization response.</returns>
    Task<AuthorizationResponse> AuthorizeAsync(string clientId, string loginVerifier = null);

    /// <summary>
    /// Get the authorization code
    /// </summary>
    /// <param name="clientId">The client identifier.</param>
    /// <param name="consentVerifier"></param>
    /// <returns>The authorization code.</returns>
    Task<string> GetAuthorizationCodeAsync(string clientId, string consentVerifier);

    /// <summary>
    /// Login to the HS API.
    /// </summary>
    /// <param name="loginRequest">The login request informations.</param>
    /// <returns>The login response.</returns>
    Task<LoginResponse> LoginAsync(LoginRequest loginRequest);

    /// <summary>
    /// Mpin login to the HS API.
    /// </summary>
    /// <param name="mpinLoginRequest">Mpin login request.</param>
    /// <returns>Mpin login response.</returns>
    Task<MpinLoginResponse> MpinLoginAsync(MpinLoginRequest mpinLoginRequest);

    /// <summary>
    /// Consent API will trigger the OAuth consent dialog after the user signs in, asking the user to grant permissions to the app.
    /// </summary>
    /// <param name="consentRequest">The consent request.</param>
    /// <returns>The consent response.</returns>
    Task<ConsentResponse> ConsentAsync(ConsentRequest consentRequest);

    /// <summary>
    /// Generate token.
    /// </summary>
    /// <param name="clientId">The client identifier.</param>
    /// <param name="authorizationCode">The authorization code.</param>
    /// <param name="clientSecret">The client secret.</param>
    /// <returns>The token.</returns>
    Task<TokenData> GenerateTokenAsync(string clientId, string authorizationCode, string clientSecret);
  }
}
