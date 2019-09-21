using PolishSpeechLibrary.Model;

namespace PolishSpeechLibrary.Process
{
    internal interface ITranscriptionProcessor
    {
        Transcription Process(Transcription source);
    }
}