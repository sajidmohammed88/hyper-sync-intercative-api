using Flurl.Http;
using Flurl.Http.Configuration;
using HyperSyncInteractiveApi.Authentication.Abstarctions;
using HyperSyncInteractiveApi.Authentication.Exceptions;
using HyperSyncInteractiveApi.Authentication.Models.Authorization;
using HyperSyncInteractiveApi.Authentication.Models.Login;
using HyperSyncInteractiveApi.Common;
using HyperSyncInteractiveApi.Common.Utils;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HyperSyncInteractiveApi.Authentication
{
  public class HsAuthentication : IHsAuthentication
  {
    private readonly ISerializer _jsonSerializer;

    public HsAuthentication()
    {
      _jsonSerializer = new FlurlJsonSerializer();
    }

    private Action<FlurlHttpSettings> ConfigureFlurlRequest => s =>
    {
      s.JsonSerializer = _jsonSerializer;
    };

    private IFlurlRequest BaseRequest => Constants.Authentication.BaseUrl.ConfigureRequest(ConfigureFlurlRequest);

    /// <inheritdoc />
    public async Task<AuthorizationResponse> AuthorizeAsync(string clientId)
    {
      try
      {
        AuthorizationResponse result = await BaseRequest
           .AppendPathSegment(Constants.Authentication.AuthorizePath)
           .WithHeader(Headers.AcceptHeaderKey, Headers.DefaultContentTypeHeaderValue)
           .WithHeader(Headers.ContentTypeHeaderKey, Headers.DefaultContentTypeHeaderValue)
           .AllowHttpStatus(HttpStatusCode.OK)
           .PostJsonAsync(new AuthorizationRequest
           {
             State = Constants.Authentication.State,
             Scope = Constants.Authentication.Scope,
             ClientId = clientId,
             RedirectUri = Constants.Authentication.RedirectUri,
             ResponseType = Constants.Authentication.ResponseType
           })
           .ReceiveJson<AuthorizationResponse>();

        if (result.Code != HttpStatusCode.OK)
        {
          ThrowException(result, result.Data.Message, nameof(AuthorizeAsync));
        }

        return result;
      }
      catch (FlurlHttpException ex)
      {
        ThrowException(new BaseResponse
        {
          Code = ex.StatusCode.HasValue ? (HttpStatusCode)ex.StatusCode : HttpStatusCode.InternalServerError,
          Status = "FAILURE"
        },
        ex.Message, 
        nameof(AuthorizeAsync));

        throw;
      }
    }

    /// <inheritdoc />
    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
    {
      try
      {
        loginRequest.Pwd = Helpers.ComputeHash(loginRequest.Pwd);

        LoginResponse response = await BaseRequest
          .AppendPathSegment(Constants.Authentication.LoginPath)
          .WithHeader(Headers.AcceptHeaderKey, Headers.DefaultContentTypeHeaderValue)
          .WithHeader(Headers.ContentTypeHeaderKey, Headers.DefaultContentTypeHeaderValue)
          .AllowHttpStatus(HttpStatusCode.OK)
          .PostJsonAsync(loginRequest)
          .ReceiveJson<LoginResponse>();

        if (response.Code != HttpStatusCode.OK)
        {
          ThrowException(response, response.Data.Message, nameof(LoginAsync));
        }

        return response;
      }
      catch (FlurlHttpException ex)
      {
        ThrowException(new BaseResponse
        {
          Code = ex.StatusCode.HasValue ? (HttpStatusCode)ex.StatusCode : HttpStatusCode.InternalServerError,
          Status = "FAILURE"
        },
        ex.Message, 
        nameof(LoginAsync));

        throw;
      }
    }

    private static AuthenticationException ThrowException(BaseResponse response, string message, string methodeName) =>
        throw new AuthenticationException($"Error during calling the methode : {nameof(AuthorizeAsync)}, with Code : {response.Code} Status : {response.Status} Message : {message}");
  }
}
