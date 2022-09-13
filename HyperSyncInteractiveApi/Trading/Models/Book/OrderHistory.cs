namespace HyperSyncInteractiveApi.Trading.Models.Book
{
  public class OrderHistory : BaseOrderBook
  {
    public int BrdLtQty { get; set; }
    public string CstFrm { get; set; }
    public string NReqId { get; set; }
    public string DclQty { get; set; }
    public string FlDtTm { get; set; }
    public string Exch { get; set; }
    public string LegOrdInd { get; set; }
    public string ExchOrdId { get; set; }
    public string OrdUsrMsg { get; set; }
    public string OrdDur { get; set; }
    public string ExchTmstp { get; set; }
    public string ScripName { get; set; }
  }
}
