using NUnit.Framework;
using System.IO;

namespace Exercise2.Tests
{
    public class FileReverseTests
    {
        [Test]
        public void Test_ReverseContents()
        {
            FileReverse fr = new FileReverse();

            string[] input = null;

            var output = fr.ReverseContents(input);
            Assert.AreEqual(input, output);

            input = new string[] { "A" };

            var output1 = fr.ReverseContents(input);
            Assert.AreEqual(input, output1);

            input = new string[] { "QWERT" };

            var output2 = fr.ReverseContents(input);
            Assert.AreEqual(new string[] { "TREWQ" }, output2);

            input = new string[] { "QWERT", "ASDFG" };
            var output3 = fr.ReverseContents(input);
            Assert.AreEqual(new string[] { "GFDSA", "TREWQ" }, output3);

            input = new string[] { "QWERT", "ASDFG", "ZXCVB" };
            var output4 = fr.ReverseContents(input);
            Assert.AreEqual(new string[] { "BVCXZ", "GFDSA", "TREWQ" }, output4);
        }

        [Test]
        public void Test_SaveReverseContentsToFile()
        {
            string fileName = ".\\Reverse.txt";
            FileReverse fr = new FileReverse();

            // Reverse contents
            var input = new string[] { "QWERT", "ASDFG", "ZXCVB" };
            var output4 = fr.ReverseContents(input);
            Assert.AreEqual(new string[] { "BVCXZ", "GFDSA", "TREWQ" }, output4);

            // Save File
            fr.SaveFile(fileName, output4);
            var fileContents = fr.OpenFile(fileName);
            Assert.AreEqual(new string[] { "BVCXZ", "GFDSA", "TREWQ" }, fileContents);

            File.Delete(fileName);
        }

        [Test]
        public void Test_ReverseContents_UsingFile()
        {
            string inputFile = ".\\TestFile.txt";
            string outputFile = ".\\TestFile_Output.txt";
            FileReverse fr = new FileReverse();
            
            // Open Test File
            string[] input = fr.OpenFile(inputFile);
            Assert.AreEqual(new string[] { "QWERT", "ASDFG", "ZXCVB" }, input);

            // Reverse contents
            var revContents = fr.ReverseContents(input);
            Assert.AreEqual(new string[] { "BVCXZ", "GFDSA", "TREWQ" }, revContents);

            // Save File
            fr.SaveFile(outputFile, revContents);
            var fileContents = fr.OpenFile(outputFile);
            Assert.AreEqual(new string[] { "BVCXZ", "GFDSA", "TREWQ" }, fileContents);

            File.Delete(outputFile);
        }

        [Test]
        public void Test_InputFileNotFoundException()
        {
            FileReverse fr = new FileReverse();
            Assert.Throws<FileNotFoundException>(() => fr.OpenFile("FileNotFound.txt"));
        }
    }
}
