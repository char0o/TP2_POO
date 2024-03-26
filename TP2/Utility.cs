using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public static class Utility
    {
        public static Random random = new Random();
        public static int DemanderNombreEntreMinEtMax(int min, int max)
        {
            return random.Next(min, max + 1);
        }
        public static void PrintFormattedColoredText(string format, string[] strings, ConsoleColor[] colors)
        {
            if (strings.Length != colors.Length)
            {
                throw new ArgumentException("Texts and colors arrays must have the same length");
            }
            string[] formatsRaw = format.Split(new[] { ",", "}" }, StringSplitOptions.None);
            string[] formats = new string[formatsRaw.Length / 2];
            for (int i = 0; i < formatsRaw.Length; i++)
            {
                if (i % 2 != 0)
                {
                    formats[i / 2] = formatsRaw[i];
                }
            }
            if (strings.Length != formats.Length)
            {
                throw new ArgumentException("Texts and formats arrays must have the same length");
            }
            for (int i = 0; i < strings.Length; i++)
            {
                string newFormat = "{0," + formats[i] + "}";
                PrintColoredText(String.Format(newFormat, strings[i].ToString()), colors[i]);
            }
        }
        public static string CreateMenuFromList(List<Classe> list, string[] options)
        {
            string menu = "";
            int index = 0;
            foreach (Classe classe in list)
            {
                menu += $"{index}. {options[index]}";
                if (index + 1 != list.Count)
                    menu += "\n";
                index++;
            }
            return menu;
        }
        public static string CreateMenuFromEnum<T>(string[] options) where T : Enum
        {
            if (options.Length != Enum.GetValues(typeof(T)).Length)
                throw new ArgumentException("Options array must have the same length as the enum");

            string menu = "";
            int offset = (int)(object)Enum.GetValues(typeof(T)).GetValue(0);
            foreach (T option in Enum.GetValues(typeof(T)))
            {
                int optionInt = (int)(object)option;
                menu += (optionInt + ". " + options[optionInt - offset]);
                if (optionInt != Enum.GetValues(typeof(T)).Length - 1 + offset)
                {
                    menu += "\n";
                }
            }
            return menu;
        }
        public static void PrintColoredText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
        public static void PrintColoredText(string text, ConsoleColor color, bool newLine)
        {
            Console.ForegroundColor = color;
            if (newLine)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.Write(text);
            }
            Console.ForegroundColor = color;

            Console.ResetColor();
        }
        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
