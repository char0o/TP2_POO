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

            Utility.PrintColoredText(message, ConsoleColor.White);
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
                    Utility.PrintColoredText(error, ConsoleColor.Red);
                    Console.SetCursorPosition(message.Length, cursorTop);
                    valid = false;
                }

            }
            return input;
        }
        public static string PromptStringCursor(string message, string error)
        {
            int cursorTop = Console.CursorTop;

            Utility.PrintColoredText(message, ConsoleColor.White);
            ClearInput(message.Length, cursorTop, Console.WindowWidth - message.Length);
            string input = Console.ReadLine();
            while (String.IsNullOrEmpty(input.Trim()))
            {
                int messageLength = message.Length;
                ClearInput(messageLength, cursorTop, input.Length);
                Console.SetCursorPosition(messageLength + 10, cursorTop);
                Utility.PrintColoredText(error, ConsoleColor.Red);
                Console.SetCursorPosition(messageLength, cursorTop);
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

        public static void Pause()
        {
            Utility.PrintColoredText("Press any key to continue...", ConsoleColor.Red, true);
            Console.ReadKey();
        }



        public static double PromptDouble(double min, double max, string message)
        {
            Console.Clear();
            double input;
            Console.WriteLine(message);
            while (!double.TryParse(Console.ReadLine(), out input) || input < min || input > max)
            {
                Utility.PrintError("Invalid number");
            }
            return input;
        }
        public static int PromptInt(string message)
        {
            int input;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Utility.PrintError("Invalid input");
            }
            return input;
        }
        public static int PromptInt(int min, int max, string message)
        {
            int input;
            Console.WriteLine(message);
            while (!int.TryParse(Console.ReadLine(), out input) || input < min || input > max)
            {
                Utility.PrintError("Invalid input");
            }
            return input;
        }
        public static int PromptInt(int min, int max, string message, string error)
        {
            int input;
            Console.WriteLine(message);
            while (!int.TryParse(Console.ReadLine(), out input) || input < min || input > max)
            {
                Utility.PrintError(error);
            }
            return input;
        }
    }
}
