using PolishSpeechLibrary.Model;

namespace PolishSpeechLibrary.IO
{
    public class SampaReader : ITranscriptionReader<string>
    {
        public Transcription Read(string sampaText)
        {
            Transcription transcription = Transcription.CreateSampaTranscription();

            foreach (var item in sampaText.Split(' '))
            {
                transcription.Add(ReadSampaSegment(item, transcription.Alphabet));
            }

            return transcription;
        }

        protected Segment ReadSampaSegment(string item, Alphabet alphabet)
        {
            var value = item.Trim();

            var segment = new Segment();

            if (value.StartsWith("#"))
            {
                value = value.Replace("#", "");
                segment.IsWordInitial = true;
                segment.IsProsodicWordInitial = true;
            }

            segment.Letter = alphabet.LetterByLabel(value);

            return segment;
        }
    }
}