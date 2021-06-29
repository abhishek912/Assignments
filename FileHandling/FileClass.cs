using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace FileHandling
{
    class FileClass
    {
        private string  DirectoryPath { get; set; }
        private string[] files;

        public FileClass(string path)
        {
            DirectoryPath = path;
            FetchFiles();
        }

        private void FetchFiles()
        {
            files = Directory.GetFiles(DirectoryPath);
        }

        public int GetTextFileCount()
        {
            var fileCount = (from file in files
                        where file.Split('.')[1] == "txt"
                        select file).Count();
            return fileCount;
        }

        public Dictionary<string, int> GetFileCountPerExt()
        {
            Dictionary<string, int> uniqueFileExt = new Dictionary<string, int>();           
            foreach(string f in files)
            {
                string extension = f.Split('.')[1];
                if (!uniqueFileExt.ContainsKey(extension))
                {
                    uniqueFileExt.Add(extension, 1);
                }
                else
                {
                    uniqueFileExt[extension] += 1;
                }
            }
            return uniqueFileExt;
        }

        public Dictionary<string, long> GetLargestFiles(int count)
        {
            Dictionary<string, long> topFiveFiles = new Dictionary<string, long>();
            var list =
                (from file in files
                 let len = GetFileLength(file)
                 where len > 0
                 orderby len descending
                 select file).Take(count);

            foreach(string f in list)
            {
                topFiveFiles.Add(f, GetFileLength(f));
            }
            return topFiveFiles;
        }

        public string FileWithMaxSize()
        {
            string maxSizeFile =
            (from file in files
             let len = GetFileLength(file)
             select file)
             .Max();
            return maxSizeFile;
        }

        private long GetFileLength(string file)
        {
            FileInfo f = new FileInfo(file);
            return f.Length;
        }
    }
}
