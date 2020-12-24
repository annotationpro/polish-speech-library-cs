using System.Collections.Generic;

namespace PolishSpeechLibrary.Model
{
    public class ClarinSampaAlphabet : Alphabet
    {
        private readonly IList<Letter> letters;

        public ClarinSampaAlphabet()
        {
            letters = GetAllLetters();
        }

        public override AlphabetName Name => AlphabetName.SAMPA;

        public override IList<Letter> Letters => letters;

        public static IList<Letter> GetAllLetters()
        {
            var manners = ArticulationManner.GetAll();
            var places = ArticulationPlace.GetAll();

            return new List<Letter>()
            {
                new Letter("#$p", manners.ById(1), places.ById(1), false, true ),
                new Letter("#$pw", manners.ById(1), places.ById(1), false, true ),
                new Letter("@", manners.ById(3), places.ById(8), false, false ),
                new Letter("a", manners.ById(10), places.ById(2), true, false ),
                new Letter("aj~", manners.ById(11), places.ById(12), true, false),
                new Letter("b", manners.ById(3), places.ById(4), true, false ),
                new Letter("c", manners.ById(3), places.ById(5), false, false ),
                new Letter("d", manners.ById(3), places.ById(6), true, false ),
                new Letter("dz", manners.ById(4), places.ById(6), true, false ),
                new Letter("dz'", manners.ById(4), places.ById(5), true, false ),
                new Letter("dZ", manners.ById(4), places.ById(6), true, false ),
                new Letter("e", manners.ById(10), places.ById(2), true, false ),
                new Letter("ej~", manners.ById(11), places.ById(12), true, false ),
                new Letter("ew~", manners.ById(11), places.ById(12), true, false ),
                new Letter("f", manners.ById(2), places.ById(7), false, false ),
                new Letter("g", manners.ById(3), places.ById(8), true, false ),
                new Letter("i", manners.ById(10), places.ById(3), true, false ),
                new Letter("j", manners.ById(6), places.ById(12), true, false ),
                new Letter("J", manners.ById(3), places.ById(5), true, false ),
                new Letter("k", manners.ById(3), places.ById(8), false, false ),
                new Letter("l", manners.ById(8), places.ById(9), true, false ),
                new Letter("m", manners.ById(5), places.ById(4), true, false ),
                new Letter("n", manners.ById(5), places.ById(6), true, false ),
                new Letter("n'", manners.ById(5), places.ById(5), true, false ),
                new Letter("N", manners.ById(5), places.ById(10), true, false ),
                new Letter("o", manners.ById(10), places.ById(2), true, false ),
                new Letter("oj~", manners.ById(11), places.ById(12), true, false ),
                new Letter("ow~", manners.ById(11), places.ById(12), true, false ),
                new Letter("p", manners.ById(3), places.ById(4), false, false ),
                new Letter("r", manners.ById(9), places.ById(9), true, false ),
                new Letter("s", manners.ById(2), places.ById(6), false, false ),
                new Letter("s'", manners.ById(2), places.ById(5), false, false ),
                new Letter("S", manners.ById(2), places.ById(9), false, false ),
                new Letter("t", manners.ById(3), places.ById(6), false, false ),
                new Letter("ts", manners.ById(4), places.ById(6), false, false ),
                new Letter("ts'", manners.ById(3), places.ById(5), false, false ),
                new Letter("tS", manners.ById(4), places.ById(9), false, false ),
                new Letter("u", manners.ById(10), places.ById(3), true, false ),
                new Letter("v", manners.ById(2), places.ById(7), true, false ),
                new Letter("w", manners.ById(7), places.ById(12), true, false ),
                new Letter("x", manners.ById(2), places.ById(8), false, false ),
                new Letter("I", manners.ById(10), places.ById(3), true, false ),
                new Letter("z", manners.ById(2), places.ById(6), true, false ),
                new Letter("z'", manners.ById(2), places.ById(5), true, false ),
                new Letter("Z", manners.ById(2), places.ById(9), true, false ),
                new Letter("e~", manners.ById(11), places.ById(12), true, false ),
                new Letter("o~", manners.ById(11), places.ById(12), true, false ),
            };
        }
    }
}