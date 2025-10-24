using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public static class EncryptionHelper
{
    private static string key = "MyUltraSecretKeyMyUltraSecretKey";
    public static string Encrypt(string plainText)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);

        using(Aes aes = Aes.Create())
        {
            aes.Key = keyBytes;
            aes.GenerateIV();
            byte[] iv = aes.IV;

            using(var encryptor = aes.CreateEncryptor(aes.Key,iv))
            using (var ms = new MemoryStream())
            {
                ms.Write(iv, 0, iv.Length);
                using(var cs = new CryptoStream(ms,encryptor, CryptoStreamMode.Write))
                using (var sw = new StreamWriter(cs))
                {
                    sw.Write(plainText);
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }

    public static string Decrypt(string encryptedText)
    {
        byte[] fullCipher  = Convert.FromBase64String(encryptedText);
        byte[] iv = new byte[16];
        byte[] cipher = new byte[fullCipher.Length - iv.Length];

        Array.Copy(fullCipher, 0, iv, 0, iv.Length);
        Array.Copy(fullCipher,iv.Length,cipher, 0, cipher.Length);

        byte[] keyBytes = Encoding.UTF8.GetBytes(key);

        using(Aes aes = Aes.Create())
        {
            aes.Key = keyBytes;
            aes.IV = iv;

            using(var decryptor = aes.CreateDecryptor(aes.Key,aes.IV))
                using (var ms = new MemoryStream(cipher))
                using(var cs = new CryptoStream(ms,decryptor, CryptoStreamMode.Read))
                using(var sr = new StreamReader(cs))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
