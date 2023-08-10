using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fødselsdagen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // introduction and input
            Console.WriteLine("Please enter your date of birth (ddMMyyyy format)");
            string input = Console.ReadLine();

            // input parsed into DateTime format
            DateTime birthday = DateTime.ParseExact(input, "ddMMyyyy", null);

            // current time subtracted from birthday
            DateTime now = DateTime.Now;
            TimeSpan difference = now - birthday;

            // finds age in years
            int years = (int)Math.Floor(difference.TotalDays / 365.2425);
            birthday = birthday.AddYears(years);
            difference = now - birthday;

            // finds surplus of days after years calculation
            int days = (int)Math.Floor(difference.TotalDays);

            // print results
            Console.WriteLine($"You are {years} years and {days} days old. ");

            // hold on results
            Console.ReadLine();
        }
    }
}
