using PolishSpeechLibrary.Gtp;
using PolishSpeechLibrary.IO;
using PolishSpeechLibrary.Model;
using PolishSpeechLibrary.WordDetection;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace PolishSpeechLibrary.Tester
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var operation = "";
            do
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Polish Speech Library Tester");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("--------------------------------------------------------------------");
                //Console.WriteLine("0. Exit application ");
                //Console.WriteLine("1. Export SAMPA alphabet");
                //Console.WriteLine("2. Import Text");
                //Console.WriteLine("3. Detect Words");
                //Console.WriteLine("4. Load Gtp Rules XML");
                //Console.WriteLine("5. Convert Gtp Rules XML->JSON");
                //Console.WriteLine("6. GTP");

                //Console.WriteLine();
                //Console.Write("Choose operation and press ENTER: ");

                //operation = Console.ReadLine();
                operation = "6";

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
                    var rules = new GtpRulesXmlReaderWriter().Read("./GtpRules.xml");

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
                    var rules = xmlWriter.Read("./GtpRules.xml");
                    var jsonWriter = new GtpRulesJsonReaderWriter();
                    jsonWriter.Write("./GtpRules.json", rules);
                    Console.WriteLine($"Rules ({rules.Count}) saved to file 'GtpRules.json'");
                    Console.ReadLine();
                }
                else if (operation == "6")
                {
                    //Console.WriteLine("----------------------------------");
                    //Console.ForegroundColor = ConsoleColor.DarkGreen;
                    //Console.WriteLine("GTP Example");
                    //Console.ForegroundColor = ConsoleColor.White;
                    //Console.WriteLine("----------------------------------");

                    Console.Write($"Loading rules... ");
                    var readerWriter = new GtpRulesCsvReaderWriter();
                    var rules = readerWriter.Read("./GtpRules.csv");
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("OK");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("]");

                    //var texts = new List<string> {
                    //    "to jest ala ładna kobyła",
                    //    "była dziewczyna nosi nocnik",
                    //    "legendarny słoń walczy z pniaczkiem"
                    //};

                    //foreach (var text in texts)
                    //{
                    //    var orthographic = new TextImporter().Import(text);
                    //    Console.WriteLine($"IN : {orthographic}");

                    //    var phonemes = new GtpProcessor(rules).Process(orthographic);
                    //    Console.Write("OUT: ");
                    //    phonemes.WriteToConsole();
                    //    Console.WriteLine();
                    //}

                    Console.WriteLine("--------------------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("GTP Command Line");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("--------------------------------------------------------------------");

                    var gtp = new GtpProcessor(rules);
                    var inputText = string.Empty;
                    do
                    {
                        Console.Write("IN : ");
                        inputText = Console.ReadLine();
                        var orthographic = new OrthorgraphicTranscriptionReader().Read(inputText);
                        Console.WriteLine($"IN : {orthographic}");

                        var phonemes = gtp.Process(orthographic);
                        Console.Write("OUT: ");
                        phonemes.WriteToConsole();
                        Console.WriteLine();
                        ShowGtpDebug(gtp.ExtendedOutput);
                    } while (inputText != "0");
                }
            } while (operation != "0");
        }

        private static void ShowGtpDebug(GtpExtendedOutput output)
        {
            Console.WriteLine("--------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("OUTPUT - Used Rules");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--------------------------------------------------------------------");
            foreach (var rule in output.UsedRules)
            {
                rule.WriteToConsole();
                Console.WriteLine();
            }
            Console.WriteLine("--------------------------------------------------------------------");
        }

        private static Transcription ImportText()
        {
            string text = "Ogólnie znana teza głosi, iż użytkownika może rozpraszać zrozumiała zawartość strony, kiedy ten chce zobaczyć sam jej wygląd.";
            return new OrthorgraphicTranscriptionReader().Read(text);
        }

        private static void ExportSampaAlphabet()
        {
            var sampa = SampaAlphabet.GetAllLetters();
            StringBuilder sb = new StringBuilder();
            foreach (var letter in sampa)
            {
                var line = $"{letter.Value} \t {letter.ArticulationManner.Name} \t\t {letter.ArticulationPlace.Name}";
                sb.AppendLine(line);
                Console.WriteLine(line);
            }
            File.WriteAllText("c:\\Projekty\\Sampa.csv", sb.ToString());
        }
    }
}