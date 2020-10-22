using System;
using System.IO;

namespace AlertToCareTest
{
    public class TestUtilities
    {
        public static string FileNameConfig()
        {
            string path = new DirectoryInfo // current directory
                           (Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
            string fileName = string.Concat(path, "AlertToCare.db");
            return fileName;
        }
    }
}
