﻿using Newtonsoft.Json;
using System;

namespace PolishSpeechLibrary.Gtp
{
    [Serializable]
    public class GtpRule
    {
        public GtpRule()
        {
        }

        public GtpRule(string grapheme, string preceding, string following, string phoneme, string debug)
        {
            Grapheme = grapheme;
            PrecedingContext = preceding;
            FollowingContext = following;
            Phoneme = phoneme;
            Debug = debug;
        }

        [JsonProperty("g")]
        public string Grapheme { get; set; } = string.Empty;

        [JsonProperty("p")]
        public string Phoneme { get; set; } = string.Empty;

        [JsonProperty("r")]
        public string PrecedingContext { get; set; } = string.Empty;

        [JsonProperty("f")]
        public string FollowingContext { get; set; } = string.Empty;

        [JsonProperty("d")]
        public string Debug { get; set; } = string.Empty;

        public bool IsNotFound { get; set; } = false;

        public override string ToString()
        {
            return $"[{PrecedingContext}][{Grapheme}][{FollowingContext}] -> {Phoneme} <{Debug}>";
        }

        public void WriteToConsole()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            Console.ForegroundColor = IsNotFound ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.Write(PrecedingContext);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t[");
            Console.ForegroundColor = IsNotFound ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write(Grapheme);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t[");
            Console.ForegroundColor = IsNotFound ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.Write(FollowingContext);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]");

            Console.Write("\t -> ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t[");
            Console.ForegroundColor = IsNotFound ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write(Phoneme);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("][");
            Console.ForegroundColor = IsNotFound ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write(Debug);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("]");

        }
    }
}