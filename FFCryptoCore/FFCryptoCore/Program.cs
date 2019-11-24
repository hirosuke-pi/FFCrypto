using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;


namespace FFCryptCore
{
    class Program
    {
        private static string version = "v1.00";
        private static bool cancelFlag = false;
        private static bool taskExited = false;

        public enum CtrlTypes
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);
        private delegate bool HandlerRoutine(CtrlTypes CtrlType);
        private static HandlerRoutine myHandlerDele;

        private static void Main(string[] args)
        {
            // Exit task
            myHandlerDele = new HandlerRoutine(exitTaskFunc);
            SetConsoleCtrlHandler(myHandlerDele, true);

            Console.Title = "FFCrypt Core "+ version;
            Console.WriteLine("\r\n[*] [FFCrypt Core "+ version +"]");
            EncryptionArgv encArgv = new EncryptionArgv();
            long times = 0;

            try
            {
                Console.WriteLine("[*] Analysing arguments...\r\n");
                encArgv.SetEncryptionArgvValue(args);
                showArgvInfo(encArgv);

                if (encArgv.ShowHelp)
                    showHelpInfo();
                else if (encArgv.IsEncryption)
                {
                    Console.Title = Console.Title + " - Encrypting...";
                    times = startEncryption(encArgv);
                }
                else
                {
                    Console.Title = Console.Title + " - Decrypting...";
                    times = startDecryption(encArgv);
                }
                GC.Collect();
            }
            catch (NoFilePathException)
            {      
                Console.WriteLine("\r\n[-] Please select the file(s).");
                showHelpInfo();
            }
            catch (NoPasswordException)
            {                
                Console.WriteLine("\r\n[-] Please set the password.");
                showHelpInfo();
            }
            catch (CreateDirectoryError)
            {
                Console.WriteLine("\r\n[-] Could not create directory: '"+ encArgv.OutPath +"' ");
                showHelpInfo();
            }
            if (encArgv.IsEncryption)
                Console.WriteLine("\r\n[*] Completed encryption. ("+ times +"ms)");
            else
                Console.WriteLine("\r\n[*] Completed decryption. ("+ times +"ms)");
            taskExited = true;

            Console.Title = "FFCrypt Core " + version;
            if (encArgv.WaitForEnterKey)
            {
                Console.WriteLine("[*] Press Enter to exit this program...");
                Console.ReadLine();
            }
        }


        private static void showHelpInfo()
        {
            
            Console.WriteLine("\r\n" +
                " ["+ Console.Title +"]\r\n\r\n" +
                "  Genenal Settings\r\n" +
                " ==================\r\n" +
                "   * Mode: --enc(--e), --dec(--d)\r\n" +
                "   -path [USING_FILE_PATH]|[ANOTHER_PATH]..., -pass [ENCRYPTION_PASSWORD]\r\n" +
                "   (-out [OUT_FOLDER_PATH]), (-pathlist [USING_PATH_LIST_FILE]),\r\n" +
                "   (-compress-level(-cl) [COMPRESS_LEVEL(0..9)(Default=7)]])\r\n" +
                "   --wait-key(--wk), --help(--h), --no-del-file(--ndf), \r\n" +
                "   --fill-zero-del(--fzd), --rand-name(--rn), --no-original(--no),\r\n" +
                "   --all-file-select (--afs), --no-restore-info(--nri),\r\n" +
                "   --restore-path(--rp), --force-write(--fw), --compress-folder(--cf)\r\n" +
                "\r\n" +
                "  Encryption Settings ((*) = Default)\r\n" +
                " =====================================\r\n" +
                "   * AES Mode : --cbc(*), --cfb, --cts, --ecb, --ofb\r\n" +
                "   * KeySize  : --k128(AES), --k192(AES), --k256(AES)(*)\r\n" +
                "   * BlockSize: --b128(AES)(*), --b192, --b256\r\n" +
                "   * Padding  : --ansix923,  --iso10126, --pkcs7(*)\r\n" +
                "\r\n" +
                " ex) ffc.exe -path C:\\Users\\User\\Documents\\Image.png -pass 1234abc\r\n"+
                "     ffc.exe -path C:\\Users\\User\\Documents\\Image.ffc -pass 1234abc --dec\r\n");
        }


