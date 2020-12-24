using PolishSpeechLibrary.Model;

namespace PolishSpeechLibrary.IO
{
    public class OrthorgraphicTranscriptionReader : ITranscriptionReader<string>
    {
        public Transcription Read(string text)
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

                transcription.Add(new Segment(letter));
            }

            return transcription;
        }
    }
}