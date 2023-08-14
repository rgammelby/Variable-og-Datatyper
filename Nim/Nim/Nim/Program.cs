using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // variable declarations
            var matches = 7;
            byte input = 0;
            bool playerTurn = true;

            // game loop
            while (true)
            {
                // match counter
                if (matches > 1)
                    Console.WriteLine($"\nThere are currently {matches} matches on the table. \n");
                else
                    Console.WriteLine("There is currently 1 match on the table. \n");

                // the player always loses
                if (matches == 1 && playerTurn == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You've lost. ");
                    Console.ResetColor();
                    Console.WriteLine("Press 'Enter' to try again. ");

                    var selection = Console.ReadKey(true).Key;

                    // press Enter to lose again, or Esc to exit
                    switch (selection)
                    {
                        case ConsoleKey.Enter:
                            Console.ReadLine();
                            Console.Clear();
                            matches = 7;
                            continue;

                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;

                    }
                }  
                // 1st player literally always loses, so this code is totally redundant
                else if (matches == 1 && playerTurn == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You win!");
                    Console.ResetColor();
                }

                // turn counter
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your turn. ");
                Console.ResetColor();
                playerTurn = true;

                // input safety; input may not be greater 3 or less than 1, and it may not be greater than the amount of matchsticks still on the table
                try
                {
                    Console.WriteLine("How many matches do you take? \n");
                    input = byte.Parse(Console.ReadLine());
                    if (input > 3 || input <= 0 || input > matches)
                    {
                        Error();
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nComputer's turn. ");
                    Console.ResetColor();
                    playerTurn = false;
                }
                catch 
                { 
                    Error();
                }

                // decrease 'matches' var with the amount of matchsticks the player has taken
                matches -= input;

                // computer switch - always wins.
                switch (matches)
                {
                    case 2:
                        matches -= 1;
                        Console.WriteLine("The computer takes 1 match. ");
                        break;

                    case 3:
                        matches -= 2;
                        Console.WriteLine("The computer takes 2 matches. ");
                        break;

                    case 4:
                        matches -= 3;
                        Console.WriteLine("The computer takes 3 matches. ");
                        break;

                    case 5:
                        matches -= 1;
                        Console.WriteLine("The computer takes 1 match. ");
                        break;

                    case 6:
                        matches -= 1;
                        Console.WriteLine("The computer takes 1 match. ");
                        break;
                }                
            }
        }

        // i know we aren't meant to do methods yet, but big blocks like this are really ugly to look at
        static void Error()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nError: User input has to be a number between 1 and 3. ");
            Task.Delay(1000).Wait();
            Console.ResetColor();
            Console.Clear();
        }
    }
}
