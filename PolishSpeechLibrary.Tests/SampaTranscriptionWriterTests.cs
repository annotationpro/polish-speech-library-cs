using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolishSpeechLibrary.IO;

namespace PolishSpeechLibrary.Tests
{
    [TestClass]
    public class SampaTranscriptionWriterTests
    {
        [TestMethod]
        public void WriteTest()
        {
            string source = "#s' f j o n t e t^S n a #a t m o s f e r a #u d^z' e l a w a #s' e #k a Z d e m u #d o m o v n' i k o v i";

            var reader = new SampaReader();
            var sampa = reader.Read(source);

            var writer = new SampaWriter();
            var result = writer.Write(sampa);

            Assert.AreEqual(source, result);
        }
    }
}