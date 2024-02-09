using System.Security.Cryptography;
using System.Text;

namespace IbsRestApi.Common;

public static class EncryptionAlg
{
    #region Encryption Variables

    #region AES Variables
    /// <summary>
    /// AES Encryption keys
    /// </summary>
    static readonly byte[] keybytes = Encoding.UTF8.GetBytes("0001020304050607");
    static readonly byte[] iv = Encoding.UTF8.GetBytes("1011121314151617");
    #endregion AES Variables


    #region RSA Alg Variables
    private static readonly bool _optimalAsymmetricEncryptionPadding = false;

    //These keys are of 2048byte
    private static readonly string PublicKey = "MjA0OCE8UlNBS2V5VmFsdWU+PE1vZHVsdXM+djFTTVVyYk5SZW50VDEya0FhWXNRMEh3Y2hjWG9nbnFUWGpYd1NXaGR5Qi9aaTQ5VnF4L0lFdWxSaGFhVjdHOUtENWRmY0I4eEZaZGgyNGJ0MHpZbGFNTlFyRVBNNnQzUEdvZXZmMXVCby9wVnhlcWFocEFkWkIwelNJcjhwTk5UOW52czV5WEN1Q00xRFo0UUR3Q3A3b2U2aXc2ZHZ4VEZNWFZJdW9rSkcrdmlFMWhORDhnbGg0dFVsMWVBdThKT3YyR0tyWmhvTmUxK2tnRzNNUmRueEFGTDQyRDl4eWF5NERvcmpGL2ZjYWNNc3dFYkM3MUo2bFNobnR2YnQ1RnY0elY1bkg0aDhqYzhnV1dQVDUvWG16TElLMmlJRDJ6L3NyeGgvbzdMRkRhWVhXMnVwbUt5VUJQR2k0OGJLUVZKT3JjZU9rd3owWE1nTDFJUk4yWnhRPT08L01vZHVsdXM+PEV4cG9uZW50PkFRQUI8L0V4cG9uZW50PjwvUlNBS2V5VmFsdWU+";
    private static readonly string PrivateKey = "MjA0OCE8UlNBS2V5VmFsdWU+PE1vZHVsdXM+djFTTVVyYk5SZW50VDEya0FhWXNRMEh3Y2hjWG9nbnFUWGpYd1NXaGR5Qi9aaTQ5VnF4L0lFdWxSaGFhVjdHOUtENWRmY0I4eEZaZGgyNGJ0MHpZbGFNTlFyRVBNNnQzUEdvZXZmMXVCby9wVnhlcWFocEFkWkIwelNJcjhwTk5UOW52czV5WEN1Q00xRFo0UUR3Q3A3b2U2aXc2ZHZ4VEZNWFZJdW9rSkcrdmlFMWhORDhnbGg0dFVsMWVBdThKT3YyR0tyWmhvTmUxK2tnRzNNUmRueEFGTDQyRDl4eWF5NERvcmpGL2ZjYWNNc3dFYkM3MUo2bFNobnR2YnQ1RnY0elY1bkg0aDhqYzhnV1dQVDUvWG16TElLMmlJRDJ6L3NyeGgvbzdMRkRhWVhXMnVwbUt5VUJQR2k0OGJLUVZKT3JjZU9rd3owWE1nTDFJUk4yWnhRPT08L01vZHVsdXM+PEV4cG9uZW50PkFRQUI8L0V4cG9uZW50PjxQPi8yY1VJS2RlMFB1b2RVaDJQQ3krbFU0aWFvVWtOZ0dOOVhHNmhvcll3c1ovbzdwdTJYZjZmS2E5M09OZ1R0NUpqaW5QL3grZG9ibmFiU1hNNFNwRGJlb3JVRGZBKzhYeDIxTHBCT0FtYUtUVWlkejNjMHlQRXBQZ3lOMlpVb3poUWhjejZlUk01cUdQSlgxU29WMjczM3ZUREFtTEVWS0N4eFRZOHVNSWI3OD08L1A+PFE+djhjYlBmcHh5aXZUelhsV2Q5L3hNK3pRUlJRSk4rTDFIYURiNHYxKzU3dExEb3VlcG03ajI0MkJFZ2U4dTNENmJEanZneWhBWFIxV3IwR09KSjBBb1ZPV2FLLzdvZ3NHZjBnM1dzNzVicWtWSmdNTHZETnFxSVVVd0ZqZml3TllONkJnN0dIdGl2S0VGdmJldTEzcGFxVERyTnFuV0ZQaWFQK1lkQ09xVjNzPTwvUT48RFA+eWVSVDF0UTNjWC9kMUlocFhud0lVOEltRm9vVTY5UWl3YWtiUjR1dWVabXNBR001aVJMOG9WaTFzVXpVTHNRczVRSk1kMklvbTFWdFF1YWtwRUZpZUJxcURvbGtOaUp0WTNDUTN0Zkp4T0szV0J1aVNEUjJ6THEwOEZPc0JjTnp0V2plRXIvendrUm9BYnlsZXdXN281Z2dadDJNWHk4WVRnTSsxQkYvODhVPTwvRFA+PERRPlRGOUxYd1JFbW9HWHFJVkF4UjVlblJJYTR0ZVcwRFhHN1pTbzNKMmRFMFhJSHpQRTYzelBxeGlRSlJFRnZSUEI5cVU1NU41N3UxazZzektGRzltV2JhaXZCbVBHN3dJN0JTZEtQQlNleXMzMUNSMC9hQ1NGdmpTNVRkeFdzYktVU0JyTFhuZWxOS2RkcVJPSkljN0ZiTjNPdXlDY2NoVjkzZGlqNnVSbEtzOD08L0RRPjxJbnZlcnNlUT5rSmYwVHZoNDZjTEQ4OElIVVZ0V3hYaDVsYlNUTWw2ZnB5cFhhUU9laUtpTy9XcnZic21waXdBVEhDQ0pERDhYdDFwbTc5K0hrc21sUjlrYktXR2U4WmNqZHJHdUZlZ3NDUGRpT3VGMVN0a283NWtnblJVY0ZTb1hxSzF1YVgvTWsxTEtDbVpZY3djQ0t2VC9OQUZrWVpVdVNqT3pPckVrRk9VNDdML3VDVE09PC9JbnZlcnNlUT48RD5HbTMyZUZLU0pvODYzZFRFbkFtMVlaRVJRdUZYdldWN1BUcHRLMXdrWXMxVmErc0ZSQnpON3Nza1NIdEUxTXBUbytTQmk2WjBWYmJNY3JIT0dGTUFOQ055Nkh5RzZnOU1pRWJzZWpndzQ2MHJnWUZlWkF1K1RiOG5zMUorR2FNcGNkZGNHa2FPUXMxa0JzaURjZlFZTmMwckNoUVQrMjI5bUVmL3VqUDN6Q1IzcUNzdkZjVTRuMkMwZzBYSWhLQ1dHYXRsbW5MOW9FMWN0MzY4aWZYK0JCUVljUExqSE05TTZaSU9pMWtmR3M2bXhaT0V3cm1BWFB0T0ZweW1tNlZjMUM4WGtVUENCVERtWUZTSFpiaHNaT09IZHpaVVlUa2lmN1VzRk40MjdTSDVrMTNpQTVGRGJTb053bW9kQ0ZrWitENGJNQ2JUZWgwVTNvell6M3FnM1E9PTwvRD48L1JTQUtleVZhbHVlPg==";

    #endregion RSA Alg Variables

    #endregion Encryption Variables

    #region AES Encryption Methods


    public static string DecryptStringAES(string cipherText)
    {

        var encrypted = Convert.FromBase64String(cipherText);
        var decriptedFromJavascript = DecryptStringFromBytes(encrypted, keybytes, iv);
        return decriptedFromJavascript;
    }

    public static string EncryptStringAES(string clearText)
    {
        return Convert.ToBase64String(EncryptStringToBytes(clearText, keybytes, iv));
    }


    private static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
    {
        // Check arguments.
        if (cipherText == null || cipherText.Length <= 0)
        {
            throw new ArgumentNullException("cipherText");
        }
        if (key == null || key.Length <= 0)
        {
            throw new ArgumentNullException("key");
        }
        if (iv == null || iv.Length <= 0)
        {
            throw new ArgumentNullException("key");
        }

        // Declare the string used to hold
        // the decrypted text.
        string plaintext = null;

        // Create an RijndaelManaged object
        // with the specified key and IV.
        using (var rijAlg = new RijndaelManaged())
        {
            //Settings
            rijAlg.Mode = CipherMode.CBC;
            rijAlg.Padding = PaddingMode.PKCS7;
            rijAlg.FeedbackSize = 128;

            rijAlg.Key = key;
            rijAlg.IV = iv;

            // Create a decrytor to perform the stream transform.
            var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
            try
            {
                // Create the streams used for decryption.
                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {

                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();

                        }

                    }
                }
            }
            catch
            {
                plaintext = "keyError";
            }
        }

        return plaintext;
    }

    private static byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
    {
        // Check arguments.
        if (plainText == null || plainText.Length <= 0)
        {
            throw new ArgumentNullException("plainText");
        }
        if (key == null || key.Length <= 0)
        {
            throw new ArgumentNullException("key");
        }
        if (iv == null || iv.Length <= 0)
        {
            throw new ArgumentNullException("key");
        }
        byte[] encrypted;
        // Create a RijndaelManaged object
        // with the specified key and IV.
        using (var rijAlg = new RijndaelManaged())
        {
            rijAlg.Mode = CipherMode.CBC;
            rijAlg.Padding = PaddingMode.PKCS7;
            rijAlg.FeedbackSize = 128;

            rijAlg.Key = key;
            rijAlg.IV = iv;

            // Create a decrytor to perform the stream transform.
            var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

            // Create the streams used for encryption.
            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
        }

        // Return the encrypted bytes from the memory stream.
        return encrypted;
    }


    #endregion AES Encryption Methods


    #region RSA Alg Encryption Methods

    static void GetKeyFromEncryptionString(string rawkey, out int keySize, out string xmlKey)
    {
        keySize = 0;
        xmlKey = "";

        if (rawkey != null && rawkey.Length > 0)
        {
            byte[] keyBytes = Convert.FromBase64String(rawkey);
            var stringKey = Encoding.UTF8.GetString(keyBytes);

            if (stringKey.Contains("!"))
            {
                var splittedValues = stringKey.Split(new char[] { '!' }, 2);

                try
                {
                    keySize = int.Parse(splittedValues[0]);
                    xmlKey = splittedValues[1];
                }
                catch (Exception e) { }
            }
        }
    }

    static int GetMaxDataLength(int keySize)
    {
        if (_optimalAsymmetricEncryptionPadding)
        {
            return ((keySize - 384) / 8) + 7;
        }
        return ((keySize - 384) / 8) + 37;
    }

    static bool IsKeySizeValid(int keySize)
    {
        return keySize >= 384 && keySize <= 16384 && keySize % 8 == 0;
    }

    static byte[] Decrypt(byte[] data, int keySize, string publicAndPrivateKeyXml)
    {
        if (data == null || data.Length == 0) throw new ArgumentException("Data are empty", "data");
        if (!IsKeySizeValid(keySize)) throw new ArgumentException("Key size is not valid", "keySize");
        if (string.IsNullOrEmpty(publicAndPrivateKeyXml)) throw new ArgumentException("Key is null or empty", "publicAndPrivateKeyXml");

        using (var provider = new RSACryptoServiceProvider(keySize))
        {
            provider.FromXmlString(publicAndPrivateKeyXml);
            return provider.Decrypt(data, _optimalAsymmetricEncryptionPadding);
        }
    }

    static byte[] Encrypt(byte[] data, int keySize, string publicKeyXml)
    {
        if (data == null || data.Length == 0) throw new ArgumentException("Data are empty", "data");
        int maxLength = GetMaxDataLength(keySize);
        if (data.Length > maxLength) throw new ArgumentException(string.Format("Maximum data length is {0}", maxLength), "data");
        if (!IsKeySizeValid(keySize)) throw new ArgumentException("Key size is not valid", "keySize");
        if (string.IsNullOrEmpty(publicKeyXml)) throw new ArgumentException("Key is null or empty", "publicKeyXml");

        using (var provider = new RSACryptoServiceProvider(keySize))
        {
            provider.FromXmlString(publicKeyXml);
            return provider.Encrypt(data, _optimalAsymmetricEncryptionPadding);
        }
    }

    /// <summary>
    /// Returns a plain text from encrypted text using RSA Encryption Algorithm
    /// </summary>
    /// <param name="encryptedText">enryptedText</param>
    /// <returns>Returns a plain text</returns>
    public static string RSADecrypt(string encryptedText)
    {

        GetKeyFromEncryptionString(PrivateKey, out int keySize, out string publicAndPrivateKeyXml);

        var decrypted = Decrypt(Convert.FromBase64String(encryptedText), keySize, publicAndPrivateKeyXml);

        return Encoding.UTF8.GetString(decrypted);
    }

    /// <summary>
    /// Returns a encrypted text from plain text using RSA Encryption Algorithm
    /// </summary>
    /// <param name="plainText">plainText</param>
    /// <returns>Returns a encrypted text</returns>
    public static string RSAEncrypt(string plainText)
    {

        GetKeyFromEncryptionString(PublicKey, out int keySize, out string publicKeyXml);

        var encrypted = Encrypt(Encoding.UTF8.GetBytes(plainText), keySize, publicKeyXml);

        return Convert.ToBase64String(encrypted);
    }


    #endregion RSA Alg Encryption Methods


    #region SHA512 Hash Methods

    static string ByteToString(byte[] buff)
    {
        string sbinary = "";

        for (int i = 0; i < buff.Length; i++)
        {
            sbinary += buff[i].ToString("X2"); // hex format
        }
        return (sbinary);
    }




    public static string ToSha512(this string value, string salt)
    {

        ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
        byte[] keyByte = encoding.GetBytes(salt);
        HMACSHA512 hMACSHA = new HMACSHA512(keyByte);

        byte[] messageBytes = encoding.GetBytes(value);
        byte[] hashmessage = hMACSHA.ComputeHash(messageBytes);

        return ByteToString(hashmessage);
    }

    public static string EncryptSha512(this string value, string salt)
    {
        return Encrypt(value, salt, SHA512.Create());
    }


    /// <summary>
    /// Encrypts the given <see cref="string"/> with SHA512.
    /// </summary>
    /// <param name="value">The <see cref="string"/>.
    /// <returns>The encrypted <see cref="string"/>.
    public static string EncryptSha512(this string value)
    {
        return Encrypt(value, string.Empty, SHA512.Create());
    }


    /// <summary>
    /// Encrypts the given <see cref="string"/> with the given <see cref="HashAlgorithm"/>.
    /// </summary>
    /// <param name="value">The <see cref="string"/>.
    /// <param name="salt">The salt.</param>
    /// <param name="hashAlgorithm">The hash algorithm.</param>
    /// <returns>The encrypted <see cref="string"/>.
    private static string Encrypt(string value, string salt, HashAlgorithm hashAlgorithm)
    {
        byte[] valueBytes = Encoding.UTF8.GetBytes(value);
        byte[] saltBytes = Encoding.UTF8.GetBytes(salt);

        byte[] toHash = new byte[valueBytes.Length + saltBytes.Length];
        Array.Copy(valueBytes, 0, toHash, 0, valueBytes.Length);
        Array.Copy(saltBytes, 0, toHash, valueBytes.Length, saltBytes.Length);

        var hash = hashAlgorithm.ComputeHash(toHash);
        return BitConverter.ToString(hash).Replace("-", string.Empty);
    }

    #endregion SHA512 Hash Methods

}