using PolishSpeechLibrary.Model;
using System;
using System.Collections.Specialized;

namespace PolishSpeechLibrary.Syllable
{
    public class SyllableDetector : ITranscriptionProcessor
    {
        public SyllablePatternCollection Patterns { get; private set; }
        public StringDictionary PatternDictionary { get; private set; } = new StringDictionary();

        public SyllableDetector(SyllablePatternCollection syllablePatterns)
        {
            InitializeSyllablePatterns(syllablePatterns);
        }

        private void InitializeSyllablePatterns(SyllablePatternCollection syllablePatterns)
        {
            Patterns = syllablePatterns;

            // Wypełnienie mapy Pattern.Index, przyspieszy szukanie Pattern
            // podajemy bez znaczka podziału: |

            PatternDictionary.Clear();

            for (int nIndex = 0; nIndex < this.Patterns.Count; nIndex++)
            {
                string sPattern = this.Patterns[nIndex].Pattern;
                sPattern = sPattern.Replace("|", "");
                PatternDictionary[sPattern] = nIndex.ToString();
            }
        }

        public Transcription Process(Transcription source)
        {
            if (PatternDictionary.Count == 0)
            {
                return null;
            }

            // pojemnij bez pauz
            Transcription utterance = Transcription.CreateSampaTranscription();

            // Cała wypowiedź tekstowo i wypowiedź bez pauz
            string sFullUtterace = string.Empty;
            foreach (Segment segment in source)
            {
                if (segment.IsProsodicWordInitial)
                    sFullUtterace += " ";
                sFullUtterace += segment.Label;
                if (!segment.IsPause)
                {
                    utterance.Add(segment);
                }
            }

            // Tymczasowe pojemniki
            string sUtterance = string.Empty;
            string sStandardUtterance = string.Empty;
            string sInfo = string.Empty;

            // Zmienne kontrolne
            bool bIsPattern = false;

            // Pozycje sylab
            //ArrayList SyllablePositions;

            // Iteracja wypowiedzi
            for (int nIndex = 0; nIndex < utterance.Count; nIndex++)
            {
                Segment segment = utterance[nIndex];

                //////////////////////////////////////////////////////////////////
                // Budowanie paternu

                if (segment.IsProsodicWordInitial)
                    sInfo += " ";
                sInfo += segment.Label;

                if (segment.IsProsodicWordInitial)
                { // nowy wyraz
                    if (sUtterance.Length > 0)
                    { // usunięcie końcówki poprzedniego
                        sUtterance = string.Empty;
                        sStandardUtterance = string.Empty;
                    }
                    segment.IsSyllableInitial = true;
                    if (segment.IsVowel)
                    {
                        sUtterance += "V";
                        sStandardUtterance += "V";
                    }
                }
                else
                { // budowanie patternu
                    if (sUtterance.Length == 0 && segment.IsVowel)
                    { // Początek
                        if (nIndex < utterance.Count - 1)
                        {
                            // tylko jeśli to nie jest ostatnia w wyrazie
                            if (!utterance[nIndex + 1].IsProsodicWordInitial)
                            {
                                sUtterance += "V";
                                sStandardUtterance += "V";
                            }
                        }
                    }
                    else if (sUtterance.Length > 0 && !segment.IsVowel)
                    { // Środek
                        sUtterance += segment.Label; sStandardUtterance += "C";
                    }
                    else if (sUtterance.Length > 0 && segment.IsVowel)
                    { // Koniec
                        sUtterance += "V"; sStandardUtterance += "V";
                        bIsPattern = true;
                    }
                }

                ///////////////////////////////////////////////////////////
                // podział z użyciem wzorców patternów

                if (bIsPattern)
                {
                    // Sprawdzam czy nie jest to podział standardowy
                    int nPhoneIndex = nIndex;

                    if (sStandardUtterance == "VV" || sStandardUtterance == "VCV")
                    {
                        if (sStandardUtterance == "VCV")
                            nPhoneIndex--;
                        utterance[nPhoneIndex].IsSyllableInitial = true;
                        //SyllablePositions.Add(nPhoneIndex);
                    }
                    else
                    {
                        string sPatternIndex = string.Empty;

                        if (PatternDictionary.ContainsKey(sUtterance))
                        {
                            sPatternIndex = PatternDictionary[sUtterance];
                        }
                        else
                        {
                            /* TODO
                            while( !patternDictionary.ContainsKey( sUtterance ) ) {
                              PatternForm form = new PatternForm();
                              form.Utterance.Text = sFullUtterace;
                              form.Pattern.Text = sUtterance;
                              form.StandardPattern.Text = sStandardUtterance;
                              Windows.Forms.DialogResult result = form.ShowDialog();
                              if( result != Windows.Forms.DialogResult.OK )
                                return false;
                              SyllablePattern p = new SyllablePattern();
                              p.Pattern = form.Pattern.Text;
                              p.StandardPattern = form.StandardPattern.Text;
                              string sPat = p.Pattern;
                              sPat = sPat.Replace( "|", "" );
                              patternDictionary[sPat] = this.Patterns.Add( p ).ToString();
                            }
                            */
                        }

                        // Obliczenie położenia podziału
                        int nPatternIndex = Convert.ToInt32(sPatternIndex);

                        SyllablePattern p = Patterns[nPatternIndex];

                        int nDividePos = p.StandardPattern.IndexOf("|");
                        if (nDividePos == -1)
                        {
                            throw new Exception("Pattern: " + sUtterance + " (" + sStandardUtterance + ") doesn't include syllable division mark '|'.");
                        }
                        else
                        {
                            int nCount = 0;
                            while (nDividePos != -1)
                            {
                                nPhoneIndex = nIndex - sStandardUtterance.Length + nDividePos + 1 - nCount;
                                utterance[nPhoneIndex].IsSyllableInitial = true;
                                //SyllablePositions.Add(nPhoneIndex);
                                if (nDividePos == p.StandardPattern.Length - 1)
                                    break;
                                nDividePos = p.StandardPattern.IndexOf("|", nDividePos + 1);
                                nCount++;
                            }
                        }
                    }

                    // Zaznaczenie podziału sylaby
                    if (segment.IsVowel && nIndex < utterance.Count - 1)
                    {
                        Segment p = utterance[nIndex + 1];
                        if (!p.IsProsodicWordInitial)
                        {
                            sUtterance = "V";
                            sStandardUtterance = "V";
                        }
                        else
                        {
                            sUtterance = string.Empty;
                            sStandardUtterance = string.Empty;
                        }
                    }
                    bIsPattern = false;
                }
            }

            return utterance;
        }
    }
}