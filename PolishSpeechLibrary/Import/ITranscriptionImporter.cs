using PolishSpeechLibrary.Model;

namespace PolishSpeechLibrary.Import
{
    public interface ITranscriptionImporter<TSource>
    {
        Transcription Import(TSource source);
    }
}