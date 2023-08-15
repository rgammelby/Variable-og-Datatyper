using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinosBlancos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Controller();
            Console.ReadLine();
        }

        // Model
        static int[,] GetModelData()
        {
            // wine sales per year
            int[,] wine = new int[11, 2]
            {
                { 175134, 2009 },
                { 175388, 2010 },
                { 172818, 2011 },
                { 142709, 2012 },
                { 151347, 2013 },
                { 188052, 2014 },  // corrected from 152620 to 188052
                { 150979, 2015 },
                { 152210, 2016 },
                { 149450, 2017 },
                { 154398, 2018 },
                { 150160, 2019 }
            };

            return wine;
        }

        // View

        static void UI()
        {
            Console.WriteLine("This program shows a rudimentary graph displaying the annual consumption of wine (in thousand litres) by danish people.\n" +
                "100 being the largest possible amount of stars, representing the highest annual sales by thousand litres value. ");
        }

        // print stats
        static void UIDisplayStats(int[] stars)
        {
            var y = 5;

            Console.WriteLine("\nGraph: ");
            for (int i = 0; i < stars.Length; i++)
            {
                Console.SetCursorPosition(0, y + i);
                Console.WriteLine(string.Concat(Enumerable.Repeat("*", stars[i])));
            }
        }

        // Controller

        static void Controller()
        {
            int[,] wine = GetModelData();

            // run intro
            UI();

            // declaration of array containing the amounts of stars
            int[] stars = new int[11];

            // maths - initialization of stars array
            for (int i = 0; i < (wine.Length / 2); i++)
            {
                stars[i] = ControllerStarFormula(wine[i, 0]);
            }

            // displays graph
            UIDisplayStats(stars);

            SortArray(wine);
        }

        static void SortArray(int[,] wine)
        {
            Console.WriteLine("\n\nBefore sort: \n");
            for (int i = 0; i < wine.Length / 2; i++)
            {
                Console.WriteLine(wine[i, 0]);
            }

            int[,] temp = new int[1, 2];
            bool sorted = true;

            for (int n = 0; n <= (wine.Length / 2) && sorted; n++)
            {
                sorted = false;
                for (int i = 0; i < (wine.Length / 2) - 1; i++)
                {
                    // if n entry is less than n + 1 entry
                    if (wine[i, 0] < wine[i + 1, 0])
                    {
                        temp[0, 0] = wine[i + 1, 0];  // n + 1 is stored in temp
                        wine[i + 1, 0] = wine[i, 0];  // n entry is moved to n + 1's place
                        wine[i, 0] = temp[0, 0];  // n entry is replaced by n + 1
                        sorted = true;
                    }
                }
            }

            Console.WriteLine("\nAfter sort: \n");
            for (int i = 0; i < wine.Length / 2; i++)
            {
                Console.WriteLine(wine[i, 0]);
            }
            Console.ReadLine();

        }

        static int ControllerStarFormula(int sales)
        {
            const int MAX = 175388;
            const byte MAX_STAR = 100;

            return MAX_STAR * sales / MAX;
        }

    }
}
