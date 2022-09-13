using System.Net;

namespace HyperSyncInteractiveApi.Common.Models
{
  public class ResponseState
  {
    public string Stat { get; set; }
    public HttpStatusCode StCode { get; set; }
    public string ErrMsg { get; set; }
  }
}
