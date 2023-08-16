using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // main loop
            while(true)
            {
                Console.Clear();

                // serves introduction & password rules
                Introduction();

                Console.WriteLine("Please enter your password: ");
                var password = Console.ReadLine();

                // runs the validator, returns a value 0-2
                int validity = Validator(password);

                if (validity == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congratulations. Your password is valid!");
                }
                else if (validity == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Your password is valid, but weak.");
                }
                else if (validity == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your password is NOT valid.");
                }

                Console.ResetColor();
                Console.ReadLine();
            }
        }
        
        // rules
        static void Introduction()
        {
            Console.WriteLine("Welcome to the password validator.\n\nThese are the rules for a valid password:\n\nThe password:\n\n" +
                "* Is more than 12, and fewer than 64 characters in length.\n" +
                "* Contains at least one (1) special character.\n" +
                "* Contains both upper and lower case letters.\n" +
                "* Contains a mix of numbers and letters.\n\n" +
                $"In some cases, your password will be valid, but considered weak. This is the case if your password\n" +
                "* Contains 4 or more repeated characters (eg. BBBB)\n" +
                "* Contains 4 or more numbers in sequence (eg. 1234, 4567)\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A strong and valid password. ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("A weak, but valid password. ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An invalid password. \n");

            Console.ResetColor();
        }

        // checks whether the password lives up to the set conditions, returns value 0-2 for validity & strength
        static int Validator(string password)
        {
            const int VALID = 0;
            const int WEAK = 1;
            const int INVALID = 2;

            bool containsUpper = ContainsUpper(password);
            bool containsLower = ContainsLower(password);
            bool passwordLength = PasswordLength(password);
            bool containsNumbers = ContainsNumbers(password);
            bool containsSpecialCharacter = ContainsSpecialCharacter(password);
            bool containsSequentialNumbers = ContainsSequentialNumbers(password);
            bool containsRepeatedCharacters = ContainsRepeatedCharacters(password);

            if (containsUpper
                && containsLower
                && passwordLength
                && containsNumbers
                && containsSpecialCharacter
                && !containsSequentialNumbers
                && !containsRepeatedCharacters)
                return VALID;

            else if (containsUpper
                && containsLower
                && passwordLength
                && containsNumbers
                && containsSpecialCharacter
                && containsSequentialNumbers
                && containsRepeatedCharacters
                ||
                containsUpper
                && containsLower
                && passwordLength
                && containsNumbers
                && containsSpecialCharacter
                && !containsSequentialNumbers
                && containsRepeatedCharacters
                ||
                containsUpper
                && containsLower
                && passwordLength
                && containsNumbers
                && containsSpecialCharacter
                && containsSequentialNumbers
                && !containsRepeatedCharacters)
                return WEAK;

            else
                return INVALID;
        }

        // checks password example for uppercase letters
        static bool ContainsUpper(string password)
        {
            bool containsUpper = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsUpper(password[i]))
                    containsUpper = true;
            }
            return containsUpper;
        }

        // checks password example for lowercase letters
        static bool ContainsLower(string password)
        {
            bool containsLower = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsLower(password[i]))
                    containsLower = true;
            }
            return containsLower;
        }

        // checks if the password example length is acceptable
        static bool PasswordLength(string password)
        {
            if (password.Length <= 64 && password.Length >= 12)
                return true;
            else 
                return false;
        }

        // checks password example for numbers
        static bool ContainsNumbers(string password)
        {
            bool containsNumbers = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                    containsNumbers = true;
            }
            return containsNumbers;
        }

        // checks password example for special characters
        static bool ContainsSpecialCharacter(string password)
        {
            bool containsSpecialCharacter = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (!char.IsLetterOrDigit(password[i]))
                    containsSpecialCharacter = true;
            }
            return containsSpecialCharacter;
        }

        // checks password example for sequential numbers
        static bool ContainsSequentialNumbers(string password)
        {
            bool containsSequentialNumbers = false;
            for (int i = 0; i < password.Length - 3; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    if (password[i + 1] == password[i] + 1
                        && password[i + 2] == password[i] + 2
                        && password[i + 3] == password[i] + 3)
                        containsSequentialNumbers = true;
                }
            }
            return containsSequentialNumbers;
        }

        // checks password example for repeated characters
        static bool ContainsRepeatedCharacters(string password)
        {
            bool containsRepeatedCharacters = false;
            for (int i = 0; i < password.Length - 3; i++)
            {
                if (password[i] == password[i + 1]
                    && password[i] == password[i + 2]
                    && password[i] == password[i + 3])
                    containsRepeatedCharacters = true;
            }
            return containsRepeatedCharacters;
        }
    }
}
