using System.Collections.Generic;

namespace PolishSpeechLibrary.Model
{
    public class UnknownAlphabet : Alphabet
    {
        public override AlphabetName Name => AlphabetName.Unknown;

        public override IList<Letter> Letters => new List<Letter>();
    }
}