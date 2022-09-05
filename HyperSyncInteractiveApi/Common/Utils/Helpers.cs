using System;
using System.Security.Cryptography;
using System.Text;

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
  }
}
