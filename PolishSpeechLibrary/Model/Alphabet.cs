using System.Collections.Generic;

namespace PolishSpeechLibrary.Model
{
    public abstract class Alphabet
    {
        public abstract AlphabetName Name { get; }
        public abstract IList<Letter> Letters { get; }
    }
}