using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Collections;
using FFCryptCore;


namespace FFCryptCore.Chipher
{
    public class Aes
    {
        public static bool EncryptFile(string path, EncryptionArgv encArgv, byte[] headerData, ref byte[] rawData)
        {
            try
            {
                if (rawData == null)
                {
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    rawData = new byte[fs.Length];
                    fs.Read(rawData, 0, (int)fs.Length);
                    fs.Close();
                    fs.Dispose();
                }

                string directoryPath = Path.GetDirectoryName(path);
                if (encArgv.OutPath != "")
                    directoryPath = encArgv.OutPath;

                byte[] encryptedBin = null;
                encryptedBin = EncryptData(ref rawData, encArgv.SaltData, encArgv.AesInfo, encArgv.CompressLevel);
                rawData = null;

                if (encArgv.IsOriginalFile)
                {
                    byte[] encbinLen = BitConverter.GetBytes(encryptedBin.Length);
                    byte[] encryptedFile = new byte[headerData.Length + encryptedBin.Length];
                    Buffer.BlockCopy(headerData, 0, encryptedFile, 0, headerData.Length);
                    Buffer.BlockCopy(encryptedBin, 0, encryptedFile, headerData.Length, encryptedBin.Length);
                    Buffer.BlockCopy(encbinLen, 0, encryptedFile, 8, encbinLen.Length);
                    headerData = null;
                    encryptedBin = null;

                    string filePath = "";
                    if (encArgv.NeedRenameRandomName)
                        filePath = directoryPath + "\\" + Hash.RandamString(32) +".ffc";
                    else
                        filePath = directoryPath + "\\" + Path.GetFileNameWithoutExtension(path) + ".ffc";

                    // Check file exists
                    if (encArgv.ForceWrite & File.Exists(filePath))
                    {
                        Console.Write("\r\n    - Warning: File Exists. Forced writing data... - ");
                        FileInfo file = new FileInfo(filePath);
                        if ((file.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                        {
                            file.Attributes = FileAttributes.Normal;
                        }
                    }
                    else if (File.Exists(filePath))
                    {
                        filePath = IOObject.RenameFile(filePath);
                        Console.Write("\r\n    - Warning: File Exists. Renamed file: " + Path.GetFileName(filePath) + " - ");
                    }

                    // Write data
                    using (FileStream fsb = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        fsb.Write(encryptedFile, 0, encryptedFile.Length);
                    }
                    encryptedFile = null;
                }
                else
                {
                    string filePath = "";
                    if (encArgv.NeedRenameRandomName)
                        filePath = directoryPath + "\\" + Hash.RandamString(32) + Path.GetExtension(path) +".ffc";
                    else
                        filePath = path + ".ffc";

                    // Check file exists
                    if (encArgv.ForceWrite & File.Exists(filePath))
                    {
                        Console.Write("\r\n    - Warning: File Exists. Forced writing data... - ");
                        FileInfo file = new FileInfo(filePath);
                        if ((file.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                        {
                            file.Attributes = FileAttributes.Normal;
                        }
                    }
                    else if (File.Exists(filePath))
                    {
                        filePath = IOObject.RenameFile(filePath);
                        Console.Write("\r\n    - Warning: File Exists. Renamed file: "+ Path.GetFileName(filePath) +" - ");
                    }

                    // Write data
                    using (FileStream fsb = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        fsb.Write(encryptedBin, 0, encryptedBin.Length);
                    }
                    encryptedBin = null;
                }

                if (encArgv.NeedDeleteFile)
                    IOObject.DeleteFileEx(path, encArgv.NeedFillDeleteFile);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\r\n    - Failed: "+ ex.Message);
                return false;
            }
        }


        public static byte[] EncryptData(ref byte[] data, byte[] salt, RijndaelManaged aes, Ionic.Zlib.CompressionLevel level)
        {
            using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            using (MemoryStream outms = new MemoryStream())
            using (CryptoStream cse = new CryptoStream(outms, encryptor, CryptoStreamMode.Write))
            {
                // Write salt and IV data.
                outms.Write(salt, 0, salt.Length);
                outms.Write(aes.IV, 0, aes.IV.Length);

                using (DeflateStream ds = new DeflateStream(cse, CompressionMode.Compress, false))
                //using (Ionic.Zlib.DeflateStream ds = new Ionic.Zlib.DeflateStream(cse, Ionic.Zlib.CompressionMode.Compress, level))
                {
                    ds.Write(data, 0, data.Length);
                }
                
                return outms.ToArray();
            }

        }


        public static bool DecryptFile(string path, EncryptionArgv encArgv)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                byte[] rawData = new byte[fs.Length];
                fs.Read(rawData, 0, (int)fs.Length);
                fs.Close();
                fs.Dispose();

                Headers header = new Headers();
                byte[] decryptedData = null;
                byte[] MD5Hash = null;
                bool ffcFile = false;
                string fileName = Path.GetFileNameWithoutExtension(path);
                string directoryName = Path.GetDirectoryName(path);
                if (encArgv.OutPath != "")
                    directoryName = encArgv.OutPath;

                // Check header
                if (header.CheckFFCFile(ref rawData))
                {
                    if (!(header.MatchPassword(encArgv.PrivatePassword, rawData)))
                    {
                        Console.WriteLine("\r\n    - Failed: Password do not match");
                        return false;
                    }

                    if (!(header.MakeEncArgv(ref rawData, ref encArgv)))
                    {
                        Console.WriteLine("\r\n    - Failed: converting headers");
                        return false;
                    }

                    ffcFile = true;
                    if (encArgv.NeedRestoreFilePath)
                    {
                        try
                        {
                            Directory.CreateDirectory(encArgv.EncFileInfo.FileDirectory);
                        }
                        catch { }

                        if (Directory.Exists(encArgv.EncFileInfo.FileDirectory))
                            directoryName = encArgv.EncFileInfo.FileDirectory;
                        else
                            Console.Write("\r\n    - Warning: Could not create directory: '"+ encArgv.EncFileInfo.FileDirectory + "' - ");
                    }

                    if (encArgv.NeedRestoreInfo)
                        fileName = encArgv.EncFileInfo.FileName;
                    else
                        fileName = fileName + encArgv.EncFileInfo.FileExtension;

                    decryptedData = DecryptData(ref encArgv.EncFileInfo.FileData, encArgv.PrivatePassword, encArgv.AesInfo);

                    rawData = null;
                    header = null;

                    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                    MD5Hash = md5.ComputeHash(decryptedData);
                    md5.Dispose();
                    md5 = null;

                    if (!((IStructuralEquatable)MD5Hash).Equals(encArgv.EncFileInfo.MD5FileHash, StructuralComparisons.StructuralEqualityComparer))
                    {
                        Console.WriteLine("\r\n    - Failed: Data do not match");
                        return false;
                    }

                }
                else
                {
                    ffcFile = false;
                    header = null;
                    decryptedData = DecryptData(ref rawData, encArgv.PrivatePassword, encArgv.AesInfo);
                    rawData = null;
                }

                string createPath = directoryName + "\\" + fileName;

                // Write decrypted data
                if (encArgv.ForceWrite & File.Exists(createPath))
                {
                    Console.Write("\r\n    - Warning: File Exists. Forced writing data... - ");
                    FileInfo file = new FileInfo(createPath);
                    if ((file.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        file.Attributes = FileAttributes.Normal;
                    }
                }
                // Check file exists
                else if (File.Exists(createPath))
                {
                    createPath = IOObject.RenameFile(createPath);
                    Console.Write("\r\n    - Warning: File Exists. Renamed file: " + Path.GetFileName(createPath) + " - ");
                }

                using (FileStream fsb = new FileStream(createPath, FileMode.Create, FileAccess.Write))
                {
                    fsb.Write(decryptedData, 0, decryptedData.Length);
                }
                decryptedData = null;

                // Compressed Zip
                if (encArgv.EncFileInfo.IsCompressedZipFile)
                {
                    string folderPath = "";
                    using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile(createPath, Encoding.UTF8))
                    {
                        folderPath = Path.GetDirectoryName(createPath) + "\\" + zip.Comment;
                        Directory.CreateDirectory(folderPath);
                        if (encArgv.ForceWrite)
                        {
                            zip.ExtractAll(folderPath, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
                        }
                        else
                        {
                            try
                            {
                                zip.ExtractAll(folderPath, Ionic.Zip.ExtractExistingFileAction.Throw);
                            }
                            catch
                            {
                                folderPath = IOObject.RenameFolder(folderPath);
                                zip.ExtractAll(folderPath, Ionic.Zip.ExtractExistingFileAction.OverwriteSilently);
                            }
                        }
                    }
                    File.Delete(createPath);
                }

                // Add file attributes
                if (ffcFile & encArgv.IsOriginalFile & encArgv.NeedRestoreInfo & !encArgv.EncFileInfo.IsCompressedZipFile)
                {
                    FileInfo fi = new FileInfo(createPath);
                    fi.CreationTime = encArgv.EncFileInfo.CreationTime;
                    fi.LastWriteTime = encArgv.EncFileInfo.LastWriteTime;
                    fi.LastAccessTime = encArgv.EncFileInfo.LastAccessTime;
                    if (encArgv.EncFileInfo.FileNotContentIndexed) fi.Attributes |= FileAttributes.NotContentIndexed;
                    if (encArgv.EncFileInfo.FileOffline) fi.Attributes |= FileAttributes.Offline;
                    if (encArgv.EncFileInfo.FileArchive) fi.Attributes |= FileAttributes.Archive;
                    if (encArgv.EncFileInfo.FileHidden) fi.Attributes |= FileAttributes.Hidden;
                    if (encArgv.EncFileInfo.FileSystem) fi.Attributes |= FileAttributes.System;
                    if (encArgv.EncFileInfo.FileReadOnly) fi.Attributes |= FileAttributes.ReadOnly;
                    fi = null;
                }

                // Delete file
                if (encArgv.NeedDeleteFile)
                    IOObject.DeleteFileEx(path, encArgv.NeedFillDeleteFile);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\r\n    - Failed: "+ ex.Message);
                return false;
            }
        }

        public static byte[] DecryptData(ref byte[] data, string password, RijndaelManaged aes)
        {
            int len = 0;
            byte[] buffer = new byte[aes.BlockSize / 8];
            byte[] salt = new byte[aes.KeySize / 8];
            byte[] iv = new byte[aes.BlockSize / 8];
            byte[] decryptedData;

            using (MemoryStream inms = new MemoryStream(data))
            {
                inms.Read(salt, 0, salt.Length);
                inms.Read(iv, 0, iv.Length);
                aes.IV = iv;

                Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(password, salt, 1000);
                aes.Key = deriveBytes.GetBytes(salt.Length);

                //Decryption interface.
                using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                using (CryptoStream cse = new CryptoStream(inms, decryptor, CryptoStreamMode.Read))
                using (MemoryStream outms = new MemoryStream())
                {
                    //using (DeflateStream ds = new DeflateStream(cse, CompressionMode.Decompress, false))
                    using (Ionic.Zlib.DeflateStream ds = new Ionic.Zlib.DeflateStream(cse, Ionic.Zlib.CompressionMode.Decompress))
                    {
                        while ((len = ds.Read(buffer, 0, buffer.Length)) > 0)
                            outms.Write(buffer, 0, len);
                    }
                    
                    decryptedData = outms.ToArray();
                }

                return decryptedData;
            }
        }
    }
}
