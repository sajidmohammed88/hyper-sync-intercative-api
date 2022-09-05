using Flurl.Http;
using Flurl.Http.Configuration;
using HyperSyncInteractiveApi.Authentication.Abstarctions;
using HyperSyncInteractiveApi.Authentication.Exceptions;
using HyperSyncInteractiveApi.Authentication.Models.Authorization;
using HyperSyncInteractiveApi.Authentication.Models.Consent;
using HyperSyncInteractiveApi.Authentication.Models.Login;
using HyperSyncInteractiveApi.Authentication.Models.MpinLogin;
using HyperSyncInteractiveApi.Authentication.Models.Token;
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
    public async Task<AuthorizationResponse> AuthorizeAsync(string clientId, string loginVerifier = null)
    {
      try
      {
        AuthorizationResponse result = await BaseRequest
           .AppendPathSegment(Constants.Authentication.AuthorizePath)
           .WithHeader(Headers.AcceptHeaderKey, Headers.DefaultContentTypeHeaderValue)
           .WithHeader(Headers.ContentTypeHeaderKey, Headers.DefaultContentTypeHeaderValue)
           .AllowHttpStatus(HttpStatusCode.OK)
           .PostJsonAsync(new LoginVerifierAuthorizationRequest
           {
             ClientId = clientId,
             LoginVerifier = loginVerifier
           })
           .ReceiveJson<AuthorizationResponse>();

        if (result.Code != HttpStatusCode.OK)
        {
          ThrowException(result, nameof(AuthorizeAsync));
        }

        return result;
      }
      catch (FlurlHttpException ex)
      {
        ThrowException(new BaseResponse
        {
          Code = ex.StatusCode.HasValue ? (HttpStatusCode)ex.StatusCode : HttpStatusCode.InternalServerError,
          Status = "FAILURE",
          Message = ex.Message
        },
        nameof(AuthorizeAsync));

        throw;
      }
    }

    /// <inheritdoc />
    public async Task<string> GetAuthorizationCodeAsync(string clientId, string consentVerifier)
    {
      try
      {
        IFlurlResponse result = await BaseRequest
           .AppendPathSegment(Constants.Authentication.AuthorizePath)
           .WithHeader(Headers.AcceptHeaderKey, Headers.DefaultContentTypeHeaderValue)
           .WithHeader(Headers.ContentTypeHeaderKey, Headers.DefaultContentTypeHeaderValue)
           .PostJsonAsync(new ConsentVerifierAuthorizationRequest
           {
             ClientId = clientId,
             ConsentVerifier = consentVerifier
           });

        if (result.StatusCode == (int)HttpStatusCode.SeeOther && result.Headers.TryGetFirst("Location", out string location))
        {
          return Helpers.GetQueryValueByName(new Uri(location).Query, "code");
        }

        throw new AuthenticationException($"The status code should be {HttpStatusCode.SeeOther} for method : {nameof(GetAuthorizationCodeAsync)}");
      }
      catch (FlurlHttpException ex)
      {
        ThrowException(new BaseResponse
        {
          Code = ex.StatusCode.HasValue ? (HttpStatusCode)ex.StatusCode : HttpStatusCode.InternalServerError,
          Status = "FAILURE",
          Message = ex.Message
        },
        nameof(GetAuthorizationCodeAsync));

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
          ThrowException(response, nameof(LoginAsync));
        }

        return response;
      }
      catch (FlurlHttpException ex)
      {
        ThrowException(new BaseResponse
        {
          Code = ex.StatusCode.HasValue ? (HttpStatusCode)ex.StatusCode : HttpStatusCode.InternalServerError,
          Status = "FAILURE",
          Message = ex.Message
        },
        nameof(LoginAsync));

        throw;
      }
    }

    /// <inheritdoc />
    public async Task<MpinLoginResponse> MpinLoginAsync(MpinLoginRequest mpinLoginRequest)
    {
      mpinLoginRequest.Mpin = Helpers.ComputeHash(mpinLoginRequest.Mpin);

      try
      {
        MpinLoginResponse response = await BaseRequest
          .AppendPathSegment(Constants.Authentication.MpinLoginPath)
          .WithHeader(Headers.AcceptHeaderKey, Headers.DefaultContentTypeHeaderValue)
          .WithHeader(Headers.ContentTypeHeaderKey, Headers.DefaultContentTypeHeaderValue)
          .AllowHttpStatus(HttpStatusCode.OK)
          .PostJsonAsync(mpinLoginRequest)
          .ReceiveJson<MpinLoginResponse>();

        if (response.Code != HttpStatusCode.OK)
        {
          ThrowException(response, nameof(MpinLoginAsync));
        }

        return response;
      }
      catch (FlurlHttpException ex)
      {
        ThrowException(new BaseResponse
        {
          Code = ex.StatusCode.HasValue ? (HttpStatusCode)ex.StatusCode : HttpStatusCode.InternalServerError,
          Status = "FAILURE",
          Message = ex.Message
        },
        nameof(MpinLoginAsync));

        throw;
      }
    }

    /// <inheritdoc />
    public async Task<ConsentResponse> ConsentAsync(ConsentRequest consentRequest)
    {
      try
      {
        ConsentResponse response = await BaseRequest
          .AppendPathSegment(Constants.Authentication.ConsentPath)
          .WithHeader(Headers.AcceptHeaderKey, Headers.DefaultContentTypeHeaderValue)
          .WithHeader(Headers.ContentTypeHeaderKey, Headers.DefaultContentTypeHeaderValue)
          .AllowHttpStatus(HttpStatusCode.OK)
          .PostJsonAsync(consentRequest)
          .ReceiveJson<ConsentResponse>();

        if (response.Code != HttpStatusCode.OK)
        {
          ThrowException(response, nameof(ConsentAsync));
        }

        return response;
      }
      catch (FlurlHttpException ex)
      {
        ThrowException(new BaseResponse
        {
          Code = ex.StatusCode.HasValue ? (HttpStatusCode)ex.StatusCode : HttpStatusCode.InternalServerError,
          Status = "FAILURE",
          Message = ex.Message
        },
        nameof(ConsentAsync));

        throw;
      }
    }

    /// <inheritdoc />
    public async Task<TokenData> GenerateTokenAsync(string clientId, string authorizationCode, string clientSecret)
    {
      try
      {
        TokenResponse response = await BaseRequest
          .AppendPathSegment(Constants.Authentication.TokenPath)
          .PostUrlEncodedAsync(new
          {
            grant_type = Constants.Authentication.GrantType,
            code = authorizationCode,
            client_id = clientId,
            client_secret = clientSecret,
            redirect_uri = Constants.Authentication.RedirectUri,
          })
          .ReceiveJson<TokenResponse>();

        if (response.Code != HttpStatusCode.OK)
        {
          ThrowException(response, nameof(GenerateTokenAsync));
        }

        return response.Data;
      }
      catch (FlurlHttpException ex)
      {
        ThrowException(new BaseResponse
        {
          Code = ex.StatusCode.HasValue ? (HttpStatusCode)ex.StatusCode : HttpStatusCode.InternalServerError,
          Status = "FAILURE",
          Message = ex.Message
        },
        nameof(GenerateTokenAsync));

        throw;
      }
    }

    private static AuthenticationException ThrowException(BaseResponse response, string methodeName) =>
    throw new AuthenticationException($"Error during calling the methode : {nameof(AuthorizeAsync)}, with Code : {response.Code} Status : {response.Status} Message : {response.Message}");
  }
}
