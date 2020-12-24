using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolishSpeechLibrary.Gtp;
using System.Collections.Generic;

namespace PolishSpeechLibrary.Tests
{
    [TestClass]
    public class GtpRulesXmlReaderWriterTests
    {
        private const string xmlFilePath = "./GtpRules.xml";

        [TestMethod]
        public void SaveAndLoadXmlGtpRules()
        {
            var rules = new List<GtpRule>();
            rules.Add(new GtpRule("a", "b", "c", "d", "xx"));
            rules.Add(new GtpRule("e", "f", "g", "h", "yy"));

            var readerWriter = new GtpRulesXmlReaderWriter();
            readerWriter.Write(xmlFilePath, rules);

            var loadedRules = readerWriter.Read(xmlFilePath);

            // first rule
            Assert.AreEqual("a", loadedRules[0].Grapheme);
            Assert.AreEqual("b", loadedRules[0].PrecedingContext);
            Assert.AreEqual("c", loadedRules[0].FollowingContext);
            Assert.AreEqual("d", loadedRules[0].Phoneme);
            Assert.AreEqual("", loadedRules[0].Debug);

            //2nd rule
            Assert.AreEqual("e", loadedRules[1].Grapheme);
            Assert.AreEqual("f", loadedRules[1].PrecedingContext);
            Assert.AreEqual("g", loadedRules[1].FollowingContext);
            Assert.AreEqual("", loadedRules[1].Debug);

            // rules count
            Assert.AreEqual(2, loadedRules.Count);
        }
    }
}