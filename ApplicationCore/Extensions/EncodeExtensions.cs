using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ApplicationCore.Extensions
{
    public static class EncodeExtensions
    {
        public static string EncodeTextMd5(this string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            var originalBytes = Encoding.Default.GetBytes(text);
            var encodedBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes);
        }
    }
}
