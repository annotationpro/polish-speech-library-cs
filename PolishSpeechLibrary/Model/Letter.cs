namespace PolishSpeechLibrary.Model
{
    public class Letter
    {
        public Letter()
        {
        }

        public Letter(string value)
        {
            Value = value;
        }

        public Letter(char value)
        {
            Value = value.ToString();
        }

        public Letter(int id, string value)
        {
            Id = id;
            Value = value;
        }

        public Letter(int id, string value, ArticulationManner articulationManner, ArticulationPlace articulationPlace, bool isVoice, bool isPause)
        {
            Id = id;
            Value = value;
            ArticulationManner = articulationManner;
            ArticulationPlace = articulationPlace;
            IsVoice = isVoice;
            IsPause = isPause;
        }

        public int Id { get; set; }
        public string Value { get; set; }
        public ArticulationManner ArticulationManner { get; set; }
        public ArticulationPlace ArticulationPlace { get; set; }
        public bool IsVoice { get; set; } = false;
        public bool IsPause { get; set; } = false;

        public override string ToString()
        {
            return Value;
        }
    }
}