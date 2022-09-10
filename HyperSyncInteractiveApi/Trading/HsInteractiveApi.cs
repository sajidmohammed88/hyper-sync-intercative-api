using HyperSyncInteractiveApi.Trading.Abstractions;
using HyperSyncInteractiveApi.Trading.Models.Book;
using HyperSyncInteractiveApi.Trading.Models.Holdings;
using HyperSyncInteractiveApi.Trading.Models.Limits;
using HyperSyncInteractiveApi.Trading.Models.Order;
using HyperSyncInteractiveApi.Trading.Models.PositionConversion;
using HyperSyncInteractiveApi.Trading.Models.ScriptDetails;
using HyperSyncInteractiveApi.Trading.Models.User;
using System.Threading.Tasks;

namespace HyperSyncInteractiveApi.Trading
{
  public class HsInteractiveApi : HsInteractiveApiBase, IHsInteractiveApi
  {
    public HsInteractiveApi(string token) : base(token, Constants.Trading.BaseUrl)
    {
    }

    #region USER

    public Task<UserDetails> GetDefaultLoginAsync()
    {
      return PostAsync<UserDetails>(Constants.Trading.User.DefaultLoginPath);
    }

    public Task<AccountDetails> GetUserDetailsAsync()
    {
      return PostAsync<AccountDetails>(Constants.Trading.User.UserDetailsPath);
    }

    public Task<ResetUserResponse> ResetUserAsync()
    {
      return PostAsync<ResetUserResponse>(Constants.Trading.User.ResetUserPath);
    }

    #endregion
    #region Book

    public Task<OrderBookResponse> GetOrderBookAsync()
    {
      return PostAsync<OrderBookResponse>(Constants.Trading.Book.OrderBookPath);
    }

    public Task<OrderHistoryResponse> GetOrderHistoryAsync(OrderHistoryRequest orderHistoryRequest)
    {
      return PostAsync<OrderHistoryRequest, OrderHistoryResponse>(Constants.Trading.Book.OrderHistoryPath, orderHistoryRequest);
    }

    public Task<TradeBookResponse> GetTradeBookAsync()
    {
      return PostAsync<TradeBookResponse>(Constants.Trading.Book.TradeBookPath);
    }

    public Task<PositionBookResponse> GetPositionBookAsync()
    {
      return PostAsync<PositionBookResponse>(Constants.Trading.Book.PositionBookPath);
    }

    #endregion
    #region Holdings
    public Task<HoldingResponse> GetHoldingsAsync(HoldingRequest holdingRequest)
    {
      return PostAsync<HoldingRequest, HoldingResponse>(Constants.Trading.Holding.HoldingsPath, holdingRequest);
    }
    #endregion
    #region Order

    public Task<PlaceOrderResponse> PlaceOrderAsync(PlaceOrderRequest placeOrderRequest)
    {
      return PostAsync<PlaceOrderRequest, PlaceOrderResponse>(Constants.Trading.Order.PlaceOrderPath, placeOrderRequest);
    }

    public Task<PlaceOrderResponse> VrPlaceOrderAsync(VrPlaceOrderRequest vrPlaceOrderRequest)
    {
      return PostAsync<VrPlaceOrderRequest, PlaceOrderResponse>(Constants.Trading.Order.VrPlaceOrderPath, vrPlaceOrderRequest);
    }

    public Task<PlaceOrderResponse> ModifyOrderAsync(ModifyOrderRequest modifyOrderRequest)
    {
      return PostAsync<ModifyOrderRequest, PlaceOrderResponse>(Constants.Trading.Order.ModifyOrderPath, modifyOrderRequest);
    }

    public Task<PlaceOrderResponse> VrModifyOrderAsync(VrModifyOrderRequest vrModifyOrderRequest)
    {
      return PostAsync<VrModifyOrderRequest, PlaceOrderResponse>(Constants.Trading.Order.VrModifyOrderPath, vrModifyOrderRequest);
    }

    public Task<OrderBaseResponse> CancelOrderAsync(CancelOrderRequest cancelOrderRequest)
    {
      return PostAsync<CancelOrderRequest, OrderBaseResponse>(Constants.Trading.Order.CancelOrderPath, cancelOrderRequest);
    }

    public Task<OrderBaseResponse> ExitCoverOrderAsync(ExistCoverOrderRequest existCoverOrderRequest)
    {
      return PostAsync<ExistCoverOrderRequest, OrderBaseResponse>(Constants.Trading.Order.ExistCoverOrderPath, existCoverOrderRequest);
    }

    public Task<CoverOrderRangeResponse> FillCoverOrderRangeAsync(CoverOrderRangeRequest coverOrderRangeRequest)
    {
      return PostAsync<CoverOrderRangeRequest, CoverOrderRangeResponse>(Constants.Trading.Order.CoverOrderRangePath, coverOrderRangeRequest);
    }

    public Task<RetentionTypesResponse> LoadRetentionTypesAsync(RetentionTypesRequest retentionTypesRequest)
    {
      return PostAsync<RetentionTypesRequest, RetentionTypesResponse>(Constants.Trading.Order.LoadRetentionTypesPath, retentionTypesRequest);
    }

    public Task<LotAndWeightResponse> GetLotsAndWeightsAsync()
    {
      return PostAsync<LotAndWeightResponse>(Constants.Trading.Order.LotsAndWeightsPath);
    }

    #endregion
    #region Position conversion

    public Task<PositionConversionResponse> PartialPositionConversionAsync(PositionConversionRequest positionConversionRequest)
    {
      return PostAsync<PositionConversionRequest, PositionConversionResponse>(Constants.Trading.PositionConversion.PostionConversionPath, positionConversionRequest);
    }

    #endregion
    #region script details

    public Task<ScriptInfoResponse> FillScriptInfoAsync(ScriptInfoRequest scriptInfoRequest)
    {
      return PostAsync<ScriptInfoRequest, ScriptInfoResponse>(Constants.Trading.ScriptDetails.ScriptInfoPath, scriptInfoRequest);
    }

    public Task<IndexListResponse> FillIndexListAsync(IndexListRequest indexListRequest)
    {
      return PostAsync<IndexListRequest, IndexListResponse>(Constants.Trading.ScriptDetails.IndexListPath, indexListRequest);
    }

    #endregion
    #region limits

    public Task<RmsLimitsResponse> FillRmsLimitsAsync(RmsLimitsRequest rmsLimitsRequest)
    {
      return PostAsync<RmsLimitsRequest, RmsLimitsResponse>(Constants.Trading.Limits.LimitsPath, rmsLimitsRequest);
    }

    #endregion
  }
}
