using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeldOgLotto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // random & array declarations
            Random r = new Random();
            int[] lotto = new int[8];

            // runs 8 times (prints 8 numbers)
            for (int i = 0; i < lotto.Length; i++)
            {
                // sets each number to be between 1 and 37
                var tal = r.Next(1, 37);

                if (lotto.Contains(tal))
                    i -= 1;
                else
                    lotto[i] = tal; 
            }

            // sort array by number value ascending
            Array.Sort(lotto);

            // print result array
            for (int i = 0; i < lotto.Length; i++)
            {
                // after index 6 (number #7) prints the last number in red
                if (i > 6)
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.Write(lotto[i] + " ");

                // waits 2 seconds between printing each number (for suspense)
                Task.Delay(2000).Wait();
            }

            // hold on result
            Console.ReadLine();
        }
    }
}