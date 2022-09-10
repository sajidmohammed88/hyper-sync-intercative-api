using HyperSyncInteractiveApi.Common.Models;
using System.Collections.Generic;

namespace HyperSyncInteractiveApi.Trading.Models.Book
{
  public class OrderHistoryResponse : ResponseState
  {
    public List<OrderHistory> Data { get; set; }
  }
}
