using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarsAndStripes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // initial variable declaration
            byte x = 0;
            byte y = 0;
            byte width = 38 * 2;

            Console.BackgroundColor = ConsoleColor.Red;

            // red stripes
            for (int i = 0; i < 7; i++)  // height
            {
                for (int j = 0; j < width; j++)  // width
                {
                    At(x + j, y + (i * 4), ' ');
                    At(x + j, y + 1 + (i * 4), ' ');
                }
            }

            Console.BackgroundColor = ConsoleColor.White;

            // white stripes
            for (int i = 0; i < 6; i++)  // height
            {
                for (int j = 0; j < width; j++)  // width
                {
                    At(x + j, y + (i * 4) + 2, ' ');
                    At(x + j, y + 1 + (i * 4) + 2, ' ');
                }
            }

            Console.BackgroundColor = ConsoleColor.Blue;

            // blue box
            for (int i = 0; i < 11; i++)  // height
            {
                for (int j = 0; j < (23 * 2); j++)  // width
                {
                    At(x + j, y + i, ' ');
                }
            }

            Console.ForegroundColor = ConsoleColor.White;

            // 5 * 6 stars
            for (int i = 0; i < 5; i++)  // height
            {
                for (int j = 0; j < 6; j++)  // width
                {
                    At(x + 2 + (j * 8), y + 1 + (i * 2), '*');
                }
            }

            // 4 * 5 stars
            for (int i = 0; i < 4; i++)  // height
            {
                for (int j = 0; j < 5; j++)  // width
                {
                    At(x + 6 + (j * 8), y + 2 + (i * 2), '*');
                }
            }

            // hold on picture
            Console.ReadLine();
        }

        // method for quick writing to a position; saves me keystrokes
        static void At(int x, int y, char c)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }
    }
}
