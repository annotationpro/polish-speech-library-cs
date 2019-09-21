using PolishSpeechLibrary.Model;

namespace PolishSpeechLibrary.Process
{
    public interface ITranscriptionImporter<TSource>
    {
        Transcription Import(TSource source);
    }
}