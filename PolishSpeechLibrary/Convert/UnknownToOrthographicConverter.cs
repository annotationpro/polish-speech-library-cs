using PolishSpeechLibrary.Model;

namespace PolishSpeechLibrary.Convert
{
    public class UnknownToOrthographicConverter : ITranscriptionConverter
    {
        public Transcription Convert(Transcription source)
        {
            var normalized = Transcription.CreateOrthographicTranscription();
            var alphabet = normalized.Alphabet;

            foreach (var label in source.Labels)
            {
                var letter = alphabet.LetterByLabel(label.Letter.Value);
                if (letter != null)
                {
                    normalized.Labels.Add(label);
                }
            }

            return normalized;
        }
    }
}