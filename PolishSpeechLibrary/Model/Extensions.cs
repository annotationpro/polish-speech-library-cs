using System.Collections.Generic;
using System.Linq;

namespace PolishSpeechLibrary.Model
{
    public static class Extensions
    {
        public static ArticulationManner ById(this IList<ArticulationManner> manners, int id)
        {
            return manners.FirstOrDefault(m => m.Id == id);
        }

        public static ArticulationManner ByName(this IList<ArticulationManner> manners, string name)
        {
            return manners.FirstOrDefault(m => m.Name == name);
        }

        public static ArticulationPlace ById(this IList<ArticulationPlace> places, int id)
        {
            return places.FirstOrDefault(m => m.Id == id);
        }

        public static ArticulationPlace ByName(this IList<ArticulationPlace> places, string name)
        {
            return places.FirstOrDefault(m => m.Name == name);
        }

        public static Letter LetterByLabel(this Alphabet alphabet, string label)
        {
            return alphabet.Letters.ByLabel(label);
        }

        public static Letter ByLabel(this IList<Letter> letters, string label)
        {
            return letters.FirstOrDefault(l => l.Value == label);
        }
    }
}