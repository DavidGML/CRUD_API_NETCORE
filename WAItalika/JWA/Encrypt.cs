using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WAItalika.JWA
{
    public class Encrypt
    {
        public static string GetSha256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder stringBuilder = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for ( int i = 0; i < stream.Length; i++)
                stringBuilder.AppendFormat("{0:2}", stream[i]);
                return stringBuilder.ToString();
        }
    }
}
