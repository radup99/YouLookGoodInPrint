using System;
using System.Text;
using System.Security.Cryptography;

namespace YouLookGoodInPrint.Shared
{
    public static class HashGenerator
    {
        public static string GetHash(this string password)
        {
            StringBuilder Sb = new StringBuilder();

            SHA256 hash = SHA256Managed.Create();
            Encoding enc = Encoding.UTF8;
            Byte[] result = hash.ComputeHash(enc.GetBytes(password));

            foreach (Byte b in result)
                Sb.Append(b.ToString("x2"));

            return Sb.ToString();
        }
    }
}
