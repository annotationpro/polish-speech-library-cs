using PolishSpeechLibrary.Model;
using System;

namespace PolishSpeechLibrary.WordDetection
{
    public class WordDetectorProcessor : ITranscriptionProcessor
    {
        // v,z - ORTHO
        // f,s - SAMPA
        public Transcription Process(Transcription transcription)
        {
            if(transcription.Alphabet.Name != AlphabetName.Orthographic)
            {
                throw new FormatException("Can't detect orthographic words in other transcription type.");
            }


            Segment prevLabel, nextLabel;

            for (int index = 0; index < transcription.Count; index++)
            {
                var label = transcription[index];

                if (index >0)
                {
                    prevLabel = transcription[index - 1];
                }
                else
                {
                    prevLabel = null;
                }

                if(index<transcription.Count - 1)
                {
                    nextLabel = transcription[index + 1];
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

            return transcription;
        }
    }
}