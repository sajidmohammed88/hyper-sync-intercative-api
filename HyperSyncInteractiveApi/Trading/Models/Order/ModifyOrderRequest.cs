namespace HyperSyncInteractiveApi.Trading.Models.Order
{
  public class ModifyOrderRequest : ModifyOrderBaseRequest
  {
    public string On { get; set; }
    public string Ot { get; set; }
    public string Tk { get; set; }
    public string Vd { get; set; }
  }
}
