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
            rules.Add(new GtpRule("a", "b", "c", "d"));
            rules.Add(new GtpRule("e", "f", "g", "h"));

            var readerWriter = new GtpRulesXmlReaderWriter();
            readerWriter.SaveGtpRules(xmlFilePath, rules);

            var loadedRules = readerWriter.LoadGtpRules(xmlFilePath);

            // first rule
            Assert.AreEqual("a", loadedRules[0].Grapheme);
            Assert.AreEqual("b", loadedRules[0].PrecedingContext);
            Assert.AreEqual("c", loadedRules[0].FollowingContext);
            Assert.AreEqual("d", loadedRules[0].Phoneme);

            //2nd rule
            Assert.AreEqual("e", loadedRules[1].Grapheme);
            Assert.AreEqual("f", loadedRules[1].PrecedingContext);
            Assert.AreEqual("g", loadedRules[1].FollowingContext);
            Assert.AreEqual("h", loadedRules[1].Phoneme);

            // rules count
            Assert.AreEqual(2, loadedRules.Count);
        }
    }
}