using HyperSyncInteractiveApi.Common.Models;

namespace HyperSyncInteractiveApi.Authentication.Models.Login
{
  public class LoginResponse : BaseResponse
  {
    public LoginData Data { get; set; }
  }
}
