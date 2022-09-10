using System.Collections.Generic;

namespace HyperSyncInteractiveApi.Trading.Models.Market
{
  public class MarketStatusResponse
  {
    public string Stat { get; set; }
    public List<MarketStatus> MarketStatus { get; set; }
  }
}
