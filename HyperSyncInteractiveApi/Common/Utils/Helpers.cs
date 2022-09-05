using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace HyperSyncInteractiveApi.Common.Utils
{
  internal static class Helpers
  {
    internal static string ComputeHash(string input)
    {
      using (var sha256 = MD5.Create())
      {
        return BitConverter
            .ToString(sha256.ComputeHash(Encoding.UTF8.GetBytes(input)))
            .Replace("-", "")
            .ToLowerInvariant();
      }
    }

    internal static string GetQueryValueByName(string query, string key) => HttpUtility.ParseQueryString(query).Get(key);
  }
}
