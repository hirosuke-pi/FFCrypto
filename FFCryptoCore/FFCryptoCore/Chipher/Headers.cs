using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Collections;


namespace FFCryptCore
{
    public class Headers
    {
        /*  0 1 2 3 4 5 6 7 8 9 A B C D E F
         * +-------------------------------+
         * |MN     |H Size | Data Size     |
         * +-------------------------------+
         * | Password HMAC256              |
         * |                               |
         * +-------------------------------+
         * | Password Hash Salt            |
         * |                               |
         * +-------------------------------+
         * | Header Data                   |
         * ~              ~                ~
         * |                               |
         * +-------------------------------+
         * | Data                          |
         * ~              ~                ~
         * |                               |
         * +-------------------------------+
         * 
         */

        /*  Header Info (v1.00)
         *  1=Chipher-Mode, 2=AES-Mode,  3=BlockSize, 4=KeySize, 5=Padding, 6=Comp, 7,8,9,10,11,12,13=Reservation, 14,15,16=File-Info, 
         *  17~=File-Name|Date
         *  
         *  
         *  0 1 2 3 4 5 6 7 8 9 A B C D E F
         * +-------------------------------+
         * | Binary Headers                |
         * +-------------------------------+
         * | MD5 Hash                      |
         * +-------------------------------+
         * | String Headers                |
         * ~               ~               ~
         * |                               |
         * +-------------------------------+
         * 
         */

        public readonly byte[] MAGIC_NUMBER_AES = new byte[] { 0xff, 0xc8, 0x79, 0x00 };
        //public byte[] FileData = null;

        private List<byte> headerData = new List<byte>();
        private EncryptionArgv encArgv = null;


        public Headers(EncryptionArgv encArgvData)
        {
            // Build chipher information header
            encArgv = encArgvData;
            int[] tmpHeader = new int[] { };
            tmpHeader = new int[] {
                    1, (int)encArgv.AesInfo.Mode, encArgv.AesInfo.BlockSize - 1, encArgv.AesInfo.KeySize - 1,
                    (int)encArgv.AesInfo.Padding, Convert.ToInt32(encArgv.EncFileInfo.IsCompressedZipFile), 0, 0, 0, 0,
                };

            foreach (int data in tmpHeader)
                headerData.Add(Convert.ToByte(data));
            
        }

        public Headers()
        {
        }

