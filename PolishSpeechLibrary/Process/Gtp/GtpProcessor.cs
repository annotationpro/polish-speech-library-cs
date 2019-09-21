using Newtonsoft.Json;
using PolishSpeechLibrary.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PolishSpeechLibrary.Process.Gtp
{
    public class GtpProcessor : ITranscriptionProcessor
    {
        public GtpProcessor(IList<GtpRule> gtpRules)
        {
            GtpRules = gtpRules;
        }

        public GtpProcessor(string gtpRulesFilePath)
        {
            var readerWriter = new GtpRulesJsonReaderWriter();
            GtpRules = readerWriter.LoadGtpRules(gtpRulesFilePath);
        }

        public IList<GtpRule> GtpRules { get; set; } = new List<GtpRule>();

        public Transcription Process(Transcription source)
        {
            var normalized = new GtpNormalizer().Process(source);
            return ConvertGraphemeToPhoneme(normalized);
        }

        private Transcription ConvertGraphemeToPhoneme(Transcription normalizedGraphemes)
        {
            // todo: create conversion
            throw new NotImplementedException();
        }

        public SteffenBatogSet OSet
        {
            get
            {
                return new SteffenBatogSet
                {
                    ".",
                    "!",
                    "?",
                    ",",
                    ";",
                    ":",
                    "-",
                    "...",
                    ")",
                    "(",
                    "#"
                };
            }
        }
    }
}