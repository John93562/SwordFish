using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Swordfish.Cryptography
{
    public static class SwordFishCryptography
    {

        public static string EncryptZip(string filePath, string key)
        {
            string outputPath = "";

            int counter = 0;
            do
            {

                try
                {
                    counter++;
                    if (counter == 100)
                    {
                        break;
                    }

                    Task.Delay(10);
                    FileInfo file = new FileInfo(filePath);
                    FileEncrypt(filePath, key, ".bac");
                    outputPath = filePath + ".bac";
                    break;
                }
                catch (Exception)
                {

                }


            } while (true);

            return outputPath;
        }

        public static string DecryptZip(string filePath, string key, string outputPath)
        {
            string outputPathFinal = "";


            int counter = 0;
            do
            {

                try
                {
                    counter++;
                    if (counter == 100)
                    {
                        break;
                    }

                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    FileInfo file = new FileInfo(filePath);
                    if (file.Extension == ".bac")
                    {
                        outputPathFinal = outputPath + "//" + file.Name.Replace(".bac", "");

                        FileDecrypt(filePath, outputPathFinal, key, false);

                    }
                    break;
                }
                catch (Exception)
                {

                }


            } while (true);

            return outputPathFinal;


        }

        public static void DecryptFolderUpdated(string folderPath, string key, string rootPath)
        {
            string BackupName = $"temp";
            string FullBackupName = rootPath + "\\" + BackupName + ".zip.bac";
            if (!File.Exists(FullBackupName))
            {
                return;
            }

            string temptempZip = rootPath;

            DecryptZip(FullBackupName, key, temptempZip);

            try
            {
                if (Directory.Exists(folderPath))
                {
                    Directory.Delete(folderPath, true);
                }

                Directory.CreateDirectory(folderPath);

                ZipFile.ExtractToDirectory(temptempZip + "\\" + BackupName + ".zip", folderPath, true);
                if (File.Exists(FullBackupName))
                {

                    File.Move(FullBackupName, FullBackupName + "backupforbadtimes", true);
                }

                if (File.Exists(temptempZip + "\\" + BackupName + ".zip"))
                {
                    File.Delete(temptempZip + "\\" + BackupName + ".zip");
                }
            }
            catch (Exception)
            {


            }

        }
        public static async Task EncryptFoldersUpdated(string folderPath, string key, string backupTempFolder, string rootFolder)
        {
            string BackupName = $"temp";
            string FullBackupName = rootFolder + "/" + BackupName + ".zip";


            Directory.CreateDirectory(backupTempFolder);

            List<string> files = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories).ToList();

            for (int i = 0; i < files.Count; i++)
            {
                int counter = 0;
                do
                {

                    try
                    {
                        counter++;
                        if (counter == 100)
                        {
                            break;
                        }

                        await Task.Delay(10);
                        FileInfo file = new FileInfo(files[i]);

                        FileInfo currentDirectory = new FileInfo(rootFolder);



                        string replaceFileName = file.FullName.Replace(currentDirectory.FullName, backupTempFolder)
                            .Replace("\\assets\\", "");
                        string replaceFileDirectory = replaceFileName.Replace(file.Name, "");
                        Directory.CreateDirectory(replaceFileDirectory);

                        File.Copy(files[i], replaceFileName, true);
                        break;
                    }
                    catch (Exception)
                    {

                    }


                } while (true);



            }


            if (File.Exists(FullBackupName))
            {
                File.Delete(FullBackupName);
            }

            ZipFile.CreateFromDirectory(backupTempFolder, FullBackupName);

            string outputPath = EncryptZip(FullBackupName, key);


            try
            {
                if (Directory.Exists(folderPath))
                {
                    Directory.Delete(folderPath, true);
                }

                if (Directory.Exists(backupTempFolder))
                {
                    Directory.Delete(backupTempFolder, true);
                }
            }
            catch (Exception)
            {


            }


        }




        //  Call this function to remove the key from memory after use for security
        [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);

        /// <summary>
        /// Creates a random salt that will be used to encrypt your file. This method is required on FileEncrypt.
        /// </summary>
        /// <returns></returns>
        public static byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[32];

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                for (int i = 0; i < 10; i++)
                {
                    // Fille the buffer with the generated data
                    rng.GetBytes(data);
                }
            }

            return data;
        }

        /// <summary>
        /// Encrypts a file from its path and a plain password.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="password"></param>
        private static void FileEncrypt(string inputFile, string password, string extension = ".enc", bool deleteAfterEncrypt = true)
        {
            //http://stackoverflow.com/questions/27645527/aes-encryption-on-large-files
            GC.Collect();   // yes, really release the db
            GC.WaitForPendingFinalizers();

            File.Copy(inputFile, inputFile + ".copy", true);
            //generate random salt
            byte[] salt = GenerateRandomSalt();

            //create output file name
            FileStream fsCrypt = new FileStream(inputFile + extension, FileMode.Create);

            //convert password string to byte arrray
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

            //Set Rijndael symmetric encryption algorithm
            Aes AES = Aes.Create();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            AES.Padding = PaddingMode.PKCS7;


            //http://stackoverflow.com/questions/2659214/why-do-i-need-to-use-the-rfc2898derivebytes-class-in-net-instead-of-directly
            //"What it does is repeatedly hash the user password along with the salt." High iteration counts.
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            //Cipher modes: http://security.stackexchange.com/questions/52665/which-is-the-best-cipher-mode-and-padding-mode-for-aes-encryption
            AES.Mode = CipherMode.CFB;

            // write salt to the begining of the output file, so in this case can be random every time
            fsCrypt.Write(salt, 0, salt.Length);

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(inputFile + ".copy", FileMode.Open);

            //create a buffer (1mb) so only this amount will allocate in the memory and not the whole file
            byte[] buffer = new byte[1048576];
            int read;


            while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
            {
                cs.Write(buffer, 0, read);
            }

            // Close up
            fsIn.Close();


            cs.Close();
            fsCrypt.Close();
            AES.Dispose();
            key.Dispose();
            GC.Collect();   // yes, really release the db
            GC.WaitForPendingFinalizers();

            File.Delete(inputFile + ".copy");
            if (deleteAfterEncrypt)
                File.Delete(inputFile);

        }

        public static void EncryptFile(string fullPath12, string extension, string password)
        {
            FileEncrypt(fullPath12, password, extension);
        }

        public static string DecryptFile(string fullPath12, string fullPathButPhotoPathNameFull, string password, bool deleteAfterDecrypt = false)
        {
            return FileDecrypt(fullPath12, fullPathButPhotoPathNameFull, password, deleteAfterDecrypt);
        }


        /// <summary>
        /// Decrypts an encrypted file with the FileEncrypt method through its path and the plain password.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        /// <param name="password"></param>
        private static string FileDecrypt(string inputFile, string outputFile, string password, bool deleteAfterDecrypt = true)
        {
            File.Copy(inputFile, inputFile + ".backupdec", true);

            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            byte[] salt = new byte[32];

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
            fsCrypt.Read(salt, 0, salt.Length);

            Aes AES = Aes.Create();

            AES.KeySize = 256;
            AES.BlockSize = 128;

            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CFB;

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

            int read;
            byte[] buffer = new byte[1048576];

            try
            {
                while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fsOut.Write(buffer, 0, read);
                }
            }
            catch (CryptographicException ex_CryptographicException)
            {
                Console.WriteLine("CryptographicException error: " + ex_CryptographicException.Message);
                File.Move(inputFile + ".backupdec", inputFile, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                cs.Close();
                if (deleteAfterDecrypt)
                {

                    File.Delete(inputFile);

                }

                if (File.Exists(inputFile + ".backupdec"))
                {
                    File.Delete(inputFile + ".backupdec");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error by closing CryptoStream: " + ex.Message);
                File.Move(inputFile + ".backupdec", inputFile, true);
            }
            finally
            {
                fsOut.Close();
                fsCrypt.Close();
                cs.Dispose();
                key.Dispose();
                AES.Dispose();

            }
            return outputFile;

        }

    }
}
