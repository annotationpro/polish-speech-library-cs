using PolishSpeechLibrary.Convert;
using PolishSpeechLibrary.Import;
using PolishSpeechLibrary.Model;
using System;
using System.IO;
using System.Text;

namespace PolishSpeechLibrary.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var operation = "";
            do
            {
                Console.Clear();
                Console.WriteLine("----------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Polish Speech Library Tester");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("----------------------------------");
                Console.WriteLine("0. Exit application ");
                Console.WriteLine("1. Export SAMPA alphabet");
                Console.WriteLine("2. Test TextImporter");

                Console.WriteLine();
                Console.Write("Choose operation and press ENTER: ");

                operation = Console.ReadLine();

                if(operation == "1")
                {
                    ExportSampaAlphabet();
                }else if(operation == "2")
                {
                    TestTextImporter();
                }


            } while (operation != "0");
        }

        private static void TestTextImporter()
        {
            string text = "Ogólnie znana teza głosi, iż użytkownika może rozpraszać zrozumiała zawartość strony, kiedy ten chce zobaczyć sam jej wygląd.";
            var unknown = new TextImporter().Import(text);
            var normalized = new UnknownToOrthographicConverter().Convert(unknown);
        }

        private static void ExportSampaAlphabet()
        {
            var sampa = SampaAlphabet.GetAllLetters();
            StringBuilder sb = new StringBuilder();
            foreach (var letter in sampa)
            {
                var line = $"{letter.Id} \t {letter.Value} \t {letter.ArticulationManner.Name} \t\t {letter.ArticulationPlace.Name}";
                sb.AppendLine(line);
                Console.WriteLine(line);
            }
            File.WriteAllText("c:\\Projekty\\Sampa.csv", sb.ToString());
        }
    }
}
