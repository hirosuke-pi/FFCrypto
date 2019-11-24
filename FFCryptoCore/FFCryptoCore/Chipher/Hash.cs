using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;


namespace FFCryptCore.Chipher
{
    public class Hash
    {
        private static string baseStr = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static byte[] GetSHA256HashBytes(string strData)
        {
            SHA256Managed sha = new SHA256Managed();
            return sha.ComputeHash(Encoding.UTF8.GetBytes(strData));
        }

        public static string GetSHA256HashString(string strData)
        {
            return BitConverter.ToString(GetSHA256HashBytes(strData)).Replace("-", string.Empty);
        }

        public static string RandamString(int length)
        {
            StringBuilder sb = new StringBuilder(length);
            Random r = new Random(DateTime.Now.Millisecond * DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Hour);
            for (int i = 0; i < length; i++)
            {
                int pos = r.Next(baseStr.Length);
                sb.Append(baseStr[pos]);
            }
            return sb.ToString();
        }
    }
}
