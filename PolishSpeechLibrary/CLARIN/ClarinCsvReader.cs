using PolishSpeechLibrary.Model;
using System;
using System.Globalization;
using System.IO;

namespace PolishSpeechLibrary.CLARIN
{
    public class ClarinCsvReader
    {
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

            foreach (var line in lines)
            {
                var segment = ReadClarinCsvLine(line, transcription.Alphabet);

                if (segment != null)
                {
                    transcription.Add(segment);
                }
            }

            return transcription;
        }

        private Segment ReadClarinCsvLine(string line, Alphabet alphabet)
        {
            string[] fields = line.Split('\t');

            if (fields.Length < 3) return null;

            var isWordInitial = fields.Length > 3 && fields[3] == "B";

            return new Segment()
            {
                Start = double.Parse(fields[0]),
                Duration = double.Parse(fields[1]),
                Letter = alphabet.LetterByLabel(fields[2]),
                IsWordInitial = isWordInitial,
                IsProsodicWordInitial = isWordInitial
            };
        }
    }
}