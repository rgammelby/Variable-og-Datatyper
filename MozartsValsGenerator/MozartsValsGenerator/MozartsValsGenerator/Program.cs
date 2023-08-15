using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MozartsValsGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // vals-generator
            // minuette x & y values
            var mx = 12;
            var my = 17;

            int[,] combo = new int[my, mx];

            Random xr = new Random();
            Random yr = new Random();
            Random all = new Random();

            var mxr = xr.Next(2, 12);
            var myr = yr.Next(1, 16);
            var add = yr.Next(2, 176);

            // contains all the numbers from 2 to 176
            int[] alla = new int[176];
            for (int i = 0; i < alla.Length; i++)
            {
                alla[i] = i + 1;
            }
            /*
            Console.WriteLine($"alla: \n");
            foreach (int i in alla)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();*/
            /*
            for (int i = 0; i < my - 1; i++)
            {
                for (int j = 0; j < mx - 1; j++)
                {
                    combo[i, j] = alla[(i + 2) * (j + 2) - 2];
                }
            }*/
            
            for (int i = 0; i < my; i++)
            {
                for (int j = 0; j < mx; j++)
                {
                    
                    Console.SetCursorPosition(i * 5, j);
                    Console.WriteLine(i * j);
                    //Console.Write(alla[i]);
                }
            }
            Console.ReadLine();



            Console.WriteLine($"combo: \n");
            foreach (int i in combo)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}
