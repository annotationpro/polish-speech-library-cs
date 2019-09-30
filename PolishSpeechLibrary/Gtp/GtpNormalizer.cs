using PolishSpeechLibrary.Model;
using System.Linq;

namespace PolishSpeechLibrary.Gtp
{
    public class GtpNormalizer : ITranscriptionProcessor
    {
        public Transcription Process(Transcription source)
        {
            Transcription normalized = Transcription.CreateTranscription(source.Alphabet.Name);

            foreach (var label in source)
            {
                var neigbours = source.GetNighbours(label);

                // skip start, repeated and end pauses
                if (label.Letter.IsPause &&
                    (neigbours.Prev == null ||
                    neigbours.Prev.Letter.IsPause ||
                    neigbours.Next == null))
                {
                    continue;
                }

                normalized.Add(new Label(label));
            }

            // remove last pause
            var last = normalized.LastOrDefault();
            if (last != null && last.Letter.IsPause)
            {
                normalized.Remove(last);
            }

            return normalized;
        }
    }
}