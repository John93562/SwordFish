using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SwordFish.Cryptography.String
{
    public static class SwordFishCryptography
    {
        public static (byte[], byte[], byte[]) EncryptString(string message)
        {
            try
            {


                byte[] messageEncrypted = null;
                byte[] finalKey = null;
                byte[] finalIv = null;

                // Create a new instance of the RijndaelManaged 
                // class.  This generates a new key and initialization  
                // vector (IV). 
                using (Aes myRijndael = Aes.Create())
                {

                    myRijndael.GenerateKey();
                    myRijndael.GenerateIV();
                    // Encrypt the string to an array of bytes. 
                    byte[] encrypted = EncryptStringToBytes(message, myRijndael.Key, myRijndael.IV);
                    messageEncrypted = encrypted;
                    finalKey = myRijndael.Key;
                    finalIv = myRijndael.IV;

                    // Decrypt the bytes to a string. 
                    //string roundtrip = DecryptStringFromBytes(encrypted, myRijndael.Key, myRijndael.IV);

                    //Display the original data and the decrypted data.
                    //Console.WriteLine("Original:   {0}", message);
                    //Console.WriteLine("Round Trip: {0}", roundtrip);
                }
                return (messageEncrypted, finalKey, finalIv);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }

            return (new byte[2], new byte[2], new byte[2]);
        }
        public static byte[] EncryptString(string message, string key, string IV)
        {
            try
            {
                byte[] ivBytes = Encoding.UTF8.GetBytes(IV);
                byte[] ivBytes2 = new byte[16];


                for (int i = 0; i < 16; i++)
                {

                    if (ivBytes.Length > i && i < 16)
                    {
                        ivBytes2[i] = ivBytes[i];
                    }
                    else
                    {
                        ivBytes2[i] = 0;
                    }
                }


                byte[] messageEncrypted = null;

                // Create a new instance of the RijndaelManaged 
                // class.  This generates a new key and initialization  
                // vector (IV). 
                using (Aes myRijndael = Aes.Create())
                {

                    myRijndael.GenerateKey();
                    // Encrypt the string to an array of bytes. 
                    byte[] keybytes = Encoding.Default.GetBytes(key);

                    byte[] filteredBytes = new byte[32];
                    int counter = 0;
                    foreach (byte item in keybytes)
                    {

                        if (counter == 32)
                        {
                            break;
                        }

                        filteredBytes[counter] = item;
                        counter++;
                    }
                    byte[] encrypted = EncryptStringToBytes(message, filteredBytes, ivBytes2);
                    messageEncrypted = encrypted;

                    // Decrypt the bytes to a string. 
                    //string roundtrip = DecryptStringFromBytes(encrypted, myRijndael.Key, myRijndael.IV);

                    //Display the original data and the decrypted data.
                    //Console.WriteLine("Original:   {0}", message);
                    //Console.WriteLine("Round Trip: {0}", roundtrip);
                }
                return messageEncrypted;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }

            return new byte[2];
        }
        public static (byte[], byte[]) EncryptString(string message, string key)
        {
            try
            {


                byte[] messageEncrypted = null;
                byte[] finalIv = null;

                // Create a new instance of the RijndaelManaged 
                // class.  This generates a new key and initialization  
                // vector (IV). 
                using (Aes myRijndael = Aes.Create())
                {

                    myRijndael.GenerateIV();
                    myRijndael.GenerateKey();
                    // Encrypt the string to an array of bytes. 
                    byte[] keybytes = Encoding.Default.GetBytes(key);

                    byte[] filteredBytes = new byte[32];

                    int counter = 0;
                    foreach (byte item in keybytes)
                    {

                        if (counter == 32)
                        {
                            break;
                        }

                        filteredBytes[counter] = item;
                        counter++;
                    }
                    byte[] encrypted = EncryptStringToBytes(message, filteredBytes, myRijndael.IV);
                    messageEncrypted = encrypted;
                    finalIv = myRijndael.IV;

                    // Decrypt the bytes to a string. 
                    //string roundtrip = DecryptStringFromBytes(encrypted, myRijndael.Key, myRijndael.IV);

                    //Display the original data and the decrypted data.
                    //Console.WriteLine("Original:   {0}", message);
                    //Console.WriteLine("Round Trip: {0}", roundtrip);
                }
                return (messageEncrypted, finalIv);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }

            return (new byte[2], new byte[2]);
        }

        public static string DecryptString(byte[] message, byte[] key, byte[] iv)
        {
            return DecryptStringFromBytes(message, key, iv);

        }

        public static string DecryptString(byte[] message, string key, string IV)
        {

            byte[] ivBytes = Encoding.UTF8.GetBytes(IV);
            byte[] ivBytes2 = new byte[16];


            for (int i = 0; i < 16; i++)
            {

                if (ivBytes.Length > i && i < 16)
                {
                    ivBytes2[i] = ivBytes[i];
                }
                else
                {
                    ivBytes2[i] = 0;
                }
            }
            byte[] keybytes = Encoding.Default.GetBytes(key);
            byte[] filteredBytes = new byte[32];

            int counter = 0;
            foreach (byte item in keybytes)
            {

                if (counter == 32)
                {
                    break;
                }

                filteredBytes[counter] = item;
                counter++;
            }

            return DecryptStringFromBytes(message, filteredBytes, ivBytes2);
        }

        public static string DecryptString(byte[] message, string key, byte[] IV)
        {


            byte[] keybytes = Encoding.Default.GetBytes(key);
            byte[] filteredBytes = new byte[32];

            int counter = 0;
            foreach (byte item in keybytes)
            {

                if (counter == 32)
                {
                    break;
                }

                filteredBytes[counter] = item;
                counter++;
            }

            return DecryptStringFromBytes(message, filteredBytes, IV);
        }

        private static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments. 
            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException(nameof(plainText));
            }

            if (Key == null || Key.Length <= 0)
            {
                throw new ArgumentNullException(nameof(Key));
            }

            if (IV == null || IV.Length <= 0)
            {
                throw new ArgumentNullException(nameof(IV));
            }

            byte[] encrypted;
            // Create an RijndaelManaged object 
            // with the specified key and IV. 
            using (Aes myRijndael = Aes.Create())
            {
                myRijndael.Key = Key;
                myRijndael.IV = IV;
                // Create a decryptor to perform the stream transform.
                ICryptoTransform encryptor = myRijndael.CreateEncryptor(myRijndael.Key, myRijndael.IV);

                // Create the streams used for encryption. 
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
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

        private static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments. 
            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException(nameof(cipherText));
            }

            if (Key == null || Key.Length <= 0)
            {
                throw new ArgumentNullException(nameof(Key));
            }

            if (IV == null || IV.Length <= 0)
            {
                throw new ArgumentNullException(nameof(IV));
            }

            // Declare the string used to hold 
            // the decrypted text. 
            string plaintext = null;

            // Create an RijndaelManaged object 
            // with the specified key and IV. 
            using (Aes myRijndael = Aes.Create())
            {
                myRijndael.Key = Key;
                myRijndael.IV = IV;
                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = myRijndael.CreateDecryptor(myRijndael.Key, myRijndael.IV);

                // Create the streams used for decryption. 
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream 
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }

    }
}
