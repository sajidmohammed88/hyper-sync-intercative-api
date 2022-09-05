using System.Text.Json.Serialization;

namespace HyperSyncInteractiveApi.Authentication.Models.Authorization
{
  public class AuthorizationRequest
  {
    public string State { get; set; }
    public string Scope { get; set; }

    [JsonPropertyName("client_id")]
    public string ClientId { get; set; }

    [JsonPropertyName("redirect_uri")]
    public string RedirectUri { get; set; }

    [JsonPropertyName("response_type")]
    public string ResponseType { get; set; }
  }
}
