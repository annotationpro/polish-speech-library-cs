using System.Collections.Generic;
using System.Linq;

namespace PolishSpeechLibrary.Model
{
    public abstract class Alphabet
    {
        public abstract AlphabetName Name { get; }
        public abstract IList<Letter> Letters { get; }

        public Letter FindByLabelOrAddNew(string label)
        {
            var letter = Letters.FirstOrDefault(l => l.Value == label);

            if(letter == null)
            {
                letter = new Letter(label, ArticulationManner.GetAll().ByName("undefined"), ArticulationPlace.GetAll().ByName("undefined"), false, false);
                Letters.Add(letter);
            }

            return letter;
        }
    }
}