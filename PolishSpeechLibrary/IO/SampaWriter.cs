using PolishSpeechLibrary.Model;
using System.Text;

namespace PolishSpeechLibrary.IO
{
    public class SampaWriter : ITranscriptionWriter<string>
    {
        public string Write(Transcription transcription)
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            foreach (var segment in transcription)
            {
                if (stringBuilder.Length != 0)
                {
                    stringBuilder.Append(" ");
                }
                stringBuilder.Append(WriteSegment(segment));
            }
            
            return stringBuilder.ToString();
        }

        private string WriteSegment(Segment segment)
        {
            string label = string.Empty;
            
            // add metadata
            if (segment.IsWordInitial || segment.IsProsodicWordInitial) { label += "#"; }
            if (segment.IsSyllableInitial) { label += "."; }
            if (segment.IsPrimaryWordAccent) { label += "\""; }

            label += segment.Label;

            return label;
        }
    }
}