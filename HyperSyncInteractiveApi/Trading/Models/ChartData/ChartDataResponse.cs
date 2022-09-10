namespace HyperSyncInteractiveApi.Trading.Models.ChartData
{
  public class ChartDataResponse
  {
    public string Stat { get; set; }
    public string ExSeg { get; set; }
    public string TrdSym { get; set; }
    public ChartDatas Data { get; set; }
  }
}
