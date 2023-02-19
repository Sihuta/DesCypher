using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BPDT_lab1.DES
{
    public static class Converter
    {
        public static string StringToBinary(string input)
        {
            return string.Join(
                string.Empty, // running them all together makes it tricky.
                Encoding.Unicode
                    .GetBytes(input)
                    .Select(b => Convert.ToString(b, 2).PadLeft(8, '0'))
            );
        }

        public static string BinaryToString(string input)
        {
            return Encoding.Unicode.GetString(
                Regex.Split(input, "(.{8})") // this is the consequence of running them all together.
                    .Where(binary => !string.IsNullOrEmpty(binary)) // keeps the matches; drops empty parts 
                    .Select(binary => Convert.ToByte(binary, 2))
                    .ToArray()
            );
        }

        public static string BinToString(string input)
        {
            return Encoding.Unicode.GetString(Convert.FromBase64String(input));
        }

        public static string StringToBin(string input)
        {
            return Encoding.Unicode.GetString(Convert.FromBase64String(input));
        }

        public static string NormalStrToHex(string str)
        {
            if (str == null || str.Length == 0)
            {
                return null;
            }

            byte[] arr = Encoding.Unicode.GetBytes(str);
            var hexStr = BitConverter.ToString(arr);
            return hexStr.Replace("-", "");
        }

        public static string HexStrToNormal(string hexStr)
        {
            if (hexStr == null || hexStr.Length == 0)
            {
                return null;
            }

            byte[] bytes = Enumerable.Range(0, hexStr.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hexStr.Substring(x, 2), 16))
                .ToArray();
            return Encoding.Unicode.GetString(bytes);
        }

        public static string HexToBin(string hexStr)
        {
            if (hexStr == null || hexStr.Length == 0)
            {
                return null;
            }

            return string.Join(
                string.Empty,
                hexStr.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0'))
            );
        }

        public static string BinToHex(string binStr)
        {
            if (binStr == null || binStr.Length == 0)
            {
                return null;
            }

            int byteLen = 8;
            var hexStr = new StringBuilder(binStr.Length / byteLen + 1);

            int mod4len = binStr.Length % byteLen;
            if (mod4len != 0)
            {
                binStr = binStr.PadLeft(((binStr.Length / byteLen) + 1) * byteLen, '0');
            }

            for (int i = 0; i < binStr.Length; i += byteLen)
            {
                string eightBits = binStr.Substring(i, byteLen);
                hexStr.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
            }

            return hexStr.ToString();
        }
    }
}
