using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolishSpeechLibrary.IO;
using PolishSpeechLibrary.WordDetection;

namespace PolishSpeechLibrary.Tests
{
    [TestClass]
    public class WordDetectorProcessorTests
    {
        [TestMethod]
        public void DetectWordsTest()
        {
            var transcription = new OrthorgraphicTranscriptionReader().Read("W domu. To nie. W samolocie. W ");
            var detected = new WordDetectorProcessor().Process(transcription);

            Assert.AreEqual(true, detected[0].IsProsodicWordInitial);
            Assert.AreEqual(true, detected[0].IsWordInitial);

            Assert.AreEqual(false, detected[2].IsProsodicWordInitial);
            Assert.AreEqual(true, detected[2].IsWordInitial);

            Assert.AreEqual(false, detected[8].IsProsodicWordInitial);
            Assert.AreEqual(true, detected[8].IsWordInitial);

            Assert.AreEqual(false, detected[11].IsProsodicWordInitial);
            Assert.AreEqual(true, detected[11].IsWordInitial);

            Assert.AreEqual(true, detected[16].IsProsodicWordInitial);
            Assert.AreEqual(true, detected[16].IsWordInitial);

            Assert.AreEqual(false, detected[18].IsProsodicWordInitial);
            Assert.AreEqual(true, detected[18].IsWordInitial);

            Assert.AreEqual(true, detected[29].IsProsodicWordInitial);
            Assert.AreEqual(true, detected[29].IsWordInitial);
        }
    }
}