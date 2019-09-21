using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolishSpeechLibrary.Process.Convert;
using PolishSpeechLibrary.Process.Import;
using PolishSpeechLibrary.Process.WordDetection;

namespace PolishSpeechLibrary.Tests
{
    [TestClass]
    public class WordDetectorProcessorTests
    {
        [TestMethod]
        public void Process()
        {
            var transcription = new UnknownToOrthographicConverter().Process(new TextImporter().Import("W samolocie leci pilot testowy. W domu nie ma pierogów. W tramwaju."));
            new WordDetectorProcessor().Process(transcription);
            //31, 54
            Assert.AreEqual(true, transcription.Labels[0].IsProsodicWordInitial);
            Assert.AreEqual(true, transcription.Labels[31].IsProsodicWordInitial);
            Assert.AreEqual(true, transcription.Labels[54].IsProsodicWordInitial);
        }
    }
}