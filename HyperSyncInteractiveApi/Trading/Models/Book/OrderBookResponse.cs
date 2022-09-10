using HyperSyncInteractiveApi.Common.Models;
using System.Collections.Generic;

namespace HyperSyncInteractiveApi.Trading.Models.Book
{
  public partial class OrderBookResponse : ResponseState
  {
    public List<OrderBook> Data { get; set; }
  }
}
