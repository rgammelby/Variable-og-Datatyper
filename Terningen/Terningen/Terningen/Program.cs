using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terningen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // loop so you can continue rolling the die
            while (true)
            {
                // random and die initialization / declaration
                Random r = new Random();
                int die = r.Next(1, 7);

                // result switch
                switch (die)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You got a 1!");
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You got a 2!");
                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You got a 3!");
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("You got a 4!");
                        break;

                    case 5:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("You got a 5!");
                        break;

                    case 6:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("You got a 6!");
                        break;
                }

                // hold on result
                Console.ReadLine();
            }          
        }
    }
}
