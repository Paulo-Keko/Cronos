using System;
using System.Text;

namespace cronos.infrastructure.Tools
{
    public static class StringTools
    {
        public static string FormatMaxLength(this string param, int length)
        {
            if (string.IsNullOrEmpty(param))
                return param;

            return param.Length <= length ? param : param.Substring(0, length);
        }

        public static string EncondeTo64(this string param)
        {
            byte[] toEncodeAsBytes = Encoding.ASCII.GetBytes(param);
            return Convert.ToBase64String(toEncodeAsBytes);
        }
    }
}
