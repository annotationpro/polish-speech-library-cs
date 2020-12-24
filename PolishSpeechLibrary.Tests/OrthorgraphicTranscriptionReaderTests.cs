using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolishSpeechLibrary.IO;

namespace PolishSpeechLibrary.Tests
{
    [TestClass]
    public class OrthorgraphicTranscriptionReaderTests
    {
        [TestMethod]
        public void ReadTest()
        {
            var transcription = new OrthorgraphicTranscriptionReader().Read("To nie TAK? - powiedział#.  ");

            // trancription -> labels -> letter -> value
            // transcription[i] - i element

            //Assert.AreEqual("", );
        }
    }
}