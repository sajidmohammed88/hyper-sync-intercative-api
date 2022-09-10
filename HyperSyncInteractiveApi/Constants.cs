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
      internal const string Source = "Web";
      internal const string DeviceName = "Chrome";
      internal const string RedirectUri = "http://localhost/oauth/authorise";
      internal const string ResponseType = "code";
      internal const string GrantType = "authorization_code";
    }

    internal static class Trading
    {
      internal const string BaseUrl = "https://uathsint.hypertrade.in";
      private const string _userBasePath = "quick/user/";
      private const string _orderBasePath = "quick/order/";

      internal static class User
      {
        internal const string UserDetailsPath = _userBasePath + "details";
        internal const string ResetUserPath = _userBasePath + "reset";
        internal const string DefaultLoginPath = _userBasePath + "login/default";
      }

      internal static class Book
      {
        internal const string OrderBookPath = _userBasePath + "orders";
        internal const string OrderHistoryPath = _orderBasePath + "history";
        internal const string TradeBookPath = _userBasePath + "trades";
        internal const string PositionBookPath = _userBasePath + "positions";
      }

      internal static class Holding
      {
        internal const string HoldingsPath = _userBasePath + "holdings";
      }

      internal static class Order
      {
        internal const string PlaceOrderPath = _orderBasePath + "place";
        internal const string VrPlaceOrderPath = _orderBasePath + "vr/place";
        internal const string ModifyOrderPath = _orderBasePath + "modify";
        internal const string VrModifyOrderPath = _orderBasePath + "vr/modify";
        internal const string CancelOrderPath = _orderBasePath + "cancel";
        internal const string ExistCoverOrderPath = _orderBasePath + "co/exit";
        internal const string CoverOrderRangePath = _orderBasePath + "co/range";
        internal const string LoadRetentionTypesPath = "/quick/load/retention/types";
        internal const string LotsAndWeightsPath = _userBasePath + "get/lot-weight";
      }

      internal static class PositionConversion
      {
        internal const string PostionConversionPath = "quick/convert/partialposition";

      }

      internal static class ScriptDetails
      {
        internal const string ScriptInfoPath = "quick/scrip/info";
        internal const string IndexListPath = "quick/index/list";
      }

      internal static class Limits
      {
        internal const string LimitsPath = "quick/user/limits";
      }
    }
  }
}
