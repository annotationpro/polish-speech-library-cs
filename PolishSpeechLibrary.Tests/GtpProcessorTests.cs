using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolishSpeechLibrary.Gtp;
using System.Collections.Generic;

namespace PolishSpeechLibrary.Tests
{
    [TestClass]
    public class GtpProcessorTests
    {
        private string jsonFilePath = "./GtpRules.json";

        [TestMethod]
        public void ProcessTest()
        {
            //var orthographic = new TextImporter().Import("To jest noga.");
            //var rules = GtpProcessor.LoadGtpRulesFromXml("./GtpRules.xml");
            //var phonetic = new GtpProcessor(rules).Process(orthographic);

            // todo
            //Assert.AreEqual("#$pto#jest#noga#$p", phonetic);
        }

        [TestMethod]
        public void SaveAndLoadGtpRules()
        {
            var rules = new List<GtpRule>();
            rules.Add(new GtpRule("a", "b", "c", "d"));
            rules.Add(new GtpRule("e", "f", "g", "h"));

            var readerWriter = new GtpRulesJsonReaderWriter();

            readerWriter.SaveGtpRules(jsonFilePath, rules);

            var loadedRules = readerWriter.LoadGtpRules(jsonFilePath);

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