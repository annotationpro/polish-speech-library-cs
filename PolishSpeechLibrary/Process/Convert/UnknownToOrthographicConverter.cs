using PolishSpeechLibrary.Model;

namespace PolishSpeechLibrary.Process.Convert
{
    public class UnknownToOrthographicConverter : ITranscriptionProcessor
    {
        public Transcription Process(Transcription source)
        {
            var normalized = Transcription.CreateOrthographicTranscription();
            var alphabet = normalized.Alphabet;

            foreach (var label in source.Labels)
            {
                var letter = alphabet.LetterByLabel(label.Letter.Value);
                if (letter != null)
                {
                    normalized.Labels.Add(new Label(letter));
                }
            }

            return normalized;
        }
    }
}