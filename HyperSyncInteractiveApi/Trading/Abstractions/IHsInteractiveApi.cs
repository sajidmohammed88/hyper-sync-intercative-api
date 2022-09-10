using HyperSyncInteractiveApi.Trading.Models.Book;
using HyperSyncInteractiveApi.Trading.Models.ChartData;
using HyperSyncInteractiveApi.Trading.Models.Holdings;
using HyperSyncInteractiveApi.Trading.Models.Limits;
using HyperSyncInteractiveApi.Trading.Models.Market;
using HyperSyncInteractiveApi.Trading.Models.Message;
using HyperSyncInteractiveApi.Trading.Models.Order;
using HyperSyncInteractiveApi.Trading.Models.PositionConversion;
using HyperSyncInteractiveApi.Trading.Models.ScriptDetails;
using HyperSyncInteractiveApi.Trading.Models.User;
using System.Threading.Tasks;

namespace HyperSyncInteractiveApi.Trading.Abstractions
{
  public interface IHsInteractiveApi
  {
    #region User

    Task<AccountDetails> GetUserDetailsAsync();
    Task<ResetUserResponse> ResetUserAsync();
    Task<UserDetails> GetDefaultLoginAsync();

    #endregion
    #region Book

    Task<OrderBookResponse> GetOrderBookAsync();

    Task<OrderHistoryResponse> GetOrderHistoryAsync(OrderHistoryRequest orderHistoryRequest);

    Task<TradeBookResponse> GetTradeBookAsync();

    Task<PositionBookResponse> GetPositionBookAsync();

    #endregion
    #region Holdings

    Task<HoldingResponse> GetHoldingsAsync(HoldingRequest holdingRequest);

    #endregion
    #region Orders

    Task<PlaceOrderResponse> PlaceOrderAsync(PlaceOrderRequest placeOrderRequest);

    Task<PlaceOrderResponse> VrPlaceOrderAsync(VrPlaceOrderRequest vrPlaceOrderRequest);

    Task<PlaceOrderResponse> ModifyOrderAsync(ModifyOrderRequest modifyOrderRequest);

    Task<PlaceOrderResponse> VrModifyOrderAsync(VrModifyOrderRequest vrModifyOrderRequest);

    Task<OrderBaseResponse> CancelOrderAsync(CancelOrderRequest cancelOrderRequest);

    Task<OrderBaseResponse> ExitCoverOrderAsync(ExistCoverOrderRequest existCoverOrderRequest);

    Task<CoverOrderRangeResponse> FillCoverOrderRangeAsync(CoverOrderRangeRequest coverOrderRangeRequest);

    Task<RetentionTypesResponse> LoadRetentionTypesAsync(RetentionTypesRequest retentionTypesRequest);

    Task<LotAndWeightResponse> GetLotsAndWeightsAsync();

    #endregion
    #region Position conversion

    Task<PositionConversionResponse> PartialPositionConversionAsync(PositionConversionRequest positionConversionRequest);

    #endregion
    #region Script details

    Task<ScriptInfoResponse> FillScriptInfoAsync(ScriptInfoRequest scriptInfoRequest);

    Task<IndexListResponse> FillIndexListAsync(IndexListRequest indexListRequest);

    #endregion
    #region Limits

    Task<RmsLimitsResponse> FillRmsLimitsAsync(RmsLimitsRequest rmsLimitsRequest);
    #endregion
    #region Market
    Task<MarketStatusResponse> FillMarketStatusAsync(MarketStatusRequest marketStatusRequest);
    #endregion
    #region Messages
    Task<ExchangeMessageResponse> FillExchangeMessageAsync(ExchangeMessageRequest exchangeMessageRequest);
    #endregion
    #region Chart data
    Task<ChartDataResponse> FillChartDataAsync(ChartDataRequest chartDataRequest);
    #endregion
  }
}
