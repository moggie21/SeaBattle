using System;
using System.Security.Cryptography;
using System.Text;

public class AESEncryptor
{
    public static string Encrypt(string plainText, string password)
    {
        // Генерируем ключ из пароля
        if (password == null || password.Length == 0) password = "StandartPassword123";
        byte[] key;
        byte[] salt = GenerateSalt();
        using (Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(password, salt))
        {
            key = pdb.GetBytes(32);
        }

        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.Mode = CipherMode.CBC;
            aesAlg.Padding = PaddingMode.PKCS7;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (var msEncrypt = new System.IO.MemoryStream())
            {
                // Сохраняем salt и IV в начало потока
                msEncrypt.Write(salt, 0, salt.Length);
                msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);

                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    csEncrypt.Write(plainTextBytes, 0, plainTextBytes.Length);
                    csEncrypt.FlushFinalBlock();
                }

                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }

    // Метод дешифрования
    public static string Decrypt(string cipherText, string password)
    {
        if (password == null || password.Length == 0) password = "StandartPassword123";
        byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

        // Извлекаем salt и IV
        byte[] salt = new byte[16];
        byte[] iv = new byte[16];
        Array.Copy(cipherTextBytes, 0, salt, 0, 16);
        Array.Copy(cipherTextBytes, 16, iv, 0, 16);

        // Генерируем ключ
        byte[] key;
        using (Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(password, salt))
        {
            key = pdb.GetBytes(32);
        }

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = key;
            aesAlg.IV = iv;
            aesAlg.Mode = CipherMode.CBC;
            aesAlg.Padding = PaddingMode.PKCS7;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (var msDecrypt = new System.IO.MemoryStream(cipherTextBytes))
            {
                // Пропускаем salt и IV
                msDecrypt.Seek(32, System.IO.SeekOrigin.Begin);

                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }

    private static byte[] GenerateSalt()
    {
        byte[] salt = new byte[16];

        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        return salt;
    }

}