namespace PolishSpeechLibrary.Model
{
    public class Segment
    {
        public Segment()
        {
        }

        public Segment(Letter letter)
        {
            this.Letter = letter;
        }

        public Segment(Segment segment)
        {
            Copy(segment, this);
        }

        public static void Copy(Segment source, Segment target)
        {
            target.Start = source.Start;
            target.Duration = source.Duration;
            target.Letter = source.Letter;
            target.IsSyllableInitial = source.IsSyllableInitial;
            target.IsWordInitial = source.IsWordInitial;
            target.IsProsodicWordInitial = source.IsProsodicWordInitial;
            target.IsPhraseInitial = source.IsPhraseInitial;
            target.IsPrimaryWordAccent = source.IsPrimaryWordAccent;
            target.IsSecondaryWordAccent = source.IsSecondaryWordAccent;
            target.IsPrimaryPhraseAccent = source.IsPrimaryPhraseAccent;
            target.IsSecondaryPhraseAccent = source.IsSecondaryPhraseAccent;
            target.IsNotFound = source.IsNotFound;
        }

        public Segment(double start, Letter letter)
        {
            this.Start = start;
            this.Duration = 0;
            this.Letter = letter;
        }

        public Segment(double start, double duration, Letter letter)
        {
            this.Start = start;
            this.Duration = duration;
            this.Letter = letter;
        }

        public double Start { get; set; } = 0;
        public double End => Start + Duration;
        public double Duration { get; set; } = 0;
        public Letter Letter { get; set; }
        public bool IsSyllableInitial { get; set; }
        public bool IsWordInitial { get; set; }
        public bool IsProsodicWordInitial { get; set; }
        public bool IsPhraseInitial { get; set; }
        public bool IsPrimaryWordAccent { get; set; }
        public bool IsSecondaryWordAccent { get; set; }
        public bool IsPrimaryPhraseAccent { get; set; }
        public bool IsSecondaryPhraseAccent { get; set; }
        public bool IsNotFound { get; set; }

        public override string ToString()
        {
            string val = Letter.ToString();
            if (IsPrimaryWordAccent) val = "\"" + val;
            if (IsSyllableInitial) val = "." + val;
            if (IsProsodicWordInitial || IsWordInitial) val = "#" + val;
            return val;
        }

        public string Label { get { return Letter.Value; } }
        public bool IsVoice { get { return Letter.IsVoice; } }
        public bool IsPause { get { return Letter.IsPause; } }
        public bool IsVowel { get { return Letter.ArticulationManner.IsVowel; } }
    }
}