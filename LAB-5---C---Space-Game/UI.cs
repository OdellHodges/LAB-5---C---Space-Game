using System;
using System.Collections.Generic;
using System.Text;

namespace LAB_5___C___Space_Game
{
    static class UI
    {
        public static ConsoleKey ElicitInput(string prompt = "> ")
        {
            var cursorLeftPos = Console.CursorLeft;
            var cursorTopPos = Console.CursorTop;

            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write(prompt);

            Console.SetCursorPosition(cursorLeftPos, cursorTopPos);

            return Console.ReadKey(true).Key;
        }

        public static double ElicitInput(string prompt, double lower, double upper)
        {
            bool valid = false;
            double input = 0.0;

            do
            {
                Console.Write($"{prompt} (Range: [{lower:f1},{upper:f1}))");

                try
                {
                    input = double.Parse(Console.ReadLine());
                }
                catch (FormatExcemption)
                ( )
            } while (!valid) ;

                return input;
            }
    
        public static void Highlight()
        {
            var background = Console.BackgroundColor;
            var foreground = Console.ForegroundColor;

            Console.ForegroundColor = background;
            Console.BackgroundColor = foreground;
        }

        public static void ResetColors()
        {
            Console.ResetColor();
        }
    }
}
