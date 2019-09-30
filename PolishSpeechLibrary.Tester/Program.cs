using PolishSpeechLibrary.Model;
using PolishSpeechLibrary.Gtp;
using PolishSpeechLibrary.Import;
using PolishSpeechLibrary.WordDetection;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

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
                Console.WriteLine("4. Load Gtp Rules XML");
                Console.WriteLine("5. Convert Gtp Rules XML->JSON");
                Console.WriteLine("6. GTP");

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
                    var rules = new GtpRulesXmlReaderWriter().LoadGtpRules("./GtpRules.xml");
                    
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
                    var xmlWriter = new GtpRulesXmlReaderWriter();
                    var rules = xmlWriter.LoadGtpRules("./GtpRules.xml");                    
                    var jsonWriter = new GtpRulesJsonReaderWriter();
                    jsonWriter.SaveGtpRules("./GtpRules.json", rules);
                    Console.WriteLine($"Rules ({rules.Count}) saved to file 'GtpRules.json'");
                    Console.ReadLine();
                }
                else if (operation == "6")
                {
                    Console.Write($"Loading rules...");
                    var readerWriter = new GtpRulesJsonReaderWriter();
                    var rules = readerWriter.LoadGtpRules("./GtpRules.json");
                    Console.WriteLine($"OK");

                    var texts = new List<string> {
                        "to jest ala ładna kobyła",
                        "była dziewczyna nosi nocnik",
                        "legendarny słoń walczy z pniaczkiem"
                    };

                    foreach (var text in texts)
                    {
                        var orthographic = new TextImporter().Import(text);
                        Console.WriteLine($"IN : {orthographic}");
                        
                        var phonemes = new GtpProcessor(rules).Process(orthographic);
                        Console.Write("OUT: ");
                        phonemes.WriteToConsole();
                        Console.WriteLine();
                    }

                    var inputText = string.Empty;
                    do
                    {
                        Console.Write("IN : ");
                        inputText = Console.ReadLine();
                        var orthographic = new TextImporter().Import(inputText);
                        Console.WriteLine($"IN : {orthographic}");

                        var phonemes = new GtpProcessor(rules).Process(orthographic);
                        Console.Write("OUT: ");
                        phonemes.WriteToConsole();
                        Console.WriteLine();
                    } while (inputText != "0");

                }

            } while (operation != "0");
        }

        private static Transcription ImportText()
        {
            string text = "Ogólnie znana teza głosi, iż użytkownika może rozpraszać zrozumiała zawartość strony, kiedy ten chce zobaczyć sam jej wygląd.";
            return new TextImporter().Import(text);
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
