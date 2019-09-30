using PolishSpeechLibrary.Model;

namespace PolishSpeechLibrary
{
    public interface ITranscriptionImporter<TSource>
    {
        Transcription Import(TSource source);
    }
}