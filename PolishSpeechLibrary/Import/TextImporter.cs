using PolishSpeechLibrary.Model;

namespace PolishSpeechLibrary.Import
{
    public class TextImporter : ITranscriptionImporter<string>
    {
        public Transcription Import(string text)
        {
            Transcription utterance = Transcription.CreateUnknownTranscription();

            foreach (var label in text)
            {
                utterance.Labels.Add(new Label(new Letter(label)));
            }

            return utterance;
        }
    }
}