using PolishSpeechLibrary.Model;

namespace PolishSpeechLibrary
{
    public interface ITranscriptionProcessor
    {
        Transcription Process(Transcription source);
    }
}