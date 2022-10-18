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
      try
      {
        string result = await BaseRequest
               .AppendPathSegment(path)
               .WithHeader(Headers.TokenHeaderKey, _token)
               .PostAsync()
               .ReceiveString();

        // log the result as string here

        return _jsonSerializer.Deserialize<T>(result);
      }
      catch (FlurlHttpException ex)
      {
        string message = $"Call failed with message : {ex.Message} and response : {await ex.GetResponseStringAsync()}";
        //Log the message here

        throw;
      }
    }

    protected async Task<TResponse> PostAsync<TRequest, TResponse>(string path, TRequest request)
    {
      try
      {
        string result = await BaseRequest
               .AppendPathSegment(path)
               .WithHeader(Headers.ContentTypeHeaderKey, Headers.UrlEncodedContentTypeHeaderValue)
               .WithHeader(Headers.TokenHeaderKey, _token)
               .PostUrlEncodedAsync(new
               {
                 jData = _jsonSerializer.Serialize(request)
               })
               .ReceiveString();

        // log result as string here

        return _jsonSerializer.Deserialize<TResponse>(result);
      }
      catch (FlurlHttpException ex)
      {
        string message = $"Call failed with message : {ex.Message} and response : {await ex.GetResponseStringAsync()}";
        //Log the message here

        throw;
      }
    }
  }
}
