using Flurl.Http;
using Flurl.Http.Configuration;
using HyperSyncInteractiveApi.Authentication.Abstarctions;
using HyperSyncInteractiveApi.Authentication.Exceptions;
using HyperSyncInteractiveApi.Authentication.Models.Authorization;
using HyperSyncInteractiveApi.Authentication.Models.Consent;
using HyperSyncInteractiveApi.Authentication.Models.Login;
using HyperSyncInteractiveApi.Authentication.Models.MpinLogin;
using HyperSyncInteractiveApi.Authentication.Models.Token;
using HyperSyncInteractiveApi.Common.Models;
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
    public Task<AuthorizationResponse> AuthorizeAsync(string clientId, string loginVerifier = null)
    {
      try
      {
        return PostAsync<LoginVerifierAuthorizationRequest, AuthorizationResponse>(Constants.Authentication.AuthorizePath, nameof(AuthorizeAsync), new LoginVerifierAuthorizationRequest
        {
          ClientId = clientId,
          LoginVerifier = loginVerifier
        });
      }
      catch (FlurlHttpException ex)
      {
        ThrowException(GenerateBaseRequest(ex), nameof(AuthorizeAsync));
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
        ThrowException(GenerateBaseRequest(ex), nameof(GetAuthorizationCodeAsync));
        throw;
      }
    }

    /// <inheritdoc />
    public Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
    {
      try
      {
        loginRequest.Pwd = Helpers.ComputeHash(loginRequest.Pwd);

        return PostAsync<LoginRequest, LoginResponse>(Constants.Authentication.LoginPath, nameof(LoginAsync), loginRequest);
      }
      catch (FlurlHttpException ex)
      {
        ThrowException(GenerateBaseRequest(ex), nameof(LoginAsync));
        throw;
      }
    }

    /// <inheritdoc />
    public Task<MpinLoginResponse> MpinLoginAsync(MpinLoginRequest mpinLoginRequest)
    {
      mpinLoginRequest.Mpin = Helpers.ComputeHash(mpinLoginRequest.Mpin);

      try
      {
        return PostAsync<MpinLoginRequest, MpinLoginResponse>(Constants.Authentication.MpinLoginPath, nameof(MpinLoginAsync), mpinLoginRequest);
      }
      catch (FlurlHttpException ex)
      {
        ThrowException(GenerateBaseRequest(ex), nameof(MpinLoginAsync));
        throw;
      }
    }

    /// <inheritdoc />
    public Task<ConsentResponse> ConsentAsync(ConsentRequest consentRequest)
    {
      try
      {
        return PostAsync<ConsentRequest, ConsentResponse>(Constants.Authentication.ConsentPath, nameof(ConsentAsync), consentRequest);
      }
      catch (FlurlHttpException ex)
      {
        ThrowException(GenerateBaseRequest(ex), nameof(ConsentAsync));
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
        ThrowException(GenerateBaseRequest(ex), nameof(GenerateTokenAsync));
        throw;
      }
    }

    private async Task<TResponse> PostAsync<TRequest, TResponse>(string path, string methodName, TRequest request) where TResponse : BaseResponse
    {
      TResponse response = await BaseRequest
        .AppendPathSegment(path)
        .PostJsonAsync(request)
        .ReceiveJson<TResponse>();

      if (response.Code != HttpStatusCode.OK)
      {
        ThrowException(response, methodName);
      }

      return response;
    }

    private static AuthenticationException ThrowException(BaseResponse response, string methodeName)
    {
      throw new AuthenticationException($"Error during calling the methode : {methodeName}, with Code : {response.Code} Status : {response.Status} Message : {response.Message}");
    }

    private static BaseResponse GenerateBaseRequest(FlurlHttpException flurlHttpException) => new BaseResponse
    {
      Code = flurlHttpException.StatusCode.HasValue ? (HttpStatusCode)flurlHttpException.StatusCode : HttpStatusCode.InternalServerError,
      Status = "FAILURE",
      Message = flurlHttpException.Message
    };
  }
}
