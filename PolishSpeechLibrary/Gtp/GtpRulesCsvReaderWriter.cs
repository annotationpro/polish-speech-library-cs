using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PolishSpeechLibrary.Gtp
{
    public class GtpRulesCsvReaderWriter
    {
        public IList<GtpRule> Read(string csvFilePath)
        {
            var rules = new List<GtpRule>();
            foreach (var line in File.ReadAllLines(csvFilePath, Encoding.UTF8))
            {
                var fields = line.Split('\t');
                rules.Add(new GtpRule()
                {
                    Debug = fields[0],
                    PrecedingContext = fields[1],
                    Grapheme = fields[2],
                    FollowingContext = fields[3],
                    Phoneme = fields[4]
                });
            }
            return rules;
        }

        public void Write(string filePath, IList<GtpRule> gtpRules)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var rule in gtpRules)
            {
                sb.AppendLine($"{rule.Debug}\t{rule.PrecedingContext}\t{rule.Grapheme}\t{rule.FollowingContext}\t{rule.Phoneme}");
            }
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }
    }
}