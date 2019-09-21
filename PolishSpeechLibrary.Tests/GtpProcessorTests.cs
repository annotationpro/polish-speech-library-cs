using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolishSpeechLibrary.Process.Convert;
using PolishSpeechLibrary.Process.Gtp;
using PolishSpeechLibrary.Process.Import;
using System.Collections.Generic;

namespace PolishSpeechLibrary.Tests
{
    [TestClass]
    public class GtpProcessorTests
    {
        [TestMethod]
        public void Process()
        {
            string text = "To jest noga.";
            var orthographic = new UnknownToOrthographicConverter().Process(new TextImporter().Import(text));
            var phonetic = new GtpProcessor(GenerateGtpRules()).Process(orthographic);

            // todo
            //Assert.AreEqual("#$pto#jest#noga#$p", phonetic);
        }

        private IList<GtpRule> GenerateGtpRules()
        {
            return new List<GtpRule>
            {
                new GtpRule("a", "", "", "a")
            };
        }
    }
}