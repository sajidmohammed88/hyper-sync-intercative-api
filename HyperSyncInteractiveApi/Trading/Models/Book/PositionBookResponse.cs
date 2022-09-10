using HyperSyncInteractiveApi.Common.Models;
using System.Collections.Generic;

namespace HyperSyncInteractiveApi.Trading.Models.Book
{
  public class PositionBookResponse : ResponseState
  {
    public List<PositionBook> Data { get; set; }
  }
}
