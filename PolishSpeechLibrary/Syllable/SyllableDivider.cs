using PolishSpeechLibrary.Model;

namespace PolishSpeechLibrary.Syllable
{
    public class SyllableDivider : ITranscriptionProcessor
    {
        public Transcription Process(Transcription source)
        {
            Transcription result = Transcription.CreateUnknownTranscription();

            Segment currentSegment = null;
            string currentLabel = "";

            foreach (var segment in source)
            {
                if (currentSegment == null || segment.IsSyllableInitial)
                {
                    if (segment.IsSyllableInitial && currentSegment != null)
                    {
                        currentSegment.Letter = result.Alphabet.FindByLabelOrAddNew(currentLabel);
                    }

                    currentSegment = new Segment
                    {
                        Start = segment.Start,
                        Duration = 0,
                        IsSyllableInitial = true
                    };
                    result.Add(currentSegment);

                    currentLabel = "";
                }

                if (segment.IsPrimaryWordAccent) { currentSegment.IsPrimaryWordAccent = true; }

                currentSegment.Duration += segment.Duration;
                if (currentLabel != "") currentLabel += " ";
                currentLabel += segment.Label;
            }

            if(currentSegment != null)
            {
                currentSegment.Letter = result.Alphabet.FindByLabelOrAddNew(currentLabel);
            }

            return result;
        }
    }
}