using System.Text;

namespace UndyingWorld.Web.Services.Impl.Helpers
{
    public static class HashHelper
    {
        public static string GetHash(string input)
        {
            var hash = System.Security.Cryptography.SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(input);
            var byteHash = hash.ComputeHash(bytes);
            var sb = new StringBuilder();
            foreach (var t in byteHash)
            {
                sb.Append(t.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