        private static long startEncryption(EncryptionArgv encArgv)
        {
            bool isFolderCompress = encArgv.EncFileInfo.IsCompressedZipFile;
            encArgv.EncFileInfo.IsCompressedZipFile = false;
            Headers headerObj = new Headers(encArgv);
            byte[] rawData = null;
            
            var swAll = new System.Diagnostics.Stopwatch();
            encArgv.InitializeAesSalt();

            Console.WriteLine("\r\n[*] Starting file encryption...");
            int count = 0;
            int maxCount = encArgv.PathList.Length;
            if (isFolderCompress)
                maxCount += +encArgv.FolderPathList.Length;
            swAll.Reset();
            swAll.Start();
            // File List
            foreach (string pathData in encArgv.PathList)
            {
                if (cancelFlag)
                {
                    Console.WriteLine("\r\n\r\n[!] Encryption is canceled.");
                    break;
                }
                count++;

                try
                {
                    rawData = readAllFile(pathData);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\r\n    - Failed: " + ex.Message);
                    continue;
                }

                encryptionData(ref rawData, pathData, count, maxCount, encArgv, headerObj);

            }

            encArgv.EncFileInfo.IsCompressedZipFile = isFolderCompress;
            // FolderList
            if (!cancelFlag & encArgv.EncFileInfo.IsCompressedZipFile)
            {
                headerObj = new Headers(encArgv);
                foreach (string pathData in encArgv.FolderPathList)
                {
                    try
                    {
                        if (cancelFlag)
                        {
                            Console.WriteLine("\r\n\r\n[!] Encryption is canceled.");
                            break;
                        }

                        count++;
                        string path = pathData;
                        Console.Write("  + Compressing Folder: " + path + " - ");
                        string zipPath = "";
                        rawData = makeAndReadZipData(pathData, out zipPath, encArgv);
                        Console.WriteLine("(Done.)");
                        path = zipPath;

                        bool success = encryptionData(ref rawData, path, count, maxCount, encArgv, headerObj);
                        if (encArgv.NeedDeleteFile & success)
                        {
                            try
                            {
                                if (encArgv.NeedFillDeleteFile)
                                {
                                    Console.Write("    - Info: Filling up 0x00 data in folder... - ");
                                    foreach (string filePath in Directory.EnumerateFiles(pathData, "*", SearchOption.AllDirectories))
                                        IOObject.DeleteFileEx(filePath, encArgv.NeedFillDeleteFile, false);
                                    Console.WriteLine("(Done.)");
                                }
                                IOObject.DeleteDirectory(pathData);
                            } catch (Exception ex)
                            {
                                Console.WriteLine("\r\n    - Failed: " + ex.Message +"\r\n");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\r\n    - Failed: " + ex.Message);
                    }
                }
            }
            swAll.Stop();
            return swAll.ElapsedMilliseconds;
        }

        private static bool encryptionData(ref byte[] rawData, string path, int count, int maxCount, EncryptionArgv encArgv, Headers headerObj)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            byte[] headerData = new byte[] { };

            Console.Write("  + Enc(" + count.ToString() + "/" + maxCount.ToString() + "): " + path + " - ");
            sw.Reset();
            sw.Start();

            if (encArgv.IsOriginalFile)
            {
                headerData = headerObj.MakeHeader(path, ref rawData);
            }

            encArgv.InitializeAesSalt();
            bool success = Chipher.Aes.EncryptFile(path, encArgv, headerData, ref rawData);


            sw.Stop();
            if (success)
                Console.WriteLine("(Done: " + sw.ElapsedMilliseconds.ToString() + "ms)");
            return success;
        }


        private static long startDecryption(EncryptionArgv encArgv)
        {
            var sw = new System.Diagnostics.Stopwatch();
            var swAll = new System.Diagnostics.Stopwatch();
            Console.WriteLine("\r\n[*] Starting file decryption...");
            int count = 0;

            swAll.Reset();
            swAll.Start();
            foreach (string path in encArgv.PathList)
            {
                if (cancelFlag)
                {
                    Console.WriteLine("[!] Decryption is canceled.");
                    break;
                }

                count++;
                bool success = false;
                Console.Write("  + Dec(" + count.ToString() + "/" + encArgv.PathList.Length.ToString() + "): " + path + " - ");
                sw.Reset();
                sw.Start();
                success = Chipher.Aes.DecryptFile(path, encArgv);
                sw.Stop();
                if (success)
                    Console.WriteLine("(Done: " + sw.ElapsedMilliseconds.ToString() + "ms)");
            }

            swAll.Stop();
            return swAll.ElapsedMilliseconds;
        }

        private static string[] getArgvStringInfo(EncryptionArgv encArgv)
        {
            List<string> info = new List<string>() { };
            info.Add("AES Mode");
            info.Add(encArgv.IsOriginalFile.ToString());
            info.Add(encArgv.IsAllFileSelected.ToString());
            info.Add(encArgv.ForceWrite.ToString());
            info.Add(encArgv.intSetCompressLevel.ToString());
            if (encArgv.OutPath == "")
                info.Add("Any directory...");
            else
                info.Add(encArgv.OutPath);
            info.Add(encArgv.PathList.Length.ToString());
            info.Add(encArgv.FolderPathList.Length.ToString());
            info.Add(Chipher.Hash.GetSHA256HashString(encArgv.PrivatePassword));
            info.Add(encArgv.AesInfo.Mode.ToString());
            info.Add(encArgv.AesInfo.Padding.ToString());
            info.Add(encArgv.AesInfo.KeySize.ToString());
            info.Add(encArgv.AesInfo.BlockSize.ToString());
            
            return info.ToArray();
        }

        private static void showArgvInfo(EncryptionArgv encArgv)
        {
            if (encArgv.IsEncryption)
                Console.WriteLine("\r\n[*] Encryption setting informations:");
            else
                Console.WriteLine("\r\n[*] Decryption setting informations:");

            string[] info = getArgvStringInfo(encArgv);

            Console.WriteLine("  + Chipher Mode : " + info[0]);
            Console.WriteLine("  + Original File: " + info[1]);
            Console.WriteLine("  + All Files    : " + info[2]);
            Console.WriteLine("  + Force Write  : " + info[3]);
            Console.WriteLine("  + Compress     : " + info[4]);
            Console.WriteLine("  + Output Path  : " + info[5]);
            Console.WriteLine("  + File Lists   : " + info[6] +" file(s)");
            Console.WriteLine("  + Folder Lists : " + info[7] + " folder(s)");
            Console.WriteLine("  + Password Hash: " + info[8]);
            Console.WriteLine("  + AES Mode     : " + info[9]);
            Console.WriteLine("  + AES Padding  : " + info[10]);
            Console.WriteLine("  + AES Key Size : " + info[11] +" bits");
            Console.WriteLine("  + AES BlockSize: " + info[12] +" bits");
            
        }

        private static byte[] readAllFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] rawData = new byte[fs.Length];
            fs.Read(rawData, 0, (int)fs.Length);
            fs.Close();
            fs.Dispose();

            return rawData;
        }

        private static byte[] makeAndReadZipData(string folderPath, out string zipPath, EncryptionArgv encArgv)
        {
            zipPath = folderPath + ".zip";
            if (File.Exists(zipPath))
                zipPath = IOObject.RenameFolder(zipPath);
            using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile(zipPath, Encoding.UTF8))
            {
                zip.CompressionLevel = encArgv.CompressLevel;
                zip.AddDirectory(folderPath, "");
                zip.Comment = Path.GetFileName(folderPath);
                zip.Save();
            }
            return readAllFile(zipPath);
        }

        private static bool exitTaskFunc(CtrlTypes ctrlTypes)
        {
            cancelFlag = true;
            Console.Write("\r\n\r\n[!] Exit code '"+ ctrlTypes.ToString() +"' detected. Please wait... ");
            while (true)
            {
                if (taskExited)
                    break;
                Thread.Sleep(1000);
            }

            return true;
        }
    }
}
