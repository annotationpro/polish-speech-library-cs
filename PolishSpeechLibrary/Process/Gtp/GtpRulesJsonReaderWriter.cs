using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PolishSpeechLibrary.Process.Gtp
{
    public class GtpRulesJsonReaderWriter
    {
        public IList<GtpRule> LoadGtpRules(string filePath)
        {
            var contents = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<IList<GtpRule>>(contents);
        }

        public void SaveGtpRules(string filePath, IList<GtpRule> gtpRules)
        {
            var contents = JsonConvert.SerializeObject(gtpRules, Formatting.None);
            File.WriteAllText(filePath, contents, Encoding.UTF8);
        }
    }
}