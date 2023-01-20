using Newtonsoft.Json;
using PolishSpeechLibrary.Model;
using System.IO;

namespace PolishSpeechLibrary.IO
{
    public class SyllablePatternCollectionWriter
    {
        public string WriteJson(SyllablePatternCollection syllables)
        {
#if DEBUG
            return JsonConvert.SerializeObject(syllables, Formatting.Indented);
#else
            return JsonConvert.SerializeObject(syllables, Formatting.None);
#endif
        }

        public void WriteJsonFile(SyllablePatternCollection syllables, string jsonFilePath)
        {
            File.WriteAllText(jsonFilePath, WriteJson(syllables));
        }
    }
}