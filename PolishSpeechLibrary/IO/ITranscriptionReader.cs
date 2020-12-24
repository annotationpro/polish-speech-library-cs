using PolishSpeechLibrary.Model;

namespace PolishSpeechLibrary.IO
{
    public interface ITranscriptionReader<TSource>
    {
        Transcription Read(TSource source);
    }
}