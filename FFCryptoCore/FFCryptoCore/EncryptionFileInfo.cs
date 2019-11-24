using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FFCryptCore
{
    public class EncryptionFileInfo
    {
        public bool IsCompressedZipFile { get; set; } = false;
        public bool IsAesMode { get; set; } = true;
        public byte[] MD5FileHash { get; set; } = new byte[16];
        public byte[] FileData = new byte[] { };

        public bool FileHidden { get; set; } = false;
        public bool FileArchive { get; set; } = false;
        public bool FileReadOnly { get; set; } = false;
        public bool FileSystem { get; set; } = false;
        public bool FileOffline { get; set; } = false;

        public bool FileNotContentIndexed { get; set; } = false;

        public string FilePath { get; set; } = "";
        public string FileDirectory { get; set; } = "";
        public string FileName { get; set; } = "";

        public string FileExtension { get; set; } = "";
        public string FileNameWithoutExtension { get; set; } = "";

        public DateTime CreationTime { get; set; } = new DateTime();
        public DateTime LastWriteTime { get; set; } = new DateTime();
        public DateTime LastAccessTime { get; set; } = new DateTime();

    }
}
