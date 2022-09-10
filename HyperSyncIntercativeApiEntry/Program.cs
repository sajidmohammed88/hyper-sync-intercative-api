using HyperSyncInteractiveApi.Authentication;
using HyperSyncInteractiveApi.Trading;
using HyperSyncInteractiveApi.Trading.Models.Book;
using HyperSyncInteractiveApi.Trading.Models.Holdings;
using HyperSyncInteractiveApi.Trading.Models.Limits;
using HyperSyncInteractiveApi.Trading.Models.Order;
using HyperSyncInteractiveApi.Trading.Models.PositionConversion;
using HyperSyncInteractiveApi.Trading.Models.ScriptDetails;
using HyperSyncInteractiveApi.Trading.Models.User;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HyperSyncIntercativeApiEntry
{
  internal class Program
  {
    static async Task Main(string[] args)
    {
      var keys = args.ToDictionary(k => k.Substring(0, k.IndexOf(':')), v => v.Substring(v.IndexOf(':') + 1));

      // token generator
      BearerTokenService bearerTokenService = new BearerTokenService(new HsAuthentication());
      string token = await bearerTokenService.GetBearerTokenAsync(keys["client_id"], keys["client_secret"], keys["uid"], keys["pwd"], keys["mpin"]);
      Debug.WriteLine(token);
      // trade api

      HsInteractiveApi hsInteractiveApi = new HsInteractiveApi(token);

      // user
      ResetUserResponse resetUserResponse = await hsInteractiveApi.ResetUserAsync();
      UserDetails userDetails = await hsInteractiveApi.GetDefaultLoginAsync();
      AccountDetails accountDetails = await hsInteractiveApi.GetUserDetailsAsync();

      // books
      OrderBookResponse orderBookResponse = await hsInteractiveApi.GetOrderBookAsync();
      OrderHistoryResponse orderHistoryResponse = await hsInteractiveApi.GetOrderHistoryAsync(new OrderHistoryRequest { NOrdNo = "" });
      TradeBookResponse tradeBookResponse = await hsInteractiveApi.GetTradeBookAsync();
      PositionBookResponse positionBookResponse = await hsInteractiveApi.GetPositionBookAsync();

      // holdings
      HoldingResponse holdingResponse = await hsInteractiveApi.GetHoldingsAsync(new HoldingRequest { BrkName = "", Prod = "" });

      //orders
      PlaceOrderResponse placeOrderResponse = await hsInteractiveApi.PlaceOrderAsync(new PlaceOrderRequest
      {

      });
      PlaceOrderResponse vrPlaceOrderResponse = await hsInteractiveApi.VrPlaceOrderAsync(new VrPlaceOrderRequest
      {

      });
      PlaceOrderResponse modifyOrderResponse = await hsInteractiveApi.ModifyOrderAsync(new ModifyOrderRequest
      {

      });
      PlaceOrderResponse vrModifyOrderResponse = await hsInteractiveApi.VrModifyOrderAsync(new VrModifyOrderRequest
      {

      });
      OrderBaseResponse cancelOrderResponse = await hsInteractiveApi.CancelOrderAsync(new CancelOrderRequest
      {

      });
      OrderBaseResponse existCoverOrderResponse = await hsInteractiveApi.ExitCoverOrderAsync(new ExistCoverOrderRequest
      {

      });
      CoverOrderRangeResponse coverOrderRangeResponse = await hsInteractiveApi.FillCoverOrderRangeAsync(new CoverOrderRangeRequest
      {

      });
      RetentionTypesResponse retentionTypesResponse = await hsInteractiveApi.LoadRetentionTypesAsync(new RetentionTypesRequest
      {

      });
      LotAndWeightResponse lotAndWeightResponse = await hsInteractiveApi.GetLotsAndWeightsAsync();

      // position conversion
      PositionConversionResponse PositionConversionResponse = await hsInteractiveApi.PartialPositionConversionAsync(new PositionConversionRequest
      {

      });

      // script details
      ScriptInfoResponse scriptInfoResponse = await hsInteractiveApi.FillScriptInfoAsync(new ScriptInfoRequest
      {

      });

      IndexListResponse indexListResponse = await hsInteractiveApi.FillIndexListAsync(new IndexListRequest
      {

      });

      // Limits
      RmsLimitsResponse rmsLimitsResponse = await hsInteractiveApi.FillRmsLimitsAsync(new RmsLimitsRequest
      {

      });
    }
  }
}
