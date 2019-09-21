using PolishSpeechLibrary.Model;
using PolishSpeechLibrary.Process;
using PolishSpeechLibrary.Process.Convert;
using PolishSpeechLibrary.Process.Gtp;
using PolishSpeechLibrary.Process.Import;
using PolishSpeechLibrary.Process.WordDetection;
using System;
using System.IO;
using System.Linq;
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
                Console.WriteLine("2. Import Text");
                Console.WriteLine("3. Detect Words");
                Console.WriteLine("4. Load Gtp Rules");
                Console.WriteLine("5. Save Gtp Rules");

                Console.WriteLine();
                Console.Write("Choose operation and press ENTER: ");

                operation = Console.ReadLine();

                if (operation == "1")
                {
                    ExportSampaAlphabet();
                }
                else if (operation == "2")
                {
                    var text = ImportText();
                    Console.Write(text);
                    Console.ReadLine();
                }
                else if (operation == "3")
                {
                    var orthographic = ImportText();
                    var detected = new WordDetectorProcessor().Process(orthographic);
                    Console.Write(detected);
                    Console.ReadLine();
                }
                else if (operation == "4")
                {
                    var rules = GtpProcessor.LoadGtpRulesFromXml("./GtpRules.xml");
                    
                    foreach (var rule in rules.Take(10))
                    {
                        rule.WriteToConsole();
                        Console.WriteLine();
                    }
                    Console.WriteLine("...");
                    Console.WriteLine($"File contains {rules.Count} rules.");
                    Console.ReadLine();
                }
                else if (operation == "5")
                {
                    var rules = GtpProcessor.LoadGtpRulesFromXml("./GtpRules.xml");
                    GtpProcessor.SaveGtpRules("./GtpRules.json", rules);
                    Console.WriteLine($"Rules ({rules.Count}) saved to file 'GtpRules.json'");
                    Console.ReadLine();
                }

            } while (operation != "0");
        }

        private static Transcription ImportText()
        {
            string text = "Ogólnie znana teza głosi, iż użytkownika może rozpraszać zrozumiała zawartość strony, kiedy ten chce zobaczyć sam jej wygląd.";
            var unknown = new TextImporter().Import(text);
            var normalized = new UnknownToOrthographicConverter().Process(unknown);
            return normalized;
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
