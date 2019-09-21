using System;

namespace PolishSpeechLibrary.Model
{
    public class Label
    {
        public Label()
        {
        }

        public Label(Letter letter)
        {
            this.Letter = letter;
        }

        public Label(Label label)
        {
            Copy(label, this);
    }

        public static void Copy(Label source, Label target)
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
        }

        public Label(double start, Letter letter)
        {
            this.Start = start;
            this.Duration = 0;
            this.Letter = letter;
        }

        public Label(double start, double duration, Letter letter)
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

        public override string ToString()
        {
            return Letter.ToString();
        }
    }
}