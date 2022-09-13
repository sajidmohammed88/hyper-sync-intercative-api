using System.Text.Json.Serialization;

namespace HyperSyncInteractiveApi.Trading.Models.Book
{
  public class BaseOrderBook : TradeBookBase
  {
    public string MfdBy { get; set; }
    public string VendorCode { get; set; }
    public string TrgPrc { get; set; }
    public string SymOrdId { get; set; }
    public string Prc { get; set; }
    public string Classification { get; set; }
    public string OrdSt { get; set; }
    public int Qty { get; set; }
    public int UnFldSz { get; set; }
    public string RejRsn { get; set; }
    public string MktPro { get; set; }

    [JsonPropertyName("GuiOrdId")]
    public string GuiOrdId { get; set; }
  }
}
