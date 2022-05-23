using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileManager
{
    public static class Crypter
    {
        private static string? xmlString;
        public static string Encrypt(string data)
        {
            var rsa = new RSACryptoServiceProvider();
            xmlString = rsa.ToXmlString(true);
            var encryptContent = rsa.Encrypt(Encoding.UTF8.GetBytes(data), true);
            return Convert.ToBase64String(encryptContent);
        }
        
        public static string Decrypt(string data)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(xmlString);
            var decryptContent = rsa.Decrypt(Convert.FromBase64String(data), true);
            return Encoding.UTF8.GetString(decryptContent);
        }
    }
}
