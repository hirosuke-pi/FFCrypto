using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FFCryptCore
{
    public class IOObject
    {
        public static void DeleteFile(string path, bool fillZero)
        {

            FileInfo file = new FileInfo(path);
            if ((file.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                file.Attributes = FileAttributes.Normal;
            }
            if (fillZero)
            {
                Console.Write("\r\n    - Info: Filling up 0x00 data... - ");
                using (FileStream fsd = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                {
                    byte[] dst = Enumerable.Repeat<byte>(0x00, (int)fsd.Length).ToArray();
                    fsd.Write(dst, 0, dst.Length);
                }
            }
            file.Delete();
        }

        public static string RenameFile(string filePath)
        {
            string filename = Path.GetFileNameWithoutExtension(filePath);
            string dirname = Path.GetDirectoryName(filePath);
            string extension = Path.GetExtension(filePath);
            string path = filePath;

            for (int i = 1; i < int.MaxValue; i++)
            {
                path = dirname + "\\" + filename + " (" + i.ToString() + ")" + extension;
                if (!File.Exists(path))
                    break;
            }
            return path;
        }

        public static string RenameFolder(string folderPath)
        {
            string path = folderPath;
            for (int i = 1; i < int.MaxValue; i++)
            {
                path = folderPath + " (" + i.ToString() + ")";
                if (!Directory.Exists(path))
                    break;
            }
            return path;
        }

        public static void DeleteFileEx(string path, bool fillZero, bool show = true)
        {

            FileInfo file = new FileInfo(path);
            if ((file.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                file.Attributes = FileAttributes.Normal;
            }
            if (fillZero)
            {
                if (show)
                    Console.Write("\r\n    - Info: Filling up 0x00 data... - ");
                using (FileStream fsd = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                {
                    byte[] dst = Enumerable.Repeat<byte>(0x00, (int)fsd.Length).ToArray();
                    fsd.Write(dst, 0, dst.Length);
                }
            }
            file.Delete();
        }

        public static void DeleteDirectory(string dir)
        {
            DirectoryInfo di = new DirectoryInfo(dir);
            RemoveReadonlyAttribute(di);
            di.Delete(true);
        }
        public static void RemoveReadonlyAttribute(DirectoryInfo dirInfo)
        {
            if ((dirInfo.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                dirInfo.Attributes = FileAttributes.Normal;
            foreach (FileInfo fi in dirInfo.GetFiles())
                if ((fi.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    fi.Attributes = FileAttributes.Normal;
            foreach (DirectoryInfo di in dirInfo.GetDirectories())
                RemoveReadonlyAttribute(di);
        }
    }
}
