using System;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReverse fileRev = new FileReverse();
            Console.WriteLine("Enter a file name : ");
            string fileName = Console.ReadLine();
            Console.WriteLine(" ----- ORIGINAL CONTENTS -----");
            string[] fileContent = fileRev.OpenFile(fileName);
            foreach (string line in fileContent)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("\n ----- REVERSED CONTENTS -----");
            string[] revFileContents = fileRev.ReverseContents(fileContent);
            foreach (string line in revFileContents)
            {
                Console.WriteLine(line);
            }

            fileRev.SaveFile(fileName, revFileContents);
            Console.WriteLine($"\n Reversed contents saved to file : {fileName}");
            Console.ReadLine();
        }
    }
}
