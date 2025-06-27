﻿using System.Text;

namespace WPF.ComTool.ViewModels
{
    public class ByteHelper
    {
        #region CRC16

        /// <summary>
        /// CRC16
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] CRC16(byte[] data)
        {
            int length = data.Length;
            if (length > 0)
            {
                ushort crc = 0xFFFF;
                for (int i = 0; i < length; i++)
                {
                    crc = (ushort)(crc ^ (data[i]));
                    for (int j = 0; j < 8; j++)
                    {
                        if ((crc & 0x0001) == 1)
                        {
                            crc = (ushort)((crc >> 1) ^ 0xA001);
                        }
                        else
                        {
                            crc >>= 1;
                        }
                    }
                }
                byte high = (byte)((crc ^ 0xFF00) >> 8);    // 高位
                byte low = (byte)(crc & 0x00FF);            // 低位

                return new byte[] { high, low };
            }

            return new byte[] { 0, 0 };
        }

        #endregion

        #region  ToCRC16

        public static string ToCRC16(string content)
        {
            return ToCRC16(content, Encoding.UTF8);
        }

        public static string ToCRC16(string content, bool isReverse)
        {
            return ToCRC16(content, Encoding.UTF8, isReverse);
        }

        public static string ToCRC16(string content, Encoding encoding)
        {
            return ByteToString(CRC16(encoding.GetBytes(content)), true);
        }

        public static string ToCRC16(string content, Encoding encoding, bool isReverse)
        {
            return ByteToString(CRC16(encoding.GetBytes(content)), isReverse);
        }

        public static string ToCRC16(byte[] data)
        {
            return ByteToString(CRC16(data), true);
        }

        public static string ToCRC16(byte[] data, bool isReverse)
        {
            return ByteToString(CRC16(data), isReverse);
        }
        #endregion

        #region  ToModbusCRC16

        public static string ToModbusCRC16(string s)
        {
            return ToModbusCRC16(s, true);
        }

        public static string ToModbusCRC16(string s, bool isReverse)
        {
            return ByteToString(CRC16(StringToHexByte(s)), isReverse);
        }

        public static string ToModbusCRC16(byte[] data)
        {
            return ToModbusCRC16(data, true);
        }

        public static string ToModbusCRC16(byte[] data, bool isReverse)
        {
            return ByteToString(CRC16(data), isReverse);
        }
        #endregion

        #region  ByteToString

        public static string ByteToString(byte[] arr, bool isReverse)
        {
            try
            {
                byte hi = arr[0], lo = arr[1];
                return Convert.ToString(isReverse ? hi + lo * 0x100 : hi * 0x100 + lo, 16).ToUpper().PadLeft(4, '0');
            }
            catch (Exception ex) { throw (ex); }
        }

        public static string ByteToString(byte[] arr)
        {
            try
            {
                return ByteToString(arr, true);
            }
            catch (Exception ex) { throw (ex); }
        }

        #endregion

        #region  StringToHexString

        public static string StringToHexString(string str)
        {
            StringBuilder s = new StringBuilder();
            foreach (short c in str.ToCharArray())
            {
                s.Append(c.ToString("X4"));
            }
            return s.ToString();
        }

        #endregion

        #region  StringToHexByte

        private static string ConvertChinese(string str)
        {
            StringBuilder s = new StringBuilder();
            foreach (short c in str.ToCharArray())
            {
                if (c <= 0 || c >= 127)
                {
                    s.Append(c.ToString("X4"));
                }
                else
                {
                    s.Append((char)c);
                }
            }
            return s.ToString();
        }

        private static string FilterChinese(string str)
        {
            StringBuilder s = new StringBuilder();
            foreach (short c in str.ToCharArray())
            {
                if (c > 0 && c < 127)
                {
                    s.Append((char)c);
                }
            }
            return s.ToString();
        }

        /// <summary>
        /// 字符串转16进制字符数组
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] StringToHexByte(string str)
        {
            return StringToHexByte(str, false);
        }

        /// <summary>
        /// 字符串转16进制字符数组
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isFilterChinese">是否过滤掉中文字符</param>
        /// <returns></returns>
        public static byte[] StringToHexByte(string str, bool isFilterChinese)
        {
            string hex = isFilterChinese ? FilterChinese(str) : ConvertChinese(str);

            //清除所有空格
            hex = hex.Replace(" ", "");
            //若字符个数为奇数，补一个0
            hex += hex.Length % 2 != 0 ? "0" : "";

            byte[] result = new byte[hex.Length / 2];
            for (int i = 0, c = result.Length; i < c; i++)
            {
                result[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return result;
        }
        #endregion

    }
}