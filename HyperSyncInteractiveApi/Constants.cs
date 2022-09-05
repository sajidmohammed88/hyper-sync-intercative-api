namespace HyperSyncInteractiveApi
{
  public static class Constants
  {
    internal static class Authentication
    {
      internal const string BaseUrl = "https://uathsauth.hypertrade.in";
      internal const string AuthorizePath = "oauth/authorise";
      internal const string LoginPath = "api/login";

      internal const string State = "teststate";
      internal const string Scope = "profile";
      internal const string ClientId = "R7JW9DDMK0O";
      internal const string RedirectUri = "http://localhost/oauth/authorise";
      internal const string ResponseType = "code";
    }

  }
}
