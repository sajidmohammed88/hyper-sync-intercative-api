namespace HyperSyncInteractiveApi.Trading.Models.Order
{
  public class PlaceOrderRequest : PlaceOrderBaseRequest
  {
    public string Ot { get; set; }
    public string Tk { get; set; }
    public string Ig { get; set; }
  }
}
