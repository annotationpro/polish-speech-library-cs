using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PolishSpeechLibrary.Gtp
{
    public class GtpRulesJsonReaderWriter
    {
        public IList<GtpRule> Read(string filePath)
        {
            var contents = File.ReadAllText(filePath, Encoding.UTF8);
            return JsonConvert.DeserializeObject<IList<GtpRule>>(contents);
        }

        public void Write(string filePath, IList<GtpRule> gtpRules)
        {
            var contents = JsonConvert.SerializeObject(gtpRules, Formatting.None);
            File.WriteAllText(filePath, contents, Encoding.UTF8);
        }
    }
}