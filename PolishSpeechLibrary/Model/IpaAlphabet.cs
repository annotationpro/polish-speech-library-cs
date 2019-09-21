using System.Collections.Generic;

namespace PolishSpeechLibrary.Model
{
    public class IpaAlphabet : Alphabet
    {
        private readonly IList<Letter> letters;

        public IpaAlphabet()
        {
            letters = GetAllLetters();
        }

        public override AlphabetName Name => AlphabetName.IPA;

        public override IList<Letter> Letters => letters;

        public static IList<Letter> GetAllLetters()
        {
            var manners = ArticulationManner.GetAll();
            var places = ArticulationPlace.GetAll();

            return new List<Letter>()
            {
                // todo add letters
            };
        }
    }
}