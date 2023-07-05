using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FMS
{
    class PasswordSecure
    {
       private string hash = "m@hm0ud";
        public PasswordSecure()
        {
            //for (int i = 65; i < 128; i++) 
            //{
            //    char c = (char)i;
            //    Console.WriteLine(c);
            //    TableContent.Add(i-65, c);
             
            //}
            //Console.WriteLine("Count :" + TableContent.Count);
        }
        public string Encrypt(string val)
        {
            byte[] result;
            byte[] data = UTF8Encoding.UTF8.GetBytes(val);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using(TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider() { Key = keys,Mode = CipherMode.ECB,Padding = PaddingMode.PKCS7})
                {
                    ICryptoTransform transform = tripleDES.CreateEncryptor();
                    result = transform.TransformFinalBlock(data, 0, data.Length);
                }
            }
            return Convert.ToBase64String(result, 0, result.Length);
        }
        public string Decrypt(string val)
        {
            byte[] result;
            byte[] data = Convert.FromBase64String(val);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripleDES.CreateDecryptor();
                    result = transform.TransformFinalBlock(data, 0, data.Length);
                }
            }
            return UTF8Encoding.UTF8.GetString(result);

        }
    }
}
