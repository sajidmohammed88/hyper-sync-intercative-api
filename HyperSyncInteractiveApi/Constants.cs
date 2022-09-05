namespace HyperSyncInteractiveApi
{
  public static class Constants
  {
    internal static class Authentication
    {
      internal const string BaseUrl = "https://uathsauth.hypertrade.in";
      internal const string AuthorizePath = "oauth/authorise";
      internal const string LoginPath = "api/login";
      internal const string MpinLoginPath = "api/mpinlogin";
      internal const string ConsentPath = "oauth/consent"; 
      internal const string TokenPath = "oauth/token";

      internal const string State = "teststate";
      internal const string Scope = "profile";
      internal const string RedirectUri = "http://localhost/oauth/authorise";
      internal const string ResponseType = "code";
      internal const string GrantType = "authorization_code";
    }
  }
}
