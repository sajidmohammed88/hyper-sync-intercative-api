using Flurl.Http;
using Flurl.Http.Configuration;
using HyperSyncInteractiveApi.Common.Utils;
using System;
using System.Threading.Tasks;

namespace HyperSyncInteractiveApi.Trading.Abstractions
{
  public abstract class HsInteractiveApiBase
  {
    private readonly string _token;
    private readonly string _baseUrl;
    private readonly ISerializer _jsonSerializer;

    protected HsInteractiveApiBase(string token, string baseUrl)
    {
      _token = token;
      _baseUrl = baseUrl;
      _jsonSerializer = new FlurlJsonSerializer();
    }

    private Action<FlurlHttpSettings> ConfigureFlurlRequest => s =>
    {
      s.JsonSerializer = _jsonSerializer;
    };

    private IFlurlRequest BaseRequest => _baseUrl.ConfigureRequest(ConfigureFlurlRequest);

    protected async Task<T> PostAsync<T>(string path)
    {
      return await BaseRequest
           .AppendPathSegment(path)
           .WithHeader(Headers.TokenHeaderKey, _token)
           .PostAsync()
           .ReceiveJson<T>();
    }

    protected async Task<TResponse> PostAsync<TRequest, TResponse>(string path, TRequest request)
    {
      return await BaseRequest
           .AppendPathSegment(path)
           .WithHeader(Headers.TokenHeaderKey, _token)
           .PostJsonAsync(request)
           .ReceiveJson<TResponse>();
    }
  }
}
