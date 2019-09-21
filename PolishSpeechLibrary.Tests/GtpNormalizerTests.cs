using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolishSpeechLibrary.Process.Import;
using System;
using System.Collections.Generic;
using System.Text;

namespace PolishSpeechLibrary.Tests
{
    [TestClass]
    class GtpNormalizerTests
    {
        [TestMethod]
        public void ProcessOrthographicTest()
        {
            var orthographic = new TextImporter().Import(" a bb  c d  ");
        }
    }
}
