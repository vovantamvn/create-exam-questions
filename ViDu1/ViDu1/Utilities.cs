using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace ViDu1
{
    class Utilities
    {
        public static string NextID(string lastID, string prefixID)
        {
            int nextID = int.Parse(lastID.Remove(0, prefixID.Length)) + 1;
            int lengthNumerID = lastID.Length - prefixID.Length;
            string zeroNumber = "";
            for (int i = 1; i <= lengthNumerID; i++)
            {
                if (nextID < Math.Pow(10, i))
                {
                    for (int j = 1; j <= lengthNumerID - i; i++)
                    {
                        zeroNumber += "0";
                    }
                    return prefixID + zeroNumber + nextID.ToString();
                }
            }
            return prefixID + nextID;
        }

        public static string StepID(string lastID, int step, string prefixID)
        {
            int stepID = int.Parse(lastID.Remove(0, prefixID.Length)) + step;
            int lengthNumerID = lastID.Length - prefixID.Length;
            string zeroNumber = "";
            for (int i = 1; i <= lengthNumerID; i++)
            {
                if (stepID < Math.Pow(10, i))
                {
                    for (int j = 1; j <= lengthNumerID - i; i++)
                    {
                        zeroNumber += "0";
                    }
                    return prefixID + zeroNumber + stepID.ToString();
                }
            }
            return prefixID + stepID;
        }

        public static string MaHoaMD5(string text)
        {
            MD5CryptoServiceProvider _md5Hasher = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(text);
            bs = _md5Hasher.ComputeHash(bs);
            StringBuilder s = new StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2"));
            }
            return s.ToString();
        }

        #region Thong tin user
        //public static UserDto user = new UserDto();
        #endregion
    }
}