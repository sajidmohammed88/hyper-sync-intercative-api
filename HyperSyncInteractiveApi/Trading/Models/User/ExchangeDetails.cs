using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HyperSyncInteractiveApi.Trading.Models.User
{
  public class ExchangeDetails
  {
    [JsonPropertyName("DERIVATIVE")]
    public List<ExchangeDetail> Derivative { get; set; }
    
    [JsonPropertyName("CURRENCY")]
    public List<ExchangeDetail> Currency { get; set; }

    [JsonPropertyName("EQUITY")]
    public List<ExchangeDetail> Equity { get; set; }

    [JsonPropertyName("COMMODITY")]
    public List<ExchangeDetail> Commodity { get; set; }
  }
}
