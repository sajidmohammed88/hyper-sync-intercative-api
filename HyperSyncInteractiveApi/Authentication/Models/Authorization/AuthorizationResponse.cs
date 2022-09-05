using HyperSyncInteractiveApi.Common;

namespace HyperSyncInteractiveApi.Authentication.Models.Authorization
{
  public class AuthorizationResponse : BaseResponse
  {
    public AuthorizationData Data { get; set; }
  }
}