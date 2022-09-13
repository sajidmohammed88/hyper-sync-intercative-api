using HyperSyncInteractiveApi.Authentication;
using HyperSyncInteractiveApi.Trading;
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
using System.Collections.Generic;
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
      OrderHistoryResponse orderHistoryResponse = await hsInteractiveApi.GetOrderHistoryAsync(new OrderHistoryRequest { NOrdNo = "22091300000002" });
      TradeBookResponse tradeBookResponse = await hsInteractiveApi.GetTradeBookAsync();
      PositionBookResponse positionBookResponse = await hsInteractiveApi.GetPositionBookAsync();

      // holdings
      HoldingResponse holdingResponse = await hsInteractiveApi.GetHoldingsAsync(new HoldingRequest { BrkName = "TELIGENZ", Prod = "CNC" });

      //orders
      PlaceOrderResponse placeOrderResponse = await hsInteractiveApi.PlaceOrderAsync(new PlaceOrderRequest
      {
        Am = "NO",
        Es = "nse_cm",
        Pc = "CNC",
        Pr = "118.45",
        Ot = "L",
        Qt = "101",
        Rt = "DAY",
        Tk = "11536",
        Tp = "0",
        Ts = "TCS-EQ",
        Tt = "B",
        Os = "MOB",
        Ig = "erfhj1234xcjid",
        Dq = "0",
        Ur = "ABCDE"
      });

      // not work orders
      PlaceOrderResponse vrPlaceOrderResponse = await hsInteractiveApi.VrPlaceOrderAsync(new VrPlaceOrderRequest
      {
        Am = "No",
        Dq = "0",
        Es = "nse_cm",
        Mp = "0",
        Os = "WEB",
        Pc = "CNC",
        Pf = "N",
        Pr = "0",
        Pt = "MKT",
        Qt = "1",
        Rt = "DAY",
        Tp = "0",
        Ts = "TCS-EQ",
        Tt = "B",
        Ur = ""
      });
      PlaceOrderResponse vrModifyOrderResponse = await hsInteractiveApi.VrModifyOrderAsync(new VrModifyOrderRequest
      {

      });
      // end not work orders

      PlaceOrderResponse modifyOrderResponse = await hsInteractiveApi.ModifyOrderAsync(new ModifyOrderRequest
      {

        Am = "NO",
        Dq = "0",
        On = "22091300000002",
        Os = "MOB",
        Ot = "MKT",
        Pr = "0",
        Qt = "4",
        Tk = "16921",
        Tp = "0",
        Ts = "20MICRONS-EQ",
        Vd = "DAY"
      });
      OrderBaseResponse cancelOrderResponse = await hsInteractiveApi.CancelOrderAsync(new CancelOrderRequest
      {
        Am = "YES",
        On = "22091300000002",
        Ts = "TCS-EQ"
      });
      OrderBaseResponse existCoverOrderResponse = await hsInteractiveApi.ExitCoverOrderAsync(new ExistCoverOrderRequest
      {
        On = "22091300000002"
      });
      CoverOrderRangeResponse coverOrderRangeResponse = await hsInteractiveApi.FillCoverOrderRangeAsync(new CoverOrderRangeRequest
      {
        ExSeg = "nse_cm",
        Sym = "11536",
        TrnsTp = "S"
      });
      RetentionTypesResponse retentionTypesResponse = await hsInteractiveApi.LoadRetentionTypesAsync(new RetentionTypesRequest
      {
        Exch = "NSE"
      });
      LotAndWeightResponse lotAndWeightResponse = await hsInteractiveApi.GetLotsAndWeightsAsync();

      // position conversion
      PositionConversionResponse PositionConversionResponse = await hsInteractiveApi.PartialPositionConversionAsync(new PositionConversionRequest
      {
        Ex = "nse_cm",
        Pc = "I",
        Ch = "NRML",
        Ts = "CIPLA-EQ",
        Os = "CPP_API",
        Qt = "1",
        Mf = "1"
      });

      // script details
      ScriptInfoResponse scriptInfoResponse = await hsInteractiveApi.FillScriptInfoAsync(new ScriptInfoRequest
      {
        ScripArr = new List<string> { "nse_cm|22" }
      });

      IndexListResponse indexListResponse = await hsInteractiveApi.FillIndexListAsync(new IndexListRequest
      {
        Exch = "NSE"
      });

      // Limits
      RmsLimitsResponse rmsLimitsResponse = await hsInteractiveApi.FillRmsLimitsAsync(new RmsLimitsRequest
      {
        Seg = "CASH",
        Exch = "NSE",
        Prod = "All"
      });

      // market
      MarketStatusResponse marketStatusResponse = await hsInteractiveApi.FillMarketStatusAsync(new MarketStatusRequest
      {
        Exch = "NSE"
      });

      // messages
      ExchangeMessageResponse exchangeMessageResponse = await hsInteractiveApi.FillExchangeMessageAsync(new ExchangeMessageRequest
      {
        Exch = "NSE"
      });

      // chart data
      ChartDataResponse chartDataResponse = await hsInteractiveApi.FillChartDataAsync(new ChartDataRequest
      {
        Exch = "NSE",
        Sym = "11536",
        Intvl = "60",
        GraphTp = "OHLC"
      });
    }
  }
}
