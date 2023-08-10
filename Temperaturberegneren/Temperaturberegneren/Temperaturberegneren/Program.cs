using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperaturberegneren
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // introduction
            Console.WriteLine("Please enter a centigrade temperature: ");

            // initial variable and conversion declarations
            double celsius = double.Parse(Console.ReadLine());
            double fahrenheit = (celsius * 1.8) + 32;
            double reaumur = celsius * 0.8;

            // print results
            Console.WriteLine($"{celsius} degrees C is equivalent to\n{fahrenheit} degrees Fahrenheit\n{reaumur} degrees Reaumur");

            Console.ReadLine();
        }
    }
}
