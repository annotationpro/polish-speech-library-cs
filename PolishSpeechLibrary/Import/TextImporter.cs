using PolishSpeechLibrary.Model;

namespace PolishSpeechLibrary.Import
{
    public class TextImporter : ITranscriptionImporter<string>
    {
        public Transcription Import(string text)
        {
            Transcription transcription = Transcription.CreateOrthographicTranscription();

            foreach (var label in text)
            {
                var letter = transcription.Alphabet.LetterByLabel(label.ToString());

                // skip letters not found in alphabet
                if (letter == null)
                {
                    continue;
                }

                transcription.Add(new Label(letter));
            }

            return transcription;
        }
    }
}