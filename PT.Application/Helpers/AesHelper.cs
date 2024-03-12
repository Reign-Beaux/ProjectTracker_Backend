using System.Security.Cryptography;
using System.Text;

namespace PT.Application.Helpers
{
    public static class AesHelper
    {
        private static readonly byte[] Key;
        private static readonly byte[] IV;

        static AesHelper()
        {
            string key = "12345678901234567890123456789012";
            string iv = "1234567890123456";

            if (key.Length != 32 || iv.Length != 16)
            {
                throw new ArgumentException("La clave debe ser de 32 caracteres y el IV debe ser de 16 caracteres.");
            }

            Key = Encoding.UTF8.GetBytes(key);
            IV = Encoding.UTF8.GetBytes(iv);
        }

        public static string Encrypt(string plainText)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msEncrypt = new MemoryStream();
            using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            using StreamWriter swEncrypt = new StreamWriter(csEncrypt, Encoding.UTF8);

            swEncrypt.Write(plainText);
            swEncrypt.Flush();
            csEncrypt.FlushFinalBlock();

            var result = Convert.ToBase64String(msEncrypt.ToArray());

            return result;
        }

        public static string Decrypt(string cipherText)
        {
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText));
            using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new StreamReader(csDecrypt);

            return srDecrypt.ReadToEnd();
        }
    }
}
