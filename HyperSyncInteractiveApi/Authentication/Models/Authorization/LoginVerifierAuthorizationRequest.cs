namespace HyperSyncInteractiveApi.Authentication.Models.Authorization
{
  public class LoginVerifierAuthorizationRequest : AuthorizationRequestBase
  {
    public string LoginVerifier { get; set; }
  }
}
