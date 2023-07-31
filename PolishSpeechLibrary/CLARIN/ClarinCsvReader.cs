using PolishSpeechLibrary.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

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

        public Transcription ReadFile(string csvFilePath, string wordsFilePath = null)
        {
            if (string.IsNullOrEmpty(wordsFilePath))
            {
                return Read(File.ReadAllLines(csvFilePath), null);
            }
            else
            {
                return Read(File.ReadAllLines(csvFilePath), File.ReadAllLines(wordsFilePath));
            }
        }

        private Segment FindWordForPhonemeSegment(string[] wordLines, Segment segment)
        {
            return wordLines.Select(wordLine => ReadClarinCsvLine(wordLine))
                .FirstOrDefault(w => Math.Abs(w.Start - segment.Start) < 0.01);
        }

        /// <summary>
        /// Read lines with clarin data
        /// </summary>
        /// <param name="lines">Data with phonemes annotation</param>
        /// <param name="words">Optional data with words segmentation, to fix phonemes with word initial information</param>
        /// <returns>Transcription with clarin segments</returns>
        public Transcription Read(string[] lines, string[] words)
        {
            Transcription transcription = Transcription.CreateClarinSampaTranscription();

            Segment prevSegment = null;

            foreach (var line in lines)
            {
                var segment = ReadClarinCsvLine(line, transcription.Alphabet);

                // fix output.csv using words.csv
                if(words != null)
                {
                    Segment word = FindWordForPhonemeSegment(words, segment);
                    if (word != null)
                    {
                        segment.IsWordInitial = true;
                        segment.IsProsodicWordInitial = true;
                        if (word.Label.Length == 1)
                        {
                            segment.IsSingleton = true;
                        }
                    }
                }

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
        private Segment ReadClarinCsvLine(string line)
        {
            return ReadClarinCsvLine(line, null);
        }

        private Segment ReadClarinCsvLine(string line, Alphabet alphabet)
        {
            string[] fields = line.Split('\t');

            if (fields.Length < 3) return null;

            var isWordInitial = fields.Length > 3 && (fields[3] == "B" || fields[3] == "S");
            var isSingleton = fields.Length > 3 && fields[3] == "S";

            Letter letter;
            if (alphabet == null)
            {
                letter = new Letter(fields[2]);
            }
            else
            {
                letter = alphabet.LetterByLabel(fields[2]);

                if (letter == null)
                {
                    throw new KeyNotFoundException("There is no letter: " + fields[2] + " in alphabet");
                }
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