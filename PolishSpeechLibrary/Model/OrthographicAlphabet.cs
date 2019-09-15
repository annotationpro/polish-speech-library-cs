using System.Collections.Generic;

namespace PolishSpeechLibrary.Model
{
    public class OrthographicAlphabet : Alphabet
    {
        private readonly IList<Letter> letters;

        public override AlphabetName Name => AlphabetName.Orthographic;
        public override IList<Letter> Letters => letters;

        public OrthographicAlphabet()
        {
            letters = GetAllLetters();
        }

        private IList<Letter> GetAllLetters()
        {
            return new List<Letter>()
            {
                new Letter(0, " ", null, null, false, true),
                new Letter(1, "a", null, null, false, false),
                new Letter(2, "ą", null, null, false, false),
                new Letter(3, "b", null, null, false, false),
                new Letter(4, "c", null, null, false, false),
                new Letter(5, "ć", null, null, false, false),
                new Letter(6, "d", null, null, false, false),
                new Letter(7, "e", null, null, false, false),
                new Letter(8, "ę", null, null, false, false),
                new Letter(9, "f", null, null, false, false),
                new Letter(10, "g", null, null, false, false),
                new Letter(11, "h", null, null, false, false),
                new Letter(12, "i", null, null, false, false),
                new Letter(13, "j", null, null, false, false),
                new Letter(14, "k", null, null, false, false),
                new Letter(15, "l", null, null, false, false),
                new Letter(16, "ł", null, null, false, false),
                new Letter(17, "m", null, null, false, false),
                new Letter(18, "n", null, null, false, false),
                new Letter(19, "ń", null, null, false, false),
                new Letter(20, "o", null, null, false, false),
                new Letter(21, "ó", null, null, false, false),
                new Letter(22, "p", null, null, false, false),
                new Letter(23, "q", null, null, false, false),
                new Letter(24, "r", null, null, false, false),
                new Letter(25, "s", null, null, false, false),
                new Letter(26, "ś", null, null, false, false),
                new Letter(27, "t", null, null, false, false),
                new Letter(28, "u", null, null, false, false),
                new Letter(29, "v", null, null, false, false),
                new Letter(30, "w", null, null, false, false),
                new Letter(31, "x", null, null, false, false),
                new Letter(32, "y", null, null, false, false),
                new Letter(33, "z", null, null, false, false),
                new Letter(34, "ź", null, null, false, false),
                new Letter(35, "ż", null, null, false, false),
                new Letter(36, "A", null, null, false, false),
                new Letter(37, "Ą", null, null, false, false),
                new Letter(38, "B", null, null, false, false),
                new Letter(39, "C", null, null, false, false),
                new Letter(40, "Ć", null, null, false, false),
                new Letter(41, "D", null, null, false, false),
                new Letter(42, "E", null, null, false, false),
                new Letter(43, "Ę", null, null, false, false),
                new Letter(44, "F", null, null, false, false),
                new Letter(45, "G", null, null, false, false),
                new Letter(46, "H", null, null, false, false),
                new Letter(47, "I", null, null, false, false),
                new Letter(48, "J", null, null, false, false),
                new Letter(49, "K", null, null, false, false),
                new Letter(50, "L", null, null, false, false),
                new Letter(51, "Ł", null, null, false, false),
                new Letter(52, "M", null, null, false, false),
                new Letter(53, "N", null, null, false, false),
                new Letter(54, "Ń", null, null, false, false),
                new Letter(55, "O", null, null, false, false),
                new Letter(56, "Ó", null, null, false, false),
                new Letter(57, "P", null, null, false, false),
                new Letter(58, "Q", null, null, false, false),
                new Letter(59, "R", null, null, false, false),
                new Letter(60, "S", null, null, false, false),
                new Letter(61, "Ś", null, null, false, false),
                new Letter(62, "T", null, null, false, false),
                new Letter(63, "U", null, null, false, false),
                new Letter(64, "V", null, null, false, false),
                new Letter(65, "W", null, null, false, false),
                new Letter(66, "X", null, null, false, false),
                new Letter(67, "Y", null, null, false, false),
                new Letter(68, "Z", null, null, false, false),
                new Letter(69, "Ź", null, null, false, false),
                new Letter(70, "Ż", null, null, false, false),
                //new Letter(71, "!", null, null, false, false),
                //new Letter(72, "@", null, null, false, false),
                //new Letter(73, "#", null, null, false, false),
                //new Letter(74, "$", null, null, false, false),
                //new Letter(75, "%", null, null, false, false),
                //new Letter(76, "%", null, null, false, false),
                //new Letter(77, "(", null, null, false, false),
                //new Letter(78, ")", null, null, false, false),
                //new Letter(79, "-", null, null, false, false),
                //new Letter(80, "+", null, null, false, false),
                //new Letter(81, "=", null, null, false, false),
                //new Letter(82, "{", null, null, false, false),
                //new Letter(83, "}", null, null, false, false),
                //new Letter(84, "[", null, null, false, false),
                //new Letter(85, "]", null, null, false, false),
                //new Letter(86, ":", null, null, false, false),
                //new Letter(87, ";", null, null, false, false),
                //new Letter(88, "\"", null, null, false, false),
                //new Letter(89, "'", null, null, false, false),
                //new Letter(90, "?", null, null, false, false),
                //new Letter(91, "/", null, null, false, false),
                //new Letter(92, "\\", null, null, false, false),
                //new Letter(93, "<", null, null, false, false),
                //new Letter(94, ">", null, null, false, false),
                //new Letter(95, ",", null, null, false, false),
                //new Letter(96, ".", null, null, false, false),
            };
        }
    }
}