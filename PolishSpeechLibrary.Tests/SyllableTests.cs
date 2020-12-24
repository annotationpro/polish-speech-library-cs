using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolishSpeechLibrary.IO;
using PolishSpeechLibrary.Model;
using PolishSpeechLibrary.Syllable;

namespace PolishSpeechLibrary.Tests
{
    [TestClass]
    public class SyllableTests
    {
        [TestMethod]
        public void DetectSyllablesTest()
        {
            var reader = new SampaReader();
            var sampa = reader.Read("#n' e #t a m #s o m #d v j e #d v j e #p u w k i");

            var syllablePatterns = SyllablePatternCollection.DefaultPatterns;
            SyllableDetector detector = new SyllableDetector(syllablePatterns);

            var detected = detector.Process(sampa);

            Assert.AreEqual(true, detected[0].IsSyllableInitial);
            Assert.AreEqual(true, detected[2].IsSyllableInitial);
            Assert.AreEqual(true, detected[5].IsSyllableInitial);
            Assert.AreEqual(true, detected[8].IsSyllableInitial);
            Assert.AreEqual(true, detected[12].IsSyllableInitial);
            Assert.AreEqual(true, detected[16].IsSyllableInitial);
            Assert.AreEqual(true, detected[19].IsSyllableInitial);
        }

        [TestMethod]
        public void DetectSyllables2Test()
        {
            var reader = new SampaReader();
            var sampa = reader.Read("#t o #j e s t #b a r d^z o #w a d n a #o p e r a t^s j a");

            var syllablePatterns = SyllablePatternCollection.DefaultPatterns;
            SyllableDetector detector = new SyllableDetector(syllablePatterns);

            var detected = detector.Process(sampa);

            Assert.AreEqual(true, detected[0].IsSyllableInitial);
            Assert.AreEqual(true, detected[2].IsSyllableInitial);
            Assert.AreEqual(true, detected[6].IsSyllableInitial);
            Assert.AreEqual(true, detected[9].IsSyllableInitial);
            Assert.AreEqual(true, detected[11].IsSyllableInitial);
            Assert.AreEqual(true, detected[13].IsSyllableInitial);
            Assert.AreEqual(true, detected[16].IsSyllableInitial);
            Assert.AreEqual(true, detected[17].IsSyllableInitial);
            Assert.AreEqual(true, detected[19].IsSyllableInitial);
            Assert.AreEqual(true, detected[21].IsSyllableInitial);
        }

        [TestMethod]
        public void DivideIntoSyllables()
        {
            var reader = new SampaReader();
            var sampa = reader.Read("#t o #j e s t #b a r d^z o #w a d n a #o p e r a t^s j a");

            var detector = new SyllableDetector(SyllablePatternCollection.DefaultPatterns);
            var detected = detector.Process(sampa);

            var divider = new SyllableDivider();
            var divided = divider.Process(detected);

            Assert.AreEqual(10, divided.Count);
        }
    }
}