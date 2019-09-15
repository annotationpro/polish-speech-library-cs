using PolishSpeechLibrary.Model;

namespace PolishSpeechLibrary.Process
{
    internal interface ITranscriptionProcessor
    {
        void Process(Transcription transcription);
    }
}