namespace HyperSyncInteractiveApi.Authentication.Models.Login
{
  public class LoginRequest
  {
    public string Uid { get; set; }
    public string Pwd { get; set; }
    public string BrokerId { get; set; }
    public string DeviceInfo { get; set; }
    public string Source { get; set; }
    public string DeviceName { get; set; }
    public string LoginChallenge { get; set; }
  }
}
