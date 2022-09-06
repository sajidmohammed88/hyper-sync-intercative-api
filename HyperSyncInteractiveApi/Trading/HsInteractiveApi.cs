using Flurl.Http;
using Flurl.Http.Configuration;
using HyperSyncInteractiveApi.Common.Utils;
using HyperSyncInteractiveApi.Trading.Abstractions;
using HyperSyncInteractiveApi.Trading.Models.User;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HyperSyncInteractiveApi.Trading
{
  public class HsInteractiveApi : IHsInteractiveApi
  {
    private readonly ISerializer _jsonSerializer;
    private readonly string _token;

    public HsInteractiveApi(string token)
    {
      _jsonSerializer = new FlurlJsonSerializer();
      _token = token;
    }

    private Action<FlurlHttpSettings> ConfigureFlurlRequest => s =>
    {
      s.JsonSerializer = _jsonSerializer;
    };

    private IFlurlRequest BaseRequest => Constants.Trading.BaseUrl.ConfigureRequest(ConfigureFlurlRequest);

    #region USER

    public async Task<UserDetails> GetDefaultLoginAsync()
    {
      var x = await BaseRequest
           .AppendPathSegment(Constants.Trading.User.DefaultLoginPath)
           .WithHeader(Headers.AcceptHeaderKey, Headers.DefaultContentTypeHeaderValue)
           .WithHeader(Headers.TokenHeaderKey, _token)
           .AllowHttpStatus(HttpStatusCode.OK)
           .PostAsync().ReceiveString();
      return await BaseRequest
           .AppendPathSegment(Constants.Trading.User.DefaultLoginPath)
           .WithHeader(Headers.AcceptHeaderKey, Headers.DefaultContentTypeHeaderValue)
           .WithHeader(Headers.TokenHeaderKey, _token)
           .AllowHttpStatus(HttpStatusCode.OK)
           .PostAsync()
           .ReceiveJson<UserDetails>();
    }

    public async Task<AccountDetails> GetUserDetailsAsync()
    {
      return await BaseRequest
           .AppendPathSegment(Constants.Trading.User.UserDetailsPath)
           .WithHeader(Headers.AcceptHeaderKey, Headers.DefaultContentTypeHeaderValue)
           .WithHeader(Headers.TokenHeaderKey, _token)
           .AllowHttpStatus(HttpStatusCode.OK)
           .PostAsync()
           .ReceiveJson<AccountDetails>();
    }

    public async Task<ResetUserResponse> ResetUserAsync()
    {
      return await BaseRequest
           .AppendPathSegment(Constants.Trading.User.ResetUserPath)
           .WithHeader(Headers.AcceptHeaderKey, Headers.DefaultContentTypeHeaderValue)
           .WithHeader(Headers.TokenHeaderKey, _token)
           .AllowHttpStatus(HttpStatusCode.OK)
           .PostAsync()
           .ReceiveJson<ResetUserResponse>();
    }

    #endregion
  }
}
