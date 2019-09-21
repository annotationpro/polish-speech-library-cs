using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolishSpeechLibrary.Process.Import;

namespace PolishSpeechLibrary.Tests
{
    [TestClass]
    public class TextImporterTests
    {
        [TestMethod]
        public void ImportTest()
        {
            var transcription = new TextImporter().Import("To nie TAK? - powiedział#.  ");

            // trancription -> labels -> letter -> value
            // transcription[i] - i element

            Assert.AreEqual("", );
        }
    }
}