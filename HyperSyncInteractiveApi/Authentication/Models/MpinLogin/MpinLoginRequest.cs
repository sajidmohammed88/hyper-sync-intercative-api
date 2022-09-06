using HyperSyncInteractiveApi.Authentication.Models.Login;

namespace HyperSyncInteractiveApi.Authentication.Models.MpinLogin
{
  public class MpinLoginRequest : LoginRequest
  {
    public MpinLoginRequest(LoginRequest loginRequest, string devicempinkey, string mpin)
    {
      BrokerId = loginRequest.BrokerId;
      LoginChallenge = loginRequest.LoginChallenge;
      Uid = loginRequest.Uid;
      DeviceInfo = loginRequest.DeviceInfo;
      Source = loginRequest.Source;
      DeviceName = loginRequest.DeviceName;
      Devicempinkey = devicempinkey;
      Mpin = mpin;
    }
    public string Devicempinkey { get; set; }

    public string Mpin { get; set; }
  }
}
