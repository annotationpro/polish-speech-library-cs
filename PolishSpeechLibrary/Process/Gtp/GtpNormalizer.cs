using System;
using System.Collections.Generic;
using System.Text;
using PolishSpeechLibrary.Model;

namespace PolishSpeechLibrary.Process.Gtp
{
    public class GtpNormalizer : ITranscriptionProcessor
    {
        public Transcription Process(Transcription source)
        {
            Transcription normalized = Transcription.CreateTranscription(source.Alphabet.Name);

            Label prevLabel = null;

            foreach (var label in source)
            {
                // skip repeated pauses
                if (label.Letter.IsPause && prevLabel!=null && prevLabel.Letter.IsPause)
                {
                    continue;
                }

                normalized.Add(new Label(label));

                prevLabel = label;
            }

            return normalized;
        }
    }
}
