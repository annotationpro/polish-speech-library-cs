using PolishSpeechLibrary.Model;

namespace PolishSpeechLibrary.Convert
{
    public interface ITranscriptionConverter
    {
        Transcription Convert(Transcription source);
    }
}