using System;

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
    }
}