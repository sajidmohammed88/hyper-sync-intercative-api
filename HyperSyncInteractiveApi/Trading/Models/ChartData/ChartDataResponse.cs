using HyperSyncInteractiveApi.Common.Models;

namespace HyperSyncInteractiveApi.Trading.Models.ChartData
{
  public class ChartDataResponse : ResponseState
  {
    public string ExSeg { get; set; }
    public string TrdSym { get; set; }
    public ChartDatas Data { get; set; }
  }
}
