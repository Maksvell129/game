using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace game
{
    class HMACGenerator
    {
        public static string HMACGenerating(string move,string key)
        {

            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

            byte[] keyByte = encoding.GetBytes(key);

            HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);

            byte[] messageBytes = encoding.GetBytes(move);

            byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);

            string HMAC = ByteToString(hashmessage);

            return HMAC;
        }

        public static string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2");
            }
            return (sbinary);
        }

        public static string GetKey()
        {
            
            byte[] key = new Byte[16];
            RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(key);
            return BitConverter.ToString(key).Replace("-","");
        }
    }
}
