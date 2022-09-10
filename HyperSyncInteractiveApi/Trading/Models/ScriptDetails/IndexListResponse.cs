using System.Collections.Generic;

namespace HyperSyncInteractiveApi.Trading.Models.ScriptDetails
{
  public class IndexListResponse
  {
    public string Stat { get; set; }
    public List<string> IdxList { get; set; }
  }
}