        public byte[] MakeHeader(string path, ref byte[] rawData)
        {
            FileInfo fi = new FileInfo(path);
            List<byte> tmpHeaderData = new List<byte>(headerData);
            List<byte> returnHeader = new List<byte>();

            // Build file information header
            string tmpHeader = fi.FullName + "|" + fi.CreationTime.ToString() + "|" + fi.LastWriteTime.ToString() +
                "|" + fi.LastAccessTime.ToString();

            tmpHeaderData.Add(Convert.ToByte((fi.Attributes & FileAttributes.NotContentIndexed) == FileAttributes.NotContentIndexed));
            tmpHeaderData.Add(Convert.ToByte((fi.Attributes & FileAttributes.Offline) == FileAttributes.Offline));
            tmpHeaderData.Add(Convert.ToByte((fi.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly));
            tmpHeaderData.Add(Convert.ToByte((fi.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden));
            tmpHeaderData.Add(Convert.ToByte((fi.Attributes & FileAttributes.Archive) == FileAttributes.Archive));
            tmpHeaderData.Add(Convert.ToByte((fi.Attributes & FileAttributes.System) == FileAttributes.System));

            // Add MD5 Hash
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            tmpHeaderData.AddRange(md5.ComputeHash(rawData));
            rawData = null;

            // Add file informations
            tmpHeaderData.AddRange(Encoding.UTF8.GetBytes(tmpHeader));
            byte[] headerBytes = tmpHeaderData.ToArray();

            byte[] salt = null;
            RijndaelManaged tmpAes = MakeDefaultAesEx(encArgv.PrivatePassword, out salt);
            byte[] optimizedHeader = Chipher.Aes.EncryptData(ref headerBytes, salt, tmpAes, Ionic.Zlib.CompressionLevel.Level9);
            //headerBytes = null;

            RijndaelManaged tmpAes1 = MakeDefaultAes();
            
            encArgv.InitializePasswordHash();
            // Build headers
            returnHeader.AddRange(MAGIC_NUMBER_AES);
            returnHeader.AddRange(BitConverter.GetBytes(optimizedHeader.Length));
            returnHeader.AddRange(BitConverter.GetBytes(fi.Length));
            returnHeader.AddRange(encArgv.PasswordHash);
            returnHeader.AddRange(encArgv.PasswordHashSalt);
            returnHeader.AddRange(optimizedHeader);

            return returnHeader.ToArray();
        }

        public bool CheckFFCFile(ref byte[] rawData)
        {
            for (int i = 0; i < 4; i++)
            {
                if (!(rawData[i] == MAGIC_NUMBER_AES[i]))
                {
                    return false;
                }
            }
            return true;
        }


        public bool MakeEncArgv(ref byte[] rawData, ref EncryptionArgv encArgv)
        {
            // Get Header size and Data size
            EncryptionFileInfo efi = new EncryptionFileInfo();
            byte[] headerSizeBytes = new byte[4];
            byte[] dataSizeBytes = new byte[8];
            Buffer.BlockCopy(rawData, 4, headerSizeBytes, 0, 4);
            Buffer.BlockCopy(rawData, 8, dataSizeBytes, 0, 8);
            int headerSize = BitConverter.ToInt32(headerSizeBytes, 0);
            long dataSizeL = BitConverter.ToInt64(dataSizeBytes, 0);
            if (int.MaxValue < dataSizeL)
                return false;
            int dataSize = (int)dataSizeL;

            byte[] headerRawBytes = new byte[headerSize];
            efi.FileData = new byte[dataSize];
            Buffer.BlockCopy(rawData, 80, headerRawBytes, 0, headerRawBytes.Length);
            Buffer.BlockCopy(rawData, 80+headerRawBytes.Length, efi.FileData, 0, efi.FileData.Length);

            // Decrypt header data
            byte[] headerBytes = Chipher.Aes.DecryptData(ref headerRawBytes, encArgv.PrivatePassword, MakeDefaultAes());
            headerRawBytes = null;

            // Read binary header data
            efi.IsAesMode = BitConverter.ToBoolean(headerBytes, 0);
            if (efi.IsAesMode)
            {
                encArgv.AesInfo.Mode = (CipherMode)(int)headerBytes[1];
                encArgv.AesInfo.BlockSize = (int)headerBytes[2] + 1;
                encArgv.AesInfo.KeySize = (int)headerBytes[3] + 1;
                encArgv.AesInfo.Padding = (PaddingMode)(int)headerBytes[4];
            }
            efi.IsCompressedZipFile = BitConverter.ToBoolean(headerBytes, 5);

            efi.FileNotContentIndexed = BitConverter.ToBoolean(headerBytes, 10);
            efi.FileOffline = BitConverter.ToBoolean(headerBytes, 11);
            efi.FileReadOnly = BitConverter.ToBoolean(headerBytes, 12);
            efi.FileHidden = BitConverter.ToBoolean(headerBytes, 13);
            efi.FileArchive = BitConverter.ToBoolean(headerBytes, 14);
            efi.FileSystem = BitConverter.ToBoolean(headerBytes, 15);
            Buffer.BlockCopy(headerBytes, 16, efi.MD5FileHash, 0, efi.MD5FileHash.Length);

            // Read string header data
            byte[] strHeaderRaw = new byte[headerBytes.Length - 32];
            Buffer.BlockCopy(headerBytes, 32, strHeaderRaw, 0, strHeaderRaw.Length);
            string[] strHeader = Encoding.UTF8.GetString(strHeaderRaw).Split('|');

            efi.FilePath = strHeader[0];
            efi.FileName = Path.GetFileName(strHeader[0]);
            efi.FileExtension = Path.GetExtension(strHeader[0]);
            efi.FileNameWithoutExtension = Path.GetFileNameWithoutExtension(strHeader[0]);
            efi.FileDirectory = Path.GetDirectoryName(strHeader[0]);

            efi.CreationTime = DateTime.Parse(strHeader[1]);
            efi.LastWriteTime = DateTime.Parse(strHeader[2]);
            efi.LastAccessTime = DateTime.Parse(strHeader[3]);

            encArgv.SetFileInfo(efi);
            return true;
            
        }

        public RijndaelManaged MakeDefaultAes()
        {
            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = 256;
            aes.BlockSize = 256;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            return aes;
        }

        public RijndaelManaged MakeDefaultAesEx(string password, out byte[] salt)
        {
            RijndaelManaged aes = MakeDefaultAes();
            Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(password, aes.KeySize / 8, 1000);
            aes.Key = deriveBytes.GetBytes(aes.KeySize / 8);
            salt = deriveBytes.Salt;
            aes.GenerateIV();
            return aes;
        }


        public bool MatchPassword(string password, byte[] rawData)
        {
            byte[] passHash = new byte[32];
            byte[] passSalt = new byte[32];

            Buffer.BlockCopy(rawData, 16, passHash, 0, 32);
            Buffer.BlockCopy(rawData, 48, passSalt, 0, 32);

            // Hashed password
            Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(password, passSalt);

            HMACSHA256 hmac = new HMACSHA256(deriveBytes.GetBytes(256));
            byte[] tmpPassHash = hmac.ComputeHash(deriveBytes.Salt);
            hmac.Dispose();
            deriveBytes.Dispose();

            return (((IStructuralEquatable)tmpPassHash).Equals(passHash, StructuralComparisons.StructuralEqualityComparer));
        }

        public static EncryptionArgv ReadHeaderAndMakeEncryptionArgv(string path, EncryptionArgv encArgv)
        {
            return encArgv;
        }
    }
}
