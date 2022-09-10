using HyperSyncInteractiveApi.Common.Models;

namespace HyperSyncInteractiveApi.Trading.Models.User
{
  public class BaseUser : ResponseState
  {
    public string DpNo { get; set; }
    public string DpNm { get; set; }
    public string ActId { get; set; }
    public string Dp { get; set; }
    public string ActName { get; set; }
    public string DpNo2 { get; set; }
    public string DpNo3 { get; set; }
    public string Email { get; set; }
    public string DpId { get; set; }
    public string BrkName { get; set; }
  }
}
