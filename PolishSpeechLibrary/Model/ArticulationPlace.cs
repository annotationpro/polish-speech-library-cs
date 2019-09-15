using System.Collections.Generic;

namespace PolishSpeechLibrary.Model
{
    public class ArticulationPlace
    {
        public ArticulationPlace()
        {
        }

        public ArticulationPlace(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public static IList<ArticulationPlace> GetAll()
        {
            return new List<ArticulationPlace>()
            {
                new ArticulationPlace(1, "sil"),
                new ArticulationPlace(2, "backvowel"),
                new ArticulationPlace(3, "frontvowel"),
                new ArticulationPlace(4, "bilabial"),
                new ArticulationPlace(5, "palatal"),
                new ArticulationPlace(6, "dental"),
                new ArticulationPlace(7, "labio-denta"),
                new ArticulationPlace(8, "velar"),
                new ArticulationPlace(9, "alveolar"),
                new ArticulationPlace(10, "tylnojęzykowa"),
                new ArticulationPlace(11, "alveolo-palatal"),
                new ArticulationPlace(12, "other")
            };
        }
    }
}