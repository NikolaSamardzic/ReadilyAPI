using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Cryptography
{
    public class TokenGenerator
    {
        public static string GenerateRandomToken(int length)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[length];
                rng.GetBytes(randomBytes);

                string base64String = Convert.ToBase64String(randomBytes);

                base64String = base64String.Replace("+", "").Replace("/", "").Replace("=", "");

                return base64String.Substring(0, Math.Min(base64String.Length, length));
            }
        }
    }
}
