using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolishSpeechLibrary.Process.Import;
using PolishSpeechLibrary.Process.WordDetection;

namespace PolishSpeechLibrary.Tests
{
    [TestClass]
    public class WordDetectorProcessorTests
    {
        [TestMethod]
        public void ProcessTest()
        {
            var transcription = new TextImporter().Import("W domu. To nie. W samolocie. W ");
            var detected = new WordDetectorProcessor().Process(transcription);

            Assert.AreEqual(true, detected[0].IsProsodicWordInitial);
            Assert.AreEqual(true, detected[0].IsWordInitial);

            Assert.AreEqual(false, detected[2].IsProsodicWordInitial);
            Assert.AreEqual(true, detected[2].IsWordInitial);

            Assert.AreEqual(false, detected[7].IsProsodicWordInitial);
            Assert.AreEqual(true, detected[7].IsWordInitial);

            Assert.AreEqual(false, detected[10].IsProsodicWordInitial);
            Assert.AreEqual(true, detected[10].IsWordInitial);

            Assert.AreEqual(true, detected[14].IsProsodicWordInitial);
            Assert.AreEqual(true, detected[14].IsWordInitial);

            Assert.AreEqual(false, detected[16].IsProsodicWordInitial);
            Assert.AreEqual(true, detected[16].IsWordInitial);

            Assert.AreEqual(true, detected[26].IsProsodicWordInitial);
            Assert.AreEqual(true, detected[26].IsWordInitial);
        }
    }
}