using NUnit.Framework;

namespace Exercise2.Tests
{
    public class FileReverseTests
    {
        [OneTimeSetUp]
        public void Setup()
        {
        }

        [OneTimeTearDown]
        public void TearDown()
        {

        }

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
            Assert.AreEqual(new string[] { "GFDSA", "TREWQ"}, output3);

            input = new string[] { "QWERT", "ASDFG", "ZXCVB" };
            var output4 = fr.ReverseContents(input);
            Assert.AreEqual(new string[] { "BVCXZ", "GFDSA", "TREWQ" }, output4);
        }
    }
}
