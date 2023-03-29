using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ManageStudent.Helper
{
    internal static class FileHelper
    {
        public static void SaveFile(List<string> text, string path)
        {
            File.WriteAllLines(path, text);
        }

        public static void SaveFile(string text, string path)
        {
            List<string> myLines = new List<string>() { text };
            File.WriteAllLines(path, myLines);
        }

        public static string ReadFile(string path)
        {
            if (!File.Exists(path))
                return null;

            //return File.ReadAllLines(path);
            using (var streamReader = File.OpenText(path))
            {
                var lines = streamReader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                //convert string[] to string
                //string builder faster string
                var result = new StringBuilder();
                foreach (var item in lines)
                {
                    result.Append(item);
                }

                return result.ToString();
            }
        }

        public static string[] ReadFileReturnArrayString(string path)
        {
            if (!File.Exists(path))
                return null;
            using (var streamReader = File.OpenText(path))
            {
                var lines = streamReader.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                return lines;
            }
        }

    }
}
