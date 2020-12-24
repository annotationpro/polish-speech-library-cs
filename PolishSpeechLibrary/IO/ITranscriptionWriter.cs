using PolishSpeechLibrary.Model;

namespace PolishSpeechLibrary.IO
{
    public interface ITranscriptionWriter<TResult>
    {
        public TResult Write(Transcription transcription);
    }
}