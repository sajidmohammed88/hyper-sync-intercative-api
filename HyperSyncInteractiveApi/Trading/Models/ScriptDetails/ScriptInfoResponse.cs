using HyperSyncInteractiveApi.Common.Models;
using System.Collections.Generic;

namespace HyperSyncInteractiveApi.Trading.Models.ScriptDetails
{
  public class ScriptInfoResponse : ResponseState
  {
    public List<ScriptInfo> Data { get; set; }
  }
}
