using HyperSyncInteractiveApi.Common.Models;
using System.Collections.Generic;

namespace HyperSyncInteractiveApi.Trading.Models.Holdings
{
  public class HoldingResponse : ResponseState
  {
    public string ClntId { get; set; }
    public List<Holding> HldVal { get; set; }
  }
}
