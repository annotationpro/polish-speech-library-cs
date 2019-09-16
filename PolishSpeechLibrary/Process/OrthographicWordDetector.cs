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


            Label prevLabel, nextLabel;

            for (int index = 0; index < transcription.Labels.Count; index++)
            {
                var label = transcription.Labels[index];

                if (index >0)
                {
                    prevLabel = transcription.Labels[index - 1];
                }
                else
                {
                    prevLabel = null;
                }

                if(index<transcription.Labels.Count - 1)
                {
                    nextLabel = transcription.Labels[index + 1];
                }
                else
                {
                    nextLabel = null;
                }

                // word initial
                if((prevLabel == null || prevLabel.Letter.IsPause) && !label.Letter.IsPause)
                {
                    label.IsWordInitial = true;

                    // prosodic word initial
                    if((nextLabel != null || nextLabel.Letter.IsPause) 
                        && (label.Letter.Value.ToLower() == "w" || label.Letter.Value.ToLower() == "z"))
                    {
                        label.IsProsodicWordInitial = true;
                    }
                }
            }
        }
    }
}