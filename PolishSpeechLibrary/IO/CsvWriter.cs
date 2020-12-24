using PolishSpeechLibrary.Model;
using System;
using System.Collections.Generic;

namespace PolishSpeechLibrary.IO
{
    public class CsvWriter : ITranscriptionWriter<IList<string>>
    {
        public IList<string> Write(Transcription transcription)
        {
            var lines = new List<string>();
            foreach (var segment in transcription)
            {
                lines.Add(WriteSegment(segment));
            }

            return lines;
        }

        private string WriteSegment(Segment segment)
        {
            return $"{segment.Start}\t{segment.Duration}\t{segment.Label}";
        }
    }
}