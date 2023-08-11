using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morsekoden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // all characters requiring more than a single keystroke have been omitted, in order to accommodate live text input & output

            // result var declaration
            string result = "";

            // main loop
            while (true)
            {
                // live user input
                var input = Console.ReadKey(true);
                
                // evil monster switch
                switch (input.Key)
                {
                    case ConsoleKey.A:
                        Console.Write("·- ");
                        result += "A";
                        break;

                    case ConsoleKey.B:
                        Console.Write("-··· ");
                        result += "B";
                        break;

                    case ConsoleKey.C:
                        Console.Write("-·-· ");
                        result += "C";
                        break;

                    case ConsoleKey.D:
                        Console.Write("—·· ");
                        result += "D";
                        break;

                    case ConsoleKey.E:
                        Console.Write("· ");
                        result += "E";
                        break;

                    case ConsoleKey.F:
                        Console.Write("··-· ");
                        result += "F";
                        break;

                    case ConsoleKey.G:
                        Console.Write("--· ");
                        result += "G";
                        break;

                    case ConsoleKey.H:
                        Console.Write("···· ");
                        result += "H";
                        break;

                    case ConsoleKey.I:
                        Console.Write("·· ");
                        result += "I";
                        break;

                    case ConsoleKey.J:
                        Console.Write("·--- ");
                        result += "J";
                        break;

                    case ConsoleKey.K:
                        Console.Write("-·- ");
                        result += "K";
                        break;

                    case ConsoleKey.L:
                        Console.Write("·-·· ");
                        result += "L";
                        break;

                    case ConsoleKey.M:
                        Console.Write("-- ");
                        result += "M";
                        break;

                    case ConsoleKey.N:
                        Console.Write("-· ");
                        result += "N";
                        break;

                    case ConsoleKey.O:
                        Console.Write("--- ");
                        result += "O";
                        break;

                    case ConsoleKey.P:
                        Console.Write("·--· ");
                        result += "P";
                        break;

                    case ConsoleKey.Q:
                        Console.Write("--·- ");
                        result += "Q";
                        break;

                    case ConsoleKey.R:
                        Console.Write("·-· ");
                        result += "R";
                        break;

                    case ConsoleKey.S:
                        Console.Write("··· ");
                        result += "S";
                        break;

                    case ConsoleKey.T:
                        Console.Write("- ");
                        result += "T";
                        break;

                    case ConsoleKey.U:
                        Console.Write("··- ");
                        result += "U";
                        break;

                    case ConsoleKey.V:
                        Console.Write("···- ");
                        result += "V";
                        break;

                    case ConsoleKey.W:
                        Console.Write("·-- ");
                        result += "W";
                        break;

                    case ConsoleKey.X:
                        Console.Write("-··- ");
                        result += "X";
                        break;

                    case ConsoleKey.Y:
                        Console.Write("-·-- ");
                        result += "Y";
                        break;

                    case ConsoleKey.Z:
                        Console.Write("--·· ");
                        result += "Z";
                        break;

                    case ConsoleKey.D1:
                        Console.Write("·---- ");
                        result += "1";
                        break;

                    case ConsoleKey.D2:
                        Console.Write("··--- ");
                        result += "2";
                        break;

                    case ConsoleKey.D3:
                        Console.Write("···-- ");
                        result += "3";
                        break;

                    case ConsoleKey.D4:
                        Console.Write("····- ");
                        result += "4";
                        break;

                    case ConsoleKey.D5:
                        Console.Write("····· ");
                        result += "5";
                        break;

                    case ConsoleKey.D6:
                        Console.Write("-···· ");
                        result += "6";
                        break;

                    case ConsoleKey.D7:
                        Console.Write("--··· ");
                        result += "7";
                        break;

                    case ConsoleKey.D8:
                        Console.Write("---·· ");
                        result += "8";
                        break;

                    case ConsoleKey.D9:
                        Console.Write("----· ");
                        result += "9";
                        break;

                    case ConsoleKey.D0:
                        Console.Write("----- ");
                        result += "0";
                        break;

                    // full stop accompanied by a newline
                    case ConsoleKey.OemPeriod:
                        Console.WriteLine("·-·-·- ");
                        result += ".";
                        break;

                    // prints regular text version of user input
                    case ConsoleKey.Enter:
                        //Console.WriteLine("·-·-·-");
                        Console.WriteLine($"\nYour sentence:\n{result} ");
                        break;

                    case ConsoleKey.OemComma:
                        Console.Write("--··-- ");
                        result += ",";
                        break;

                    // words are space separated
                    case ConsoleKey.Spacebar:
                        Console.Write(" / ");
                        result += " ";
                        break;

                    // exits program
                    case ConsoleKey.Escape:
                        Console.WriteLine("\n--·-------··-···-·--··-·-·-\n");  // "GOODBYE"
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
