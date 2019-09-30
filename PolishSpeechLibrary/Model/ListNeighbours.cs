namespace PolishSpeechLibrary.Model
{
    public class ListNeighbourhs<TType>
    {
        public TType Prev { get; set; }
        public TType Next { get; set; }
    }
}