using Newtonsoft.Json;
using System;
using System.Data;

namespace PolishSpeechLibrary.Model
{
    public class SyllablePattern
    {
        public SyllablePattern()
        {
        }

        public SyllablePattern(string pattern, string standardPattern)
        {
            Pattern = pattern;
            StandardPattern = standardPattern;
            IsFactory = false;
        }
        public SyllablePattern(string pattern, string standardPattern, bool isFactory)
        {
            Pattern = pattern;
            StandardPattern = standardPattern;
            IsFactory = isFactory;
        }

        [JsonProperty("p")]
        public string Pattern { get; set; }
        [JsonProperty("s")]
        public string StandardPattern { get; set; }
        [JsonProperty("f")]
        public bool IsFactory { get; set; }

        public override string ToString()
        {
            return Pattern;
        }
    }
}