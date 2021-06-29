using System;
using System.IO;
using System.Linq;

namespace FileHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\FileHandlingTest\";
            string[] extensions = { ".txt", ".bin", ".docx", ".doc", ".csv" };
            string[] words = { "uploading", "storing", "searching", "an", "the", "is", "a",
                                    "data", "game", "dance", "Encyclopedia", "Jungle", "one", "two",
                                    "three", "six", "seven", "eight", "ten"};
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                int x = rnd.Next(5);
                string name = path + "filename" + i + extensions[x];
                if (!File.Exists(name))
                {
                    using (StreamWriter newFile = File.CreateText(name))
                    {
                        string fileContent = "";
                        for (int j = 0; j < rnd.Next(words.Length); j++)
                        {
                            fileContent += words[rnd.Next(words.Length)] + " ";
                        }
                        newFile.WriteLine(fileContent);
                    }
                }
            }

            FileClass f = new FileClass(path);

            var fileDic =  f.GetFileCountPerExt();
            Console.WriteLine("Extensions     Count");
            foreach(var e in fileDic)
            {
                Console.WriteLine($"{e.Key}             {e.Value}");
            }
            Console.WriteLine();

            int count = f.GetTextFileCount();
            Console.WriteLine($"Total Number of .txt files: {count}");

            var fileDic1 = f.GetLargestFiles(5);
            Console.WriteLine($"5 Largest Size Files...");
            Console.WriteLine("File Name                           Size(Bytes)");
            foreach (var e in fileDic1)
            {
                Console.WriteLine($"{e.Key}".PadRight(40) + e.Value);
            }
            Console.WriteLine();

            var fileName = f.GetLargestFiles(1);
            Console.WriteLine($"Maximum Size file under the Directory: {path}");
            Console.WriteLine($"File Name: {fileName.Keys.First()}");

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
