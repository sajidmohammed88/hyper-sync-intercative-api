using HyperSyncInteractiveApi.Trading.Models.User;
using System.Threading.Tasks;

namespace HyperSyncInteractiveApi.Trading.Abstractions
{
  public interface IHsInteractiveApi
  {
    #region User

    Task<AccountDetails> GetUserDetailsAsync();
    Task<ResetUserResponse> ResetUserAsync();
    Task<UserDetails> GetDefaultLoginAsync();

    #endregion
  }
}
