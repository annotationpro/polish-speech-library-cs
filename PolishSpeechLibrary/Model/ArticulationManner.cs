using System.Collections.Generic;

namespace PolishSpeechLibrary.Model
{
    public class ArticulationManner
    {
        public ArticulationManner()
        {
        }

        public ArticulationManner(int id, string name, bool isVowel)
        {
            Id = id;
            Name = name;
            IsVowel = isVowel;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsVowel { get; set; }

        public static IList<ArticulationManner> GetAll()
        {
            return new List<ArticulationManner>()
            {
                new ArticulationManner(1, "sil", false),
                new ArticulationManner(2, "fricative", false),
                new ArticulationManner(3, "stop", false),
                new ArticulationManner(4, "affricate", false),
                new ArticulationManner(5, "nasal", false),
                new ArticulationManner(6, "j", false),
                new ArticulationManner(7, "w", false),
                new ArticulationManner(8, "l", false),
                new ArticulationManner(9, "r", false),
                new ArticulationManner(10, "vowel", true),
                new ArticulationManner(11, "diphtong", true),
            };
        }
    }
}