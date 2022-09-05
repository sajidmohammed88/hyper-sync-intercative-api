using HyperSyncInteractiveApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSyncInteractiveApi.Authentication.Models.Login
{
  public class LoginResponse : BaseResponse
  {
    public LoginData Data { get; set; }
  }
}
