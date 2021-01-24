using System.Collections.Generic;

namespace PolishSpeechLibrary.CLARIN
{
    using PolishSpeechLibrary;
    using PolishSpeechLibrary.Model;

    public class ClarinToSampaConverter : ITranscriptionProcessor
    {
        public Dictionary<string, string> LetterConvert { get; private set; } = new Dictionary<string, string>();

        public ClarinToSampaConverter()
        {
            InitLetters();
        }

        private void InitLetters()
        {
            LetterConvert.Clear();

            LetterConvert.Add("a", "a");
            LetterConvert.Add("aj~", "aj~");
            LetterConvert.Add("b", "b");
            LetterConvert.Add("c", "c");
            LetterConvert.Add("d", "d");
            LetterConvert.Add("dz", "d^z");
            LetterConvert.Add("dz'", "d^z'");
            LetterConvert.Add("dZ", "d^Z");
            LetterConvert.Add("e", "e");
            LetterConvert.Add("ej~", "ej~");
            LetterConvert.Add("ew~", "ew~");
            LetterConvert.Add("f", "f");
            LetterConvert.Add("g", "g");
            LetterConvert.Add("i", "i");
            LetterConvert.Add("j", "j");
            LetterConvert.Add("J", "J");
            LetterConvert.Add("k", "k");
            LetterConvert.Add("k'", "c");
            LetterConvert.Add("l", "l");
            LetterConvert.Add("m", "m");
            LetterConvert.Add("n", "n");
            LetterConvert.Add("n'", "n'");
            LetterConvert.Add("N", "N");
            LetterConvert.Add("o", "o");
            LetterConvert.Add("oj~", "oj~");
            LetterConvert.Add("ow~", "ow~");
            LetterConvert.Add("p", "p");
            LetterConvert.Add("r", "r");
            LetterConvert.Add("s", "s");
            LetterConvert.Add("s'", "s'");
            LetterConvert.Add("S", "S");
            LetterConvert.Add("t", "t");
            LetterConvert.Add("ts", "t^s");
            LetterConvert.Add("ts'", "t^s'");
            LetterConvert.Add("tS", "t^S");
            LetterConvert.Add("u", "u");
            LetterConvert.Add("v", "v");
            LetterConvert.Add("w", "w");
            LetterConvert.Add("x", "x");
            LetterConvert.Add("x'", "x");
            LetterConvert.Add("I", "y");
            LetterConvert.Add("z", "z");
            LetterConvert.Add("z'", "z'");
            LetterConvert.Add("Z", "Z");
            LetterConvert.Add("e~", "e~");
            LetterConvert.Add("o~", "o~");
        }

        public Transcription Process(Transcription source)
        {
            Transcription result = Transcription.CreateSampaTranscription();

            foreach (var item in source)
            {
                var segment = new Segment(item)
                {
                    Letter = result.Alphabet.LetterByLabel(LetterConvert[item.Label])
                };
                result.Add(segment);
            }

            return result;
        }
    }
}