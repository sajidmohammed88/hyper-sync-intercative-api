namespace HyperSyncInteractiveApi.Trading.Models.Order
{
  public class PlaceOrderBaseRequest : ModifyOrderBaseRequest
  {
    public string Es { get; set; }
    public string Pc { get; set; }
    public string Rt { get; set; }
    public string Tt { get; set; }
    public string Ur { get; set; }
  }
}
