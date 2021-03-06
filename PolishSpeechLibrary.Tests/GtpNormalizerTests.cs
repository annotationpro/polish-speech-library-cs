﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolishSpeechLibrary.Gtp;
using PolishSpeechLibrary.IO;

namespace PolishSpeechLibrary.Tests
{
    [TestClass]
    public class GtpNormalizerTests
    {
        [TestMethod]
        public void ProcessOrthographicTest()
        {
            // input
            var orthographic = new OrthorgraphicTranscriptionReader().Read(" a bb  c d  ");

            // operation
            var normalized = new GtpNormalizer().Process(orthographic);

            // checks
            Assert.AreEqual("a", normalized[0].Letter.Value);
            Assert.AreEqual(" ", normalized[1].Letter.Value);
            Assert.AreEqual("b", normalized[2].Letter.Value);
            Assert.AreEqual("b", normalized[3].Letter.Value);
            Assert.AreEqual(" ", normalized[4].Letter.Value);
            Assert.AreEqual("c", normalized[5].Letter.Value);
            Assert.AreEqual(" ", normalized[6].Letter.Value);
            Assert.AreEqual("d", normalized[7].Letter.Value);

            Assert.AreEqual(8, normalized.Count);
        }
    }
}