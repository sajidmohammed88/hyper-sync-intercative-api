using System.Text.Json.Serialization;

namespace HyperSyncInteractiveApi.Authentication.Models.Authorization
{
  public class AuthorizationRequestBase
  {
    public string State { get; set; } = Constants.Authentication.State;

    public string Scope { get; set; } = Constants.Authentication.Scope;

    [JsonPropertyName("client_id")]
    public string ClientId { get; set; }

    [JsonPropertyName("redirect_uri")]
    public string RedirectUri { get; set; } = Constants.Authentication.RedirectUri;

    [JsonPropertyName("response_type")]
    public string ResponseType { get; set; } = Constants.Authentication.ResponseType;
  }
}
