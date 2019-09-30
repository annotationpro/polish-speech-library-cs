using System.Collections.Generic;

namespace PolishSpeechLibrary.Gtp
{
    public class GtpExtendedOutput
    {
        public IList<GtpRule> UsedRules { get; set; } = new List<GtpRule>();
    }
}