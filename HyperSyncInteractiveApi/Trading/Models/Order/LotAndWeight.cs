using System.Text.Json.Serialization;

namespace HyperSyncInteractiveApi.Trading.Models.Order
{
  public class LotAndWeight
  {
    [JsonPropertyName("NFO")]
    public string NFO { get; set; }

    [JsonPropertyName("BFO")]
    public string BFO { get; set; }
  }
}