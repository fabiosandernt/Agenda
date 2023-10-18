using System.Security.Cryptography;

namespace Agenda.Domain.Base
{
    public class SecurityUtils
    {
        public static String HashSHA1(String text)
        {
            return GetSHA1HashData(text);
        }

        private static string GetSHA1HashData(string data)
        {
            SHA1CryptoServiceProvider SHA1 = new SHA1CryptoServiceProvider();
            byte[] byteV = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] byteH = SHA1.ComputeHash(byteV);

            SHA1.Clear();

            return Convert.ToBase64String(byteH);
        
        }
    }
}
