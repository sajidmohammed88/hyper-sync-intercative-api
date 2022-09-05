using System;
using System.Text.Json.Serialization;

namespace HyperSyncInteractiveApi.Authentication.Models.Token
{
  public class TokenData
  {
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }
    
    [JsonPropertyName("expires_in")]
    public DateTime ExpiresIn { get; set; }

    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }
  }
}
