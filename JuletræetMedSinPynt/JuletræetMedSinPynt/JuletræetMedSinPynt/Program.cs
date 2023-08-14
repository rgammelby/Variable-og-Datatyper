using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuletræetMedSinPynt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // relevant dimension/size declarations
            var offset = 9;
            var asteriskOffset = 1;
            var treeHeight = 8;

            // parent loop
            for (int i = 0; i < treeHeight; i++)
            {
                // inner loops
                for (int j = 0; j < offset; j++)
                {
                    // spaces place asterisks correctly later in the program
                    Console.Write(" ");
                }
                for (int j = 0; j < asteriskOffset; j++)
                {
                    // if CursorLeft (x value) is even, print green
                    if (Console.CursorLeft % 2 == 0)
                        Console.ForegroundColor = ConsoleColor.Green;

                    // the rest is red
                    else
                        Console.ForegroundColor = ConsoleColor.Red;

                    // if CursorTop (y value) is even, print green
                    if (Console.CursorTop % 2 == 0) 
                        Console.ForegroundColor = ConsoleColor.Green;

                    // print asterisks
                    Console.Write("*");
                }

                // newlines and increments/decrements
                Console.WriteLine();
                asteriskOffset += 2;
                offset--;
            }

            // hold on result
            Console.ReadLine();
        }
    }
}
