using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public class HashPassword : IHashPassword
    {
        public string Hash(string pass)
        {
            var inputBytes = Encoding.UTF8.GetBytes(pass);
            using var sha256 = SHA256.Create();

            var outputBytes = sha256.ComputeHash(inputBytes);
            return string.Join("", outputBytes.Select(b => b.ToString("x2")));
        }
    }
}
