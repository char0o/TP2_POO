using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public static class InputManager
    {
        public static int PromptIntCursor(int min, int max, string message, string error)
        {
            int input = -1;
            int cursorTop = Console.CursorTop;

            PrintColoredText(message, ConsoleColor.White);
            ClearInput(message.Length, cursorTop, Console.WindowWidth - message.Length);
            bool valid = false;
            while (!valid)
            {
                string inputString = Console.ReadLine();
                valid = int.TryParse(inputString, out input);
                if (!valid || input < min || input > max)
                {
                    ClearInput(message.Length, cursorTop, inputString.Length);
                    Console.SetCursorPosition(message.Length + 5, cursorTop);
                    PrintColoredText(error, ConsoleColor.Red);
                    Console.SetCursorPosition(message.Length, cursorTop);
                    valid = false;
                }

            }
            return input;
        }
        public static string PromptStringCursor(string message, string error)
        {
            int cursorTop = Console.CursorTop;

            PrintColoredText(message, ConsoleColor.White);
            ClearInput(message.Length, cursorTop, Console.WindowWidth - message.Length);
            string input = Console.ReadLine();
            while (String.IsNullOrEmpty(input.Trim()))
            {
                ClearInput(message.Length, cursorTop, input.Length);
                Console.SetCursorPosition(message.Length + 10, cursorTop);
                PrintColoredText(error, ConsoleColor.Red);
                Console.SetCursorPosition(message.Length, cursorTop);
                input = Console.ReadLine();
            }
            return input;
        }
        public static void ClearInput(int cursorLeft, int cursorTop, int length)
        {
            Console.SetCursorPosition(cursorLeft, cursorTop);
            string clear = new string(' ', length);
            Console.Write(clear);
            Console.SetCursorPosition(cursorLeft, cursorTop);
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
        public static void Pause()
        {
            PrintColoredText("Press any key to continue...", ConsoleColor.Red, true);
            Console.ReadKey();
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
                InputManager.PrintColoredText(String.Format(newFormat, strings[i].ToString()), colors[i]);
            }
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

        public static string PromptString(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            string input = Console.ReadLine();
            while (String.IsNullOrEmpty(input.Trim()))
            {
                PrintError("Name can't be empty");
                Console.WriteLine(message);
                input = Console.ReadLine();
            }
            return input;
        }
        public static string PromptString(string message, string error)
        {
            Console.Clear();
            Console.WriteLine(message);
            string input = Console.ReadLine();
            while (String.IsNullOrEmpty(input.Trim()))
            {
                PrintError(error);
                Console.WriteLine(message);
                input = Console.ReadLine();
            }
            return input;
        }
        public static double PromptDouble(double min, double max, string message)
        {
            Console.Clear();
            double input;
            Console.WriteLine(message);
            while (!double.TryParse(Console.ReadLine(), out input) || input < min || input > max)
            {
                PrintError("Invalid number");
            }
            return input;
        }
        public static int PromptInt(string message)
        {
            int input;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                PrintError("Invalid input");
            }
            return input;
        }
        public static int PromptInt(int min, int max, string message)
        {
            int input;
            Console.WriteLine(message);
            while (!int.TryParse(Console.ReadLine(), out input) || input < min || input > max)
            {
                PrintError("Invalid input");
            }
            return input;
        }
        public static int PromptInt(int min, int max, string message, string error)
        {
            int input;
            Console.WriteLine(message);
            while (!int.TryParse(Console.ReadLine(), out input) || input < min || input > max)
            {
                PrintError(error);
            }
            return input;
        }
    }
}
