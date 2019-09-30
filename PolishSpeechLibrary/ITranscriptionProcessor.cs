using PolishSpeechLibrary.Model;

namespace PolishSpeechLibrary
{
    internal interface ITranscriptionProcessor
    {
        Transcription Process(Transcription source);
    }
}