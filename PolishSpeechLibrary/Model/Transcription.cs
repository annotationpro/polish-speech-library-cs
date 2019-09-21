using System;
using System.Collections.Generic;
using System.Text;

namespace PolishSpeechLibrary.Model
{
    public class Transcription : List<Label>
    {
        private Transcription(Alphabet alphabet)
        {
            this.Alphabet = alphabet;
        }

        public static Transcription CreateUnknownTranscription()
        {
            return new Transcription(new UnknownAlphabet());
        }

        public static Transcription CreateTranscription(AlphabetName name)
        {
            switch (name)
            {
                case AlphabetName.IPA:
                    return CreateIpaTranscription();
                case AlphabetName.Orthographic:
                    return CreateOrthographicTranscription();
                case AlphabetName.SAMPA:
                    return CreateSampaTranscription();
                default:
                    return CreateUnknownTranscription();
            }
        }

        private static Transcription CreateIpaTranscription()
        {
            return new Transcription(new IpaAlphabet());
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var label in this)
            {
                sb.AppendLine($"[{label.Letter.Value}]");
            }
            return sb.ToString();
        }
    }
}