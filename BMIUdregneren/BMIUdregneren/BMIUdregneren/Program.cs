using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMIUdregneren
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // clears the console when loop restarts
            Console.Clear();

            // uninitialized variables
            float height;
            float weight;

            // main loop
            while (true)
            {
                // information and input intake
                Console.WriteLine("This is a BMI calculator. In order to calculate your BMI, you will need to enter two values. " +
                "Please enter your height (in centimetres): ");

                // saves the program if user input is unexpected
                try
                {
                    height = byte.Parse(Console.ReadLine());

                    Console.WriteLine("\nPlease enter your weight (in kilograms): ");
                    weight = byte.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please enter a number. ");
                    Task.Delay(1000).Wait();
                    Console.Clear();
                    continue;
                }

                // float.Parse(Console.ReadLine()); did not accept numbers with any decimals, so i went for input in cm 
                height /= 100;

                // input summary
                Console.WriteLine($"\nHeight in metres: {height}\nWeight in kilogrammes: {weight}");

                // calc
                float bmi = weight / (height * height);

                // result print
                Console.WriteLine("Your BMI is " + bmi.ToString("n2") + ".\n");

                // conditional result print
                if (bmi > 16 && bmi < 18.5)
                    Console.WriteLine("You are currently underweight. ");

                else if (bmi > 18.5 && bmi < 24)
                    Console.WriteLine("Your weight is within the norm for your height. ");

                else if (bmi > 24 && bmi < 30)
                    Console.WriteLine("You are currently overweight. ");

                else if (bmi > 30 && bmi < 35)
                    Console.WriteLine("You are currently obese (first degree). ");

                else if (bmi > 35 && bmi < 40)
                    Console.WriteLine("You are currently obese (second degree). ");

                else if (bmi > 40)
                    Console.WriteLine("You are currently obese (third degree). ");

                else  // off the charts escape clause
                    Console.WriteLine("Your BMI does not match with any category on the scale. ");

                // hold on results
                Console.ReadLine();
            }
            
        }
    }
}
