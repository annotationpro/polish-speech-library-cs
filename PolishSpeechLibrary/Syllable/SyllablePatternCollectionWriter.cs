using Newtonsoft.Json;
using PolishSpeechLibrary.Model;
using System.IO;

namespace PolishSpeechLibrary.IO
{
    public class SyllablePatternCollectionWriter
    {
        public string WriteJson(SyllablePatternCollection syllables)
        {
            return JsonConvert.SerializeObject(syllables, Formatting.Indented);
        }

        public void WriteJsonFile(SyllablePatternCollection syllables, string jsonFilePath)
        {
            File.WriteAllText(jsonFilePath, WriteJson(syllables));
        }
    }
}