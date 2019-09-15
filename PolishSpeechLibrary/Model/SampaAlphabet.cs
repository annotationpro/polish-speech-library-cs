using System.Collections.Generic;

namespace PolishSpeechLibrary.Model
{
    public class SampaAlphabet : Alphabet
    {
        private readonly IList<Letter> letters;

        public SampaAlphabet()
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
                new Letter(1, "#$p", manners.ById(1), places.ById(1), false, true ),
                new Letter(2, "#$pw", manners.ById(1), places.ById(1), false, true ),
                new Letter(3, "@", manners.ById(3), places.ById(8), false, false ),
                new Letter(4, "a", manners.ById(10), places.ById(2), true, false ),
                new Letter(5, "aj~", manners.ById(11), places.ById(12), true, false),
                new Letter(6, "b", manners.ById(3), places.ById(4), true, false ),
                new Letter(7, "c", manners.ById(3), places.ById(5), false, false ),
                new Letter(8, "d", manners.ById(3), places.ById(6), true, false ),
                new Letter(9, "d^z", manners.ById(4), places.ById(6), true, false ),
                new Letter(10, "d^z'", manners.ById(4), places.ById(5), true, false ),
                new Letter(11, "d^Z", manners.ById(4), places.ById(6), true, false ),
                new Letter(12, "e", manners.ById(10), places.ById(2), true, false ),
                new Letter(13, "ej~", manners.ById(11), places.ById(12), true, false ),
                new Letter(14, "ew~", manners.ById(11), places.ById(12), true, false ),
                new Letter(15, "f", manners.ById(2), places.ById(7), false, false ),
                new Letter(16, "g", manners.ById(3), places.ById(8), true, false ),
                new Letter(17, "i", manners.ById(10), places.ById(3), true, false ),
                new Letter(18, "j", manners.ById(6), places.ById(12), true, false ),
                new Letter(19, "J", manners.ById(3), places.ById(5), true, false ),
                new Letter(20, "k", manners.ById(3), places.ById(8), false, false ),
                new Letter(21, "l", manners.ById(8), places.ById(9), true, false ),
                new Letter(22, "m", manners.ById(5), places.ById(4), true, false ),
                new Letter(23, "n", manners.ById(5), places.ById(6), true, false ),
                new Letter(24, "n'", manners.ById(5), places.ById(5), true, false ),
                new Letter(25, "N", manners.ById(5), places.ById(10), true, false ),
                new Letter(26, "o", manners.ById(10), places.ById(2), true, false ),
                new Letter(27, "oj~", manners.ById(11), places.ById(12), true, false ),
                new Letter(28, "ow~", manners.ById(11), places.ById(12), true, false ),
                new Letter(29, "p", manners.ById(3), places.ById(4), false, false ),
                new Letter(30, "r", manners.ById(9), places.ById(9), true, false ),
                new Letter(31, "s", manners.ById(2), places.ById(6), false, false ),
                new Letter(32, "s'", manners.ById(2), places.ById(5), false, false ),
                new Letter(33, "S", manners.ById(2), places.ById(9), false, false ),
                new Letter(34, "t", manners.ById(3), places.ById(6), false, false ),
                new Letter(35, "t^s", manners.ById(4), places.ById(6), false, false ),
                new Letter(36, "t^s'", manners.ById(3), places.ById(5), false, false ),
                new Letter(37, "t^S", manners.ById(4), places.ById(9), false, false ),
                new Letter(38, "u", manners.ById(10), places.ById(3), true, false ),
                new Letter(39, "v", manners.ById(2), places.ById(7), true, false ),
                new Letter(40, "w", manners.ById(7), places.ById(12), true, false ),
                new Letter(41, "x", manners.ById(2), places.ById(8), false, false ),
                new Letter(42, "y", manners.ById(10), places.ById(3), true, false ),
                new Letter(43, "z", manners.ById(2), places.ById(6), true, false ),
                new Letter(44, "z'", manners.ById(2), places.ById(5), true, false ),
                new Letter(45, "Z", manners.ById(2), places.ById(9), true, false ),
                new Letter(46, "e~", manners.ById(11), places.ById(12), true, false ),
                new Letter(47, "o~", manners.ById(11), places.ById(12), true, false ),
            };
        }
    }
}