using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumfanget
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // introduction and declarations
            Console.WriteLine("Calculate the area of a box. Please enter the height of the box: ");
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the width of the box: ");
            double width = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the length of the box: ");
            double length = double.Parse(Console.ReadLine());

            // maths
            double area = height * width * length;

            // print results
            Console.WriteLine($"\nHeight: {height}\nWidth: {width}\nLength: {length}\n\nArea of the box: {area}");



        }
    }
}
