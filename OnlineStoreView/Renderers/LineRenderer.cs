using System;
using System.Threading;

namespace OnlineStoreView.Renderers
{
    public static class LineRenderer
    {
        public static void Clear()
        {
            Console.Clear();
        }

        public static void Primary(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            PrintAndResetColor(text);
        }

        public static void Secondary(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            PrintAndResetColor(text);
        }

        public static void Header(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            PrintAndResetColor(text);
        }

        public static void Success(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            PrintAndResetColor(text);
        }

        public static void Error(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            PrintAndResetColor(text);
        }

        public static void Warning(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintAndResetColor(text);
        }

        public static void Information(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            PrintAndResetColor(text);
        }

        private static void PrintAndResetColor(string text)
        {
            Console.WriteLine(text);
            Console.ResetColor();
        }

        internal static void Loading(string startText, string indicator, string endText, ConsoleColor color, int timeInSeconds)
        {
            Console.Write($"\n{startText.ToUpperInvariant()}: ");

            for (int i = 0; i <= timeInSeconds; i++)
            {
                Thread.Sleep(timeInSeconds * 100);
                Console.Write($"{indicator} ");
            }

            Console.ForegroundColor = color;
            Console.Write(endText);
            Thread.Sleep(timeInSeconds * 500);
            Console.ResetColor();
        }
    }
}