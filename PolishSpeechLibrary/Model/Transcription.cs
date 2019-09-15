using System.Collections.Generic;

namespace PolishSpeechLibrary.Model
{
    public class Transcription
    {
        private Transcription(Alphabet alphabet)
        {
            this.Alphabet = alphabet;
        }

        public static Transcription CreateUnknownTranscription()
        {
            return new Transcription(new UnknownAlphabet());
        }

        public static Transcription CreateOrthographicTranscription()
        {
            return new Transcription(new OrthographicAlphabet());
        }

        public static Transcription CreateSampaTranscription()
        {
            return new Transcription(new SampaAlphabet());
        }

        public Alphabet Alphabet { get; set; }
        public IList<Label> Labels { get; set; } = new List<Label>();
    }
}