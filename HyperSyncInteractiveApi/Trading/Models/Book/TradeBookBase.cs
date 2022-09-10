namespace HyperSyncInteractiveApi.Trading.Models.Book
{
  public class TradeBookBase : PositionBookBase
  {
    public int FldQty { get; set; }
    public string AvgPrc { get; set; }
    public string PrcTp { get; set; }
    public string RptTp { get; set; }
    public string OrdGenTp { get; set; }
    public string TrnsTp { get; set; }
    public string NOrdNo { get; set; }
    public string OrdSrc { get; set; }
  }
}
