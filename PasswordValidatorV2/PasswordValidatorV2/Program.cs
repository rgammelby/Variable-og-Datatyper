using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidatorV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        #region Controller

        static void Start()
        {
            // main loop
            while(true)
            {
                Console.Clear();
                Introduction();

                var password = Input();
                var validity = 0;

                bool legalInput = InputValidator(password);

                if (legalInput)
                    validity = PasswordValidator(password);

                var error = ErrorMessage();

                if (validity == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your password is NOT valid.");
                    Console.WriteLine(error);
                }
                else if (validity == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Your password is valid, but weak.");
                    Console.WriteLine(error);
                }
                else if (validity == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congratulations. Your password is valid!");
                }

                Console.ResetColor();

                var selection = Console.ReadKey(true).Key;

                switch (selection)
                {
                    case ConsoleKey.Enter:
                        break;

                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        #endregion

        #region View

        // welcome and rules introduction
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
        
        // isolates error and returns appropriate error message
        static string ErrorMessage()
        {
            int[] errorCodes = new int[EvaluatedCriteria.Length];

            var error = "";

            for (int i = 0; i < EvaluatedCriteria.Length; i++)
            {
                if (!EvaluatedCriteria[i])
                    errorCodes[i] = i + 1;
                else
                    errorCodes[i] = 0;
            }

            // debug info
            /*
            foreach (int i in errorCodes)
            {
                Console.WriteLine("Active error: " + i.ToString());
            }

            foreach (bool b in EvaluatedCriteria)
            {
                Console.WriteLine(b.ToString());
            }*/

            for (int i = 0; i < errorCodes.Length; i++)
            {
                switch(errorCodes[i])
                {
                    case 1:
                        error = $"Error code: {errorCodes[0]}. Password must contain a mix of upper and lower case letters. ";
                        return error;

                    case 2:
                        error += $"Error code: {errorCodes[1]}. Password must contain a mix of upper and lower case letters. ";
                        return error;

                    case 3:
                        error += $"Error code: {errorCodes[2]}. Password must be between 12 and 64 characters in length. ";
                        return error;

                    case 4:
                        error += $"Error code: {errorCodes[3]}. Password must contain a mix of letters and numbers. ";
                        return error;

                    case 5:
                        error += $"Error code: {errorCodes[4]}. Password must contain at least one (1) special character (eg. \\, \", etc.). ";
                        return error;

                    case 6:
                        error += $"Error code: {errorCodes[5]}. Password shouldn't contain sequential numbers (eg. 1234, 4567). ";
                        return error;

                    case 7:
                        error += $"Error code: {errorCodes[6]}. Password shouldn't contain four or more repeated characters (eg. BBBB, 9999). ";
                        return error;
                }
            }
            return error;
        }

        #endregion

        #region Model

        // bool array for storing evaluated criteria values (1/0)
        static bool[] EvaluatedCriteria = new bool[7];

        // evalutes password validity, returns validity value
        static int PasswordValidator(string password)
        {
            const int INVALID = 0;
            const int WEAK = 1;
            const int VALID = 2;

            // all true for strong & valid
            bool containsUpper = ContainsUpper(password);
            bool containsLower = ContainsLower(password);
            bool passwordLength = PasswordLength(password);
            bool containsNumbers = ContainsNumbers(password);
            bool containsSpecialCharacter = ContainsSpecialCharacter(password);
            bool containsNoSequentialNumbers = ContainsNoSequentialNumbers(password);
            bool containsNoRepeatedCharacters = ContainsNoRepeatedCharacters(password);

            // if password lives up to first 5 criteria:
            if (
                containsUpper
                && containsLower
                && passwordLength
                && containsNumbers
                && containsSpecialCharacter)
            {
                // if password lives up to 2 extra criteria:
                if (containsNoSequentialNumbers && containsNoRepeatedCharacters)
                    return VALID;
                else
                    return WEAK;
            }
            else
            {
                return INVALID;
            }
        }

        // retrieve user password input
        static string Input()
        {
            Console.WriteLine("Please enter your password: ");
            var password = Console.ReadLine();

            return password;
        }

        // checks whether user input is valid
        static bool InputValidator(string input)
        {
            if (!string.IsNullOrEmpty(input))
                return true;
            else
                return false;
        }

        // checks password example for uppercase letters
        static bool ContainsUpper(string password)
        {
            bool containsUpper = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsUpper(password[i]))
                {
                    containsUpper = true;
                    EvaluatedCriteria[0] = true;
                }
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
                {
                    containsLower = true;
                    EvaluatedCriteria[1] = true;
                }
            }
            return containsLower;
        }

        // checks if the password example length is acceptable
        static bool PasswordLength(string password)
        {
            bool passwordLength = false;

            if (password.Length <= 64 && password.Length >= 12)
            {
                passwordLength = true;
                EvaluatedCriteria[2] = true;
            }

            return passwordLength;
        }

        // checks password example for numbers
        static bool ContainsNumbers(string password)
        {
            bool containsNumbers = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    containsNumbers = true;
                    EvaluatedCriteria[3] = true;
                }
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
                {
                    containsSpecialCharacter = true;
                    EvaluatedCriteria[4] = true;
                }
            }
            return containsSpecialCharacter;
        }

        // checks password example for sequential numbers
        static bool ContainsNoSequentialNumbers(string password)
        {
            bool containsNoSequentialNumbers = true;
            EvaluatedCriteria[5] = true;
            for (int i = 0; i < password.Length - 3; i++)
            {
                if (password[i + 1] == password[i] + 1
                    && password[i + 2] == password[i] + 2
                    && password[i + 3] == password[i] + 3)
                {
                    containsNoSequentialNumbers = false;
                    EvaluatedCriteria[5] = false;
                }
            }
            return containsNoSequentialNumbers;
        }

        // checks password example for repeated characters
        static bool ContainsNoRepeatedCharacters(string password)
        {
            bool containsNoRepeatedCharacters = true;
            EvaluatedCriteria[6] = true;
            for (int i = 0; i < password.Length - 3; i++)
            {
                if (password[i] == password[i + 1]
                    && password[i] == password[i + 2]
                    && password[i] == password[i + 3])
                {
                    containsNoRepeatedCharacters = false;
                    EvaluatedCriteria[6] = false;
                }
            }
            return containsNoRepeatedCharacters;
        }

        #endregion
    }
}
