using Flurl.Http.Configuration;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HyperSyncInteractiveApi.Common.Utils
{
  internal class FlurlJsonSerializer : ISerializer
  {
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    /// <summary>
    /// Initializes a new instance of <see cref="FlurlJsonSerializer"/>
    /// </summary>
    public FlurlJsonSerializer()
    {
      _jsonSerializerOptions = new JsonSerializerOptions
      {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
      };
    }

    /// <inheritdoc />
    public T Deserialize<T>(string s)
    {
      return JsonSerializer.Deserialize<T>(s, _jsonSerializerOptions);
    }

    /// <inheritdoc />
    public T Deserialize<T>(Stream stream)
    {
      if (stream == null || stream.Length == 0)
      {
        return default;
      }

      return JsonSerializer.DeserializeAsync<T>(stream, _jsonSerializerOptions).Result;
    }

    /// <inheritdoc />
    public string Serialize(object obj)
    {
      return JsonSerializer.Serialize(obj, _jsonSerializerOptions);
    }
  }
}
