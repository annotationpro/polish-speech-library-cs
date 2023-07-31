using System;
using System.Collections.Generic;
using System.Text;

namespace PolishSpeechLibrary.Model
{
    public class Transcription : List<Segment>
    {
        public Alphabet Alphabet { get; private set; }

        private Transcription(Alphabet alphabet)
        {
            Alphabet = alphabet;
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

                case AlphabetName.ClarinSampa:
                    return CreateClarinSampaTranscription();

                case AlphabetName.Unknown:
                default:
                    return CreateUnknownTranscription();
            }
        }

        public static Transcription CreateTranscription(Alphabet alphabet)
        {
            return new Transcription(alphabet);
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

        public static Transcription CreateClarinSampaTranscription()
        {
            return new Transcription(new ClarinSampaAlphabet());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var label in this)
            {
                if (this.IndexOf(label) > 0)
                {
                    sb.Append(" ");
                }
                var wordInitial = label.IsProsodicWordInitial ? "#" : "";
                //var wordInitial = label.IsWordInitial ? "#" : "";
                var syllableInitial = label.IsSyllableInitial ? "." : "";
                sb.Append($"{wordInitial}{syllableInitial}{label.Letter.Value}");
            }
            return sb.ToString();
        }

        public void WriteToConsole()
        {
            foreach (var label in this)
            {
                if (this.IndexOf(label) > 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" ");
                }

                if (label.IsNotFound)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.Write(label.ToString());

                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}