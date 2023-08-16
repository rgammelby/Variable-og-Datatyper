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
            // minuette x & y values, and minuette 2d-array declaration
            var mx = 16;
            var my = 11;

            int[,] minuette = new int[mx, my];

            // populates 2d array with numbers 1-176 (sequential, because i couldn't be bothered to enter the values manually)
            var populate = 1;

            for (int i = 0; i < mx; i++)
            {
                for (int j = 0; j < my; j++)
                {
                    minuette[i, j] = populate;
                    populate++;
                }
            }

            // sound file locator
            // for each run (of 16), the sum of the dice indicate the y-value, indicating which # sound to use

            // dice generation
            Random mxRandom = new Random();
            Random myRandom = new Random();

            // dice sum
            var minuetteSum = mxRandom.Next(1, 7) + myRandom.Next(1, 7);
            int minuetteWav;

            // TRIO
            // same exact process, could've been a method accepting parameters int x, int y and int[,] mdArray
            var tx = 16;
            var ty = 6;

            int[,] trio = new int[tx, ty];

            populate = 1;

            for (int i = 0; i < tx; i++)
            {
                for (int j = 0; j < ty; j++)
                {
                    trio[i, j] = populate;
                    populate++;
                }
            }

            // single die
            Random tRandom = new Random();

            var trioSum = tRandom.Next(1, 7);
            int trioWav;

            // array consolidation
            string[] completeMusic = new string[mx + tx];

            // reads minuette and trio into the consolidated complete "piece"
            for (int i = 0; i < mx - 1; i++)
            {
                minuetteWav = minuette[i, minuetteSum];
                completeMusic[i] = @"C:\Users\zbcrabg\Github Integration\programming-basics\MozartsValsGenerator\Sound files\Wave\M"
                + minuetteWav + ".wav";
            }

            for (int i = tx; i < tx; i++)
            {
                trioWav = trio[i, trioSum];
                completeMusic[i] = @"C:\Users\zbcrabg\Github Integration\programming-basics\MozartsValsGenerator\Sound files\Wave\M"
                + trioWav + ".wav";
            }

            // media player
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();

            // plays the sound corresponding to each string in completeMusic; each file selected randomly
            foreach (string s in completeMusic)
            {
                sp.SoundLocation = s;
                sp.Load();
                sp.PlaySync();
            }
        }
    }
}
