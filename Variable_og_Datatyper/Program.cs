using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variable_og_Datatyper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Opgave A

            int length = 16;
            double width = 5.1;

            Console.WriteLine(length * width);
            Console.ReadLine();

            // Opgave B

            // integervariablen 'area' kan ikke erklæres som int length * double width, da integervariablen ikke kan indeholde decimaltal - som double kan
            //int area = length * width;

            // Opgave C

            // doublevariablen kan til gengæld godt arbejde med decimaltal, og kan derfor fint arbejde med både integers og doubles
            double d = length * width;
        }
    }
}
