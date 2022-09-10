namespace HyperSyncInteractiveApi.Trading.Models.Book
{
  public class PositionBook : PositionBookBase
  {
    public string BuyAmt { get; set; }
    public string CfSellAmt { get; set; }
    public string SqrFlg { get; set; }
    public string ActId { get; set; }
    public string CfBuyQty { get; set; }
    public string CfSellQty { get; set; }
    public string FlBuyQty { get; set; }
    public string FlSellQty { get; set; }
    public string SellAmt { get; set; }
    public string PosFlg { get; set; }
    public string CfBuyAmt { get; set; }
    public string Type { get; set; }
    public string Exp { get; set; }
    public string HsUpTm { get; set; }
  }
}
