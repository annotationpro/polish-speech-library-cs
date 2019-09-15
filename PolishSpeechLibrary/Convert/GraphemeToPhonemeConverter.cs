using PolishSpeechLibrary.Model;

namespace PolishSpeechLibrary.Convert
{
    public class GraphemeToPhonemeConverter : ITranscriptionConverter
    {
        public Transcription Convert(Transcription source)
        {
            var result = Transcription.CreateSampaTranscription();

            // gtp here

            return result;
        }
    }
}