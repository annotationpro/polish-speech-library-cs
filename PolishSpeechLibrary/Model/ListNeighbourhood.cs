namespace PolishSpeechLibrary.Model
{
    public class ListNeighbourhood<TType>
    {
        public TType Prev { get; set; }
        public TType Next { get; set; }
    }
}