using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrabble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // letter array declarations for later point tracking
            char[] one =
            {
                'E', 'A', 'N', 'R'
            };

            char[] two =
            {
                'D', 'L', 'O', 'S', 'T'
            };

            char[] three =
            {
                'B', 'I', 'K', 'F', 'G', 'M', 'U', 'V'
            };

            char[] four =
            {
                'H', 'J', 'P', 'Y', 'Æ', 'Ø', 'Å'
            };

            char[] eight =
            {
                'C', 'X', 'Z', 'W', 'Q'
            };

            // main loop
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please enter your word: \n");

                var word = Console.ReadLine();
                var score = 0;

                // used to terminate if word input is illegal
                bool legalWord = true;

                // letter based point assignment
                for (int i = 0; i < word.Length; i++)
                {
                    char letter = char.ToUpper(word[i]);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(letter);
                    Console.ResetColor();

                    if (one.Contains(letter))
                    {
                        Console.Write(" (1) ");
                        score += 1;
                    }

                    else if (two.Contains(letter))
                    {
                        Console.Write(" (2) ");
                        score += 2;
                    }

                    else if (three.Contains(letter))
                    {
                        Console.Write(" (3) ");
                        score += 3;
                    }

                    else if (four.Contains(letter))
                    {
                        Console.Write(" (4) ");
                        score += 4;
                    }

                    else if (eight.Contains(letter))
                    {
                        Console.Write(" (8) ");
                        score += 8;
                    }

                    // if letter isn't in one of the lists, display error message
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Illegal characters in word.\n" +
                            "Please try again with a legal word.");
                        Console.ResetColor();
                        Task.Delay(2000).Wait();
                        legalWord = false;
                    }
                }

                // display results if legal word
                if (legalWord)
                {
                    Console.WriteLine($"\n\nYour word, {word}, is worth {score} points.");
                    Console.ReadLine();
                }
            }
        }
    }
}
