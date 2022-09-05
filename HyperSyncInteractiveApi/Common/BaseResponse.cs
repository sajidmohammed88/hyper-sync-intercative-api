using System.Net;

namespace HyperSyncInteractiveApi.Common
{
  /// <summary>
  /// The base response of the API.
  /// </summary>
  public class BaseResponse
  {
    /// <summary>
    /// The status code reponse.
    /// </summary>
    public HttpStatusCode Code { get; set; }

    /// <summary>
    /// The reponse status.
    /// </summary>
    public string Status { get; set; }

    public string Message { get; set; }
  }
}
