using Newtonsoft.Json;
using PolishSpeechLibrary.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolishSpeechLibrary.Gtp
{
    public class GtpProcessor : ITranscriptionProcessor
    {
        public GtpProcessor(IList<GtpRule> gtpRules)
        {
            InitializeRules(gtpRules);
            
        }

        public GtpProcessor(string gtpRulesFilePath)
        {
            var readerWriter = new GtpRulesJsonReaderWriter();
            InitializeRules(readerWriter.LoadGtpRules(gtpRulesFilePath));
        }

        private void InitializeRules(IList<GtpRule> gtpRules)
        {
            // group by grapheme
            rulesByGrapheme = gtpRules.GroupBy(r => r.Grapheme).ToDictionary(i => i.Key, i => i.ToList());
            
            // sort rules paralel for each letter descending longer first
            Parallel.ForEach(rulesByGrapheme, (entry) => {
                entry.Value.Sort((y, x) => (x.PrecedingContext.Length + x.FollowingContext.Length).CompareTo(y.PrecedingContext.Length + y.FollowingContext.Length));
            });
        }

        Dictionary<string, List<GtpRule>> rulesByGrapheme = new Dictionary<string, List<GtpRule>>();

        public IList<GtpRule> GtpRules { get; set; } = new List<GtpRule>();

        public GtpExtendedOutput ExtendedOutput { get; } = new GtpExtendedOutput();

        public Transcription Process(Transcription source)
        {
            var phonetic = Transcription.CreateSampaTranscription();

            foreach (var label in source)
            {
                //var neighbours = source.GetNighbours(label);
                var context = FindGraphemeContext(source, source.IndexOf(label));
                var rule = FindRule(label.Letter.Value, context.Item1, context.Item2);

                Label phoneticLabel = new Label(label);

                if (rule == null)
                {
                    phoneticLabel = new Label(new Letter(label.Letter.Value));

                    if (!OSet.Contains(label.Letter.Value))
                    {
                        phoneticLabel.IsNotFound = true;
                    }
                }
                else
                {
                    phoneticLabel = new Label(new Letter(rule.Phoneme));
                }

                phonetic.Add(phoneticLabel);
            }

            return phonetic;
        }

        private GtpRule FindRule(string grapheme, string precedingContext, string followingContext)
        {
            if(!rulesByGrapheme.ContainsKey(grapheme)) { return null; }

            foreach (var rule in rulesByGrapheme[grapheme])
            {
                if (rule.Grapheme != grapheme) continue;

                if (CheckRule(rule, precedingContext, followingContext))
                {
                    return rule;
                }
            }
            return null;
        }

        private bool CheckRule(GtpRule rule, string precedingContext, string followingContext)
        {
            if (precedingContext.Length < rule.PrecedingContext.Length || followingContext.Length < rule.FollowingContext.Length)
            {
                return false;
            }

            if (precedingContext.Substring(precedingContext.Length - rule.PrecedingContext.Length) == rule.PrecedingContext && followingContext.Substring(0, rule.FollowingContext.Length) == rule.FollowingContext)
            {
                return true;
            }

            return false;
        }

        private Tuple<string, string> FindGraphemeContext(Transcription transcription, int index)
        {
            string precedingContext = string.Empty;
            if (index > 0)
            {
                precedingContext = transcription.Take(index)
                    .Select(l => l.Letter.Value)
                    .Aggregate((current, next) => current + next);
            }

            string followingContext = string.Empty;

            if (transcription.Count - 1 > index)
            {
                followingContext = transcription.Skip(index + 1).Take(transcription.Count - 1 - index)
                    .Select(l => l.Letter.Value)
                    .Aggregate((current, next) => current + next);
            }

            return new Tuple<string, string>("#" + precedingContext.Replace(" ", "#"), followingContext.Replace(" ", "#") + "#");
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