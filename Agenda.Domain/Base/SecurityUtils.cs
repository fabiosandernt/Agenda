using System.Security.Cryptography;

namespace Agenda.Domain.Base
{
    public class SecurityUtils
    {
        public static String HashSHA256(String text)
        {
            return GetSHA256HashData(text);
        }

        private static string GetSHA256HashData(string data)
        {
            SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider();
            byte[] byteV = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] byteH = SHA256.ComputeHash(byteV);

            SHA256.Clear();

            return Convert.ToBase64String(byteH);
        
        }
    }
}
