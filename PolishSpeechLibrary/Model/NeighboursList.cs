namespace PolishSpeechLibrary.Model
{
    public class NeighbourhsList<TType>
    {
        public TType Prev { get; set; }
        public TType Next { get; set; }
    }
}