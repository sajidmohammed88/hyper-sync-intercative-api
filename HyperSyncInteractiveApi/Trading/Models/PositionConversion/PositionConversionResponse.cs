using System.Text.Json.Serialization;

namespace HyperSyncInteractiveApi.Trading.Models.PositionConversion
{
  public class PositionConversionResponse
  {
    public string Stat { get; set; }
    public string Posflag { get; set; }

    [JsonPropertyName("Result")]
    public string Result { get; set; }
  }
}
