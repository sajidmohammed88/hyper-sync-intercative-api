using HyperSyncInteractiveApi.Authentication.Models.Login;

namespace HyperSyncInteractiveApi.Authentication.Models.MpinLogin
{
  public class MpinLoginRequest : LoginRequest
  {
    public string Devicempinkey { get; set; }

    public string Mpin { get; set; }
  }
}
