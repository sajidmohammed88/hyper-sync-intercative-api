namespace HyperSyncInteractiveApi.Trading.Models.Book
{
  public class TradeBook : TradeBookBase
  {
    public string BrdLtQty { get; set; }
    public string ExOrdId { get; set; }
    public string BrkClnt { get; set; }
    public string CstFrm { get; set; }
    public string ActId { get; set; }
    public string Rmk { get; set; }
    public string FlDt { get; set; }
    public string AlgId { get; set; }
    public string ExTm { get; set; }
    public string NReqId { get; set; }
    public int FlLeg { get; set; }
    public string UsrId { get; set; }
    public string FlId { get; set; }
    public string FlTm { get; set; }
    public string AlgCat { get; set; }
    public string OrdDur { get; set; }
    public int BoeSec { get; set; }
    public string Exp { get; set; }
    public int MinQty { get; set; }
    public string HsUpTm { get; set; }
  }
}
