using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Exercise2
{
    public class FileReverse
    {
        public FileReverse()
        {   
        }

        /// <summary>
        /// Read an input text file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// https://docs.microsoft.com/en-us/dotnet/api/system.io.file.readalllines?view=net-5.0
        public string[] OpenFile(string fileName)
        {
            return File.ReadAllLines(fileName);
        }

        /// <summary>
        /// Reverse the contents
        /// </summary>
        /// <param name="lines"></param>
        public string[] ReverseContents(string[] lines)
        {
            if(lines != null)
            {
                int length = lines.Length;
                // i => starts from 0 to half the length (ascending)
                // j => starts from length to half the length (descending)
                for (int i=0,j=length-1; i< Convert.ToInt32(Math.Ceiling(lines.Length/2.0)); i++,j--) 
                {
                    if (i > j)
                    {
                        break;
                    }

                    // i and j point to the same line
                    if ( i == j )
                    {
                        lines[i] = ReverseString(lines[i]);
                        break;
                    }

                    string temp = lines[i];
                    lines[i] = ReverseString(lines[j]);
                    lines[j] = ReverseString(temp);
                }
            }

            return lines;
        }

        /// <summary>
        /// Write the reversed contents to an output file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="lines"></param>
        /// https://docs.microsoft.com/en-us/dotnet/api/system.io.file.writealllines?view=net-5.0
        public void  SaveFile(string fileName, string[] lines)
        {
            File.WriteAllLines(fileName, lines);
        }

        string ReverseString(string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

    }
}
