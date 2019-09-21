using Newtonsoft.Json;
using PolishSpeechLibrary.Model;
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
            GtpRules = LoadGtpRules(gtpRulesFilePath);
        }

        public IList<GtpRule> GtpRules { get; set; } = new List<GtpRule>();

        public Transcription Process(Transcription source)
        {
            var result = Transcription.CreateSampaTranscription();

            // todo: gtp here

            return result;
        }

        public static IList<GtpRule> LoadGtpRules(string filePath)
        {
            var contents = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<IList<GtpRule>>(contents);
        }

        public static IList<GtpRule> LoadGtpRulesFromXml(string filePath)
        {
            var reader = new GtpRulesXmlReader();
            return reader.LoadGtpRules(filePath);
        }

        public static void SaveGtpRules(string filePath, IList<GtpRule> gtpRules)
        {
            var contents = JsonConvert.SerializeObject(gtpRules, Formatting.None);
            File.WriteAllText(filePath, contents, Encoding.UTF8);
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