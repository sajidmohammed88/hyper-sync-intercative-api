namespace HyperSyncInteractiveApi.Trading.Models.Order
{
  public class VrPlaceOrderRequest : PlaceOrderBaseRequest
  {
    public string Mp { get; set; }
    public string Pf { get; set; }
    public string Pt { get; set; }
  }
}
