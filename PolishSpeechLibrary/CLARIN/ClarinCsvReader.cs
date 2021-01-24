using PolishSpeechLibrary.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace PolishSpeechLibrary.CLARIN
{
    public class ClarinCsvReader
    {
        IList<string> prosodicWordSingletons = new List<string>() { "f", "s", "v", "z" };

        public ClarinCsvReader()
        {
            InitializeCultureInfo();
        }

        private void InitializeCultureInfo()
        {
            CultureInfo cultureInfo = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
            CultureInfo.CurrentCulture = cultureInfo;
        }

        public Transcription ReadFile(string csvFilePath)
        {
            return Read(File.ReadAllLines(csvFilePath));
        }

        public Transcription Read(string content)
        {
            return Read(content.Split(Environment.NewLine));
        }

        public Transcription Read(string[] lines)
        {
            Transcription transcription = Transcription.CreateClarinSampaTranscription();


            Segment prevSegment = null;

            foreach (var line in lines)
            {
                var segment = ReadClarinCsvLine(line, transcription.Alphabet);

                if (segment != null)
                {
                    if(prevSegment != null)
                    {
                        // w domu, z domu, z klasy, w szkole prosodic only on first word
                        if(prevSegment.IsSingleton && prosodicWordSingletons.Contains(prevSegment.Label))
                        {
                            segment.IsProsodicWordInitial = false;
                        }
                    }
                    transcription.Add(segment);
                    prevSegment = segment;
                }
            }

            return transcription;
        }

        private Segment ReadClarinCsvLine(string line, Alphabet alphabet)
        {
            string[] fields = line.Split('\t');

            if (fields.Length < 3) return null;

            var isWordInitial = fields.Length > 3 && fields[3] == "B" || fields[3] == "S";
            var isSingleton = fields.Length > 3 && fields[3] == "S";

            var letter = alphabet.LetterByLabel(fields[2]);

            if(letter == null)
            {
                throw new KeyNotFoundException("There is no letter: " + fields[2] + " in alphabet");
            }

            return new Segment()
            {
                Start = double.Parse(fields[0]),
                Duration = double.Parse(fields[1]),
                Letter = letter,
                IsWordInitial = isWordInitial,
                IsProsodicWordInitial = isWordInitial,
                IsSingleton = isSingleton
            };
        }
    }
}