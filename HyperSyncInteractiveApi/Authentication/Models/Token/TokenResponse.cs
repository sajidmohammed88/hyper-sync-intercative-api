using HyperSyncInteractiveApi.Common.Models;

namespace HyperSyncInteractiveApi.Authentication.Models.Token
{
  public class TokenResponse : BaseResponse
  {
    public TokenData Data { get; set; }
  }
}
