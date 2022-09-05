using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace HyperSyncInteractiveApi.Authentication.Models.Consent
{
  public class ConsentRequest
  {
    [JsonPropertyName("client_id")]
    public string ClientId { get; set; }
    public string ConsentChallenge { get; set; }
    public string Consent { get; set; }
  }
}
