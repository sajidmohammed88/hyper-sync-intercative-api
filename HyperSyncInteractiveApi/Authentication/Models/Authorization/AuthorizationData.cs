using HyperSyncInteractiveApi.Common;

namespace HyperSyncInteractiveApi.Authentication.Models.Authorization
{
  public class AuthorizationData : BaseData
  {
    public string LoginChallenge { get; set; }
    public string BrokerId { get; set; }
    public string ConsentChallenge { get; set; }
    public bool Consent { get; set; }
  }
}