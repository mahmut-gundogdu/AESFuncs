using System;
using System.Linq;

namespace EncryptDecryptApp
{
    public static class Extensions
    {
        public static string FormatToString(this byte[] bytes)
        {
           return string.Concat(Array.ConvertAll(bytes, x => x.ToString("X2")));
        }

        public static byte[] FormatToByteArray(this string hex)
        {
               return Enumerable.Range(0, hex.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                     .ToArray(); ;
        }
    }
}
