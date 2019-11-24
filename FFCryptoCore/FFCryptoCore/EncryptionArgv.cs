using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace FFCryptCore
{
    public class NoPasswordException : Exception
    {
        public NoPasswordException() : base("") { }
    }

    public class NoFilePathException : Exception
    {
        public NoFilePathException() : base("") { }
    }

    public class CreateDirectoryError : Exception
    {
        public CreateDirectoryError() : base("") { }
    }

    public class EncryptionArgv
    {

        public bool ShowHelp { get; private set; } = false;
        public bool IsEncryption { get; private set; } = true;
        public bool WaitForEnterKey { get; private set; } = false;
        public bool IsOriginalFile { get; private set; } = true;
        public bool NeedDeleteFile { get; private set; } = true;
        public bool NeedFillDeleteFile { get; private set; } = false;
        public bool NeedRenameRandomName { get; private set; } = false;
        public bool ForceWrite { get; private set; } = false;
        public bool NeedRestoreFilePath { get; private set; } = false;
        public bool IsAllFileSelected { get; private set; } = false;
        public bool NeedRestoreInfo { get; private set; } = true;
        public RijndaelManaged AesInfo { get; private set; } = new RijndaelManaged();
        public string PrivatePassword { get; private set; } = "";
        public byte[] PasswordHash { get; private set; } = new byte[] { };
        public byte[] PasswordHashSalt { get; private set; } = new byte[] { };
        public string[] PathList { get; private set; } = null;
        public string[] FolderPathList { get; private set; } = null;
        public string OutPath { get; private set; } = "";

        public int intSetCompressLevel { get; private set; } = 7;
        public Ionic.Zlib.CompressionLevel CompressLevel { get; private set; } = Ionic.Zlib.CompressionLevel.Default;

        public byte[] SaltData { get; private set; } = new byte[] { };

        public EncryptionFileInfo EncFileInfo { get; private set; } = new EncryptionFileInfo();

        private string pathListFile = "";
        private List<string> inPath = new List<string>();


        public void InitializeAesSalt()
        {
            Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(PrivatePassword, AesInfo.KeySize / 8);
            AesInfo.Key = deriveBytes.GetBytes(AesInfo.KeySize / 8);
            SaltData = deriveBytes.Salt;
            AesInfo.GenerateIV();
        }


        public void InitializePasswordHash()
        {
            // Hashed password
            Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(PrivatePassword, 32, 1000);

            HMACSHA256 hmac = new HMACSHA256(deriveBytes.GetBytes(256));
            PasswordHashSalt = deriveBytes.Salt;
            PasswordHash = hmac.ComputeHash(deriveBytes.Salt);
            hmac.Dispose();
            deriveBytes.Dispose();
        }


        public void SetFileInfo(EncryptionFileInfo fileInfo)
        {
            EncFileInfo = fileInfo;
        }


        public void SetEncryptionArgvValue(string[] argvList)
        {
            List<string> argv = new List<string>();
            foreach (string argvData in argvList)
                argv.Add(argvData.ToLower());

            // Default AES Mode
            AesInfo.KeySize = 256;
            AesInfo.BlockSize = 256;
            AesInfo.Mode = CipherMode.CBC;
            AesInfo.Padding = PaddingMode.PKCS7;

            // Analysis argv data
            for (int i = 0; i < argvList.Length; i++)
            {
                try
                {
                    // Genenal Settings
                    if (argv[i] == "-path") inPath.AddRange(argvList[++i].Split('|'));
                    else if (argv[i] == "-pass") PrivatePassword = argvList[++i];
                    else if (argv[i] == "-out") OutPath = argvList[++i];
                    else if (argv[i] == "-pathlist") pathListFile = argvList[++i];
                    else if (argv[i] == "-compress-level" | argv[i] == "-cl") intSetCompressLevel = int.Parse(argvList[++i]);
                    else if (argv[i] == "--enc" | argv[i] == "--e") IsEncryption = true;
                    else if (argv[i] == "--dec" | argv[i] == "--d") IsEncryption = false;
                    else if (argv[i] == "--wait-key" | argv[i] == "--wk") WaitForEnterKey = true;
                    else if (argv[i] == "--help" | argv[i] == "--h") ShowHelp = true;
                    else if (argv[i] == "--no-del-file" | argv[i] == "--ndf") NeedDeleteFile = false;
                    else if (argv[i] == "--fill-zero-del" | argv[i] == "--fzd") NeedFillDeleteFile = true;
                    else if (argv[i] == "--rand-name" | argv[i] == "--rn") NeedRenameRandomName = true;
                    else if (argv[i] == "--no-original" | argv[i] == "--no") IsOriginalFile = false;
                    else if (argv[i] == "--restore-path" | argv[i] == "--rp") NeedRestoreFilePath = true;
                    else if (argv[i] == "--no-restore-info" | argv[i] == "--nri") NeedRestoreInfo = false;
                    else if (argv[i] == "--force-write" | argv[i] == "--fw") ForceWrite = true;
                    else if (argv[i] == "--all-file-select" | argv[i] == "--afs") IsAllFileSelected = true;
                    else if (argv[i] == "--compress-folder" | argv[i] == "--cf") EncFileInfo.IsCompressedZipFile = true;

                    // Encryption Settings
                    else if (argv[i] == "--cbc") AesInfo.Mode = CipherMode.CBC;
                    else if (argv[i] == "--cfb") AesInfo.Mode = CipherMode.CFB;
                    else if (argv[i] == "--cts") AesInfo.Mode = CipherMode.CTS;
                    else if (argv[i] == "--ecb") AesInfo.Mode = CipherMode.ECB;
                    else if (argv[i] == "--ofb") AesInfo.Mode = CipherMode.OFB;
                    else if (argv[i] == "--k128") AesInfo.KeySize = 128;
                    else if (argv[i] == "--k192") AesInfo.KeySize = 192;
                    else if (argv[i] == "--k256") AesInfo.KeySize = 256;
                    else if (argv[i] == "--b128") AesInfo.BlockSize = 128;
                    else if (argv[i] == "--b192") AesInfo.BlockSize = 192;
                    else if (argv[i] == "--b256") AesInfo.BlockSize = 256;
                    else if (argv[i] == "--ansix923") AesInfo.Padding = PaddingMode.ANSIX923;
                    else if (argv[i] == "--iso10126") AesInfo.Padding = PaddingMode.ISO10126;
                    else if (argv[i] == "--pkcs7") AesInfo.Padding = PaddingMode.PKCS7;
                    else if (argv[i] == "--zeros") AesInfo.Padding = PaddingMode.Zeros;
                    else
                        Console.WriteLine("[-] Unknown command: " + argv[i]);
                }
                catch
                {
                    Console.WriteLine("[-] Please input '"+ argv[--i]+ "' parameter.");
                }
            }
            if (!IsEncryption)
                EncFileInfo.IsCompressedZipFile = false;

            // Add all file path
            if (File.Exists(pathListFile)) addPathList();
            if (IsEncryption | IsAllFileSelected)
                addFilePath();
            else
                addFilePath(".ffc");

            if (IsEncryption & !(IsAllFileSelected))
            {
                List<string> tmpPathList = new List<string>(PathList);
                tmpPathList.RemoveAll(s => s.Contains(".ffc"));
                PathList = tmpPathList.ToArray();
            }

            // Check output path
            if (OutPath != "")
            {
                if (!(Directory.Exists(OutPath)))
                {
                    try
                    {
                        Directory.CreateDirectory(OutPath);
                    }
                    catch { }
                    if (!(Directory.Exists(OutPath)))
                    {
                        OutPath = "";
                        if (!ForceWrite)
                            throw new CreateDirectoryError();
                    }
                }
            }

            if (intSetCompressLevel >= 0 & intSetCompressLevel <= 9)
                CompressLevel = (Ionic.Zlib.CompressionLevel)intSetCompressLevel;


            InitializePasswordHash();
            
            // Exceptions
            if (PathList.Length < 1 & FolderPathList.Length < 1) throw new NoFilePathException();
            if (PrivatePassword == "") throw new NoPasswordException();

            // Discope values
            inPath = null;
            pathListFile = "";

            GC.Collect();
        }

        private void addPathList()
        {
            using (StreamReader sr = new StreamReader(pathListFile))
            {
                while (sr.Peek() != -1)
                {
                    inPath.Add(sr.ReadLine());
                }
            }
        }

        private void addFilePath(string extension = "")
        {
            List<string> tmpFileList = new List<string>();
            List<string> tmpFolderList = new List<string>();
            foreach (string tmpPath in inPath)
            {
                string path = tmpPath;
                try
                {
                    if (Directory.Exists(path) & !tmpFolderList.Contains(path))
                    {
                        if (Directory.Exists(Directory.GetCurrentDirectory() +"\\"+ path))
                            path = Directory.GetCurrentDirectory() + "\\" + path;
                        if (!EncFileInfo.IsCompressedZipFile)
                        {
                            if (extension == "")
                                tmpFileList.AddRange(Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories));
                            else
                                tmpFileList.AddRange(Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories)
                                    .Where(s => s.EndsWith(extension, StringComparison.OrdinalIgnoreCase)).ToArray());
                        }
                        tmpFolderList.Add(path);
                    }
                    else if (File.Exists(path))
                    {
                        if (File.Exists(Directory.GetCurrentDirectory() + "\\" + path))
                            path = Directory.GetCurrentDirectory() + "\\" + path;
                        if (extension == "")
                            tmpFileList.Add(path);
                        else if (extension == Path.GetExtension(path))
                            tmpFileList.Add(path);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("[-] IO Error: "+ ex.Message);
                }
            }
            PathList = tmpFileList.Distinct().ToArray();
            FolderPathList = tmpFolderList.ToArray();
        }   
    }
}
