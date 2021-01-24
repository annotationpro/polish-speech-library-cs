using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolishSpeechLibrary.CLARIN;
using PolishSpeechLibrary.Model;
using System.Collections.Generic;

namespace PolishSpeechLibrary.Tests
{
    [TestClass]
    public class ClarinTranscriptionTests
    {
        public string Csv { get; private set; }
        public string BadCsv { get; private set; }

        [TestInitialize]
        public void Before()
        {
            Csv = "0.000\t0.030\ts'\tB\n" +
                    "0.030\t0.030\tf\tI\n" +
                    "0.060\t0.030\tj\tI\n" +
                    "0.090\t0.030\to\tI\n" +
                    "0.120\t0.030\tn\tI\n" +
                    "0.150\t0.030\tt\tI\n" +
                    "0.180\t0.030\te\tI\n" +
                    "0.210\t0.030\ttS\tI\n" +
                    "0.240\t0.030\tn\tI\n" +
                    "0.270\t0.030\ta\tE\n" +
                    "3.220\t0.030\ta\tB\n" +
                    "3.250\t0.030\tt\tI\n" +
                    "3.280\t0.030\tm\tI\n" +
                    "3.310\t0.030\to\tI\n" +
                    "3.340\t0.030\ts\tI\n" +
                    "3.370\t0.030\tf\tI\n" +
                    "3.400\t0.030\te\tI\n" +
                    "3.430\t0.030\tr\tI\n" +
                    "3.460\t0.030\ta\tE\n" +
                    "3.490\t0.030\tu\tB\n" +
                    "3.520\t0.030\tdz'\tI\n" +
                    "3.550\t0.030\te\tI\n" +
                    "3.580\t0.030\tl\tI\n" +
                    "3.610\t0.030\ta\tI\n" +
                    "3.640\t0.030\tw\tI\n" +
                    "3.670\t0.030\ta\tE\n" +
                    "6.100\t0.030\ts'\tB\n" +
                    "6.130\t0.030\te\tE\n" +
                    "6.160\t0.030\tk\tB\n" +
                    "6.190\t0.030\ta\tI\n" +
                    "6.220\t0.030\tZ\tI\n" +
                    "6.250\t0.030\td\tI\n" +
                    "6.280\t0.030\te\tI\n" +
                    "6.310\t0.030\tm\tI\n" +
                    "6.340\t0.030\tu\tE\n" +
                    "6.750\t0.030\td\tB\n" +
                    "6.780\t0.030\to\tI\n" +
                    "6.810\t0.030\tm\tI\n" +
                    "6.840\t0.030\to\tI\n" +
                    "6.870\t0.030\tv\tI\n" +
                    "6.900\t0.030\tn'\tI\n" +
                    "6.930\t0.030\ti\tI\n" +
                    "6.960\t0.040\tk\tI\n" +
                    "7.000\t0.030\to\tI\n" +
                    "7.030\t0.030\tv\tI\n" +
                    "7.060\t0.030\ti\tE\n" +
                    "";

            BadCsv = "0.000\t0.030\ts'\tB\n" +
                    "0.030\t0.030\tf\tI\n" +
                    "0.060\t0.030\tj\tI\n" +
                    "0.090\t0.030\to\tI\n" +
                    "0.120\t0.030\tn\tI\n" +
                    "0.150\t0.030\tx!\tI\n" +
                    "0.180\t0.030\te\tI\n" +
                    "";
        }

        [TestMethod]
        public void ReadClaringCsvTest()
        {
            var transcription = ReadCsv(Csv);

            Assert.AreEqual(46, transcription.Count);
        }

        private Transcription ReadCsv(string csv)
        {
            var reader = new ClarinCsvReader();
            string[] lines = csv.Split('\n');
            return reader.Read(lines);
        }

        [TestMethod]
        public void BadLetterTest()
        {
            try
            {
                var transcription = ReadCsv(BadCsv);
            }
            catch (KeyNotFoundException exc)
            {
                Assert.AreEqual("There is no letter: x! in alphabet", exc.Message);
            }
        }

        [TestMethod]
        public void ConvertClarinToSampaTest()
        {
            var clarin = ReadCsv(Csv);
            var converter = new ClarinToSampaConverter();
            var sampa = converter.Process(clarin);

            Assert.AreEqual(46, clarin.Count);
            Assert.AreEqual(46, sampa.Count);
        }
    }
}