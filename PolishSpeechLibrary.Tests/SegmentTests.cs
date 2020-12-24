using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolishSpeechLibrary.Model;
using System.Linq;

namespace PolishSpeechLibrary.Tests
{
    [TestClass]
    public class SegmentTests
    {
        [TestMethod]
        public void CopyTest()
        {
            var sourceSegment = new Segment()
            {
                Start = 1,
                Duration = 2,
                Letter = new Letter("a", new ArticulationManner(4, "testmanner", true), new ArticulationPlace(5, "testplace"), true, true),
                IsSyllableInitial = true,
                IsWordInitial = true,
                IsProsodicWordInitial = true,
                IsPhraseInitial = true,
                IsPrimaryWordAccent = true,
                IsSecondaryWordAccent = true,
                IsPrimaryPhraseAccent = true,
                IsSecondaryPhraseAccent = true,
                IsNotFound = true
            };


            var label = new Segment();
            Segment.Copy(sourceSegment, label);

            // writable properties count
            // change if you add new property
            // IMPORTANT! remember to update copy method
            var properties = typeof(Segment).GetProperties().Where(p => p.CanWrite).ToList();
            int writablePropertiesCount = properties.Count();
            Assert.AreEqual(12, writablePropertiesCount);

            // copy result
            Assert.AreEqual(1, label.Start);
            Assert.AreEqual(2, label.Duration);

            // letter
            Assert.AreEqual("a", label.Letter.Value);
            Assert.AreEqual(true, label.Letter.IsPause);
            Assert.AreEqual(true, label.Letter.IsVoice);

            // other flags
            Assert.AreEqual(true, label.IsSyllableInitial);
            Assert.AreEqual(true, label.IsWordInitial);
            Assert.AreEqual(true, label.IsProsodicWordInitial);
            Assert.AreEqual(true, label.IsPhraseInitial);
            Assert.AreEqual(true, label.IsPrimaryWordAccent);
            Assert.AreEqual(true, label.IsSecondaryWordAccent);
            Assert.AreEqual(true, label.IsPrimaryPhraseAccent);
            Assert.AreEqual(true, label.IsSecondaryPhraseAccent);
            Assert.AreEqual(true, label.IsNotFound);
        }
    }
}