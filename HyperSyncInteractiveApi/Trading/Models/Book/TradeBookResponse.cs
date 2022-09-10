using HyperSyncInteractiveApi.Common.Models;
using System.Collections.Generic;

namespace HyperSyncInteractiveApi.Trading.Models.Book
{
  public class TradeBookResponse : ResponseState
  {
    public List<TradeBook> Data { get; set; }
  }
}
