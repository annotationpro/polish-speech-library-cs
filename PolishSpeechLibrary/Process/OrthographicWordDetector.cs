using PolishSpeechLibrary.Model;
using System;

namespace PolishSpeechLibrary.Process
{
    public class OrthographicWordDetector : ITranscriptionProcessor
    {
        // v,z - ORTHO
        // f,s - SAMPA
        public void Process(Transcription transcription)
        {
            if(transcription.Alphabet.Name != AlphabetName.Orthographic)
            {
                throw new FormatException("Can't detect orthographic words in other transcription type.");
            }


        }
    }
}