using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        private static IEnumerable<string> exitOptions = new List<string>
        {
            "exit",
            "quit",
            ":q"
        };

        static void Main(string[] args)
        {
            Console.WriteLine($"You may exit at anytime using {string.Join(", ", exitOptions)}");

            string userInput = string.Empty;
            do
            {
                Console.Write("Choose a year: ");
                userInput = Console.ReadLine();

                if (String.Equals(userInput, "2020", StringComparison.CurrentCultureIgnoreCase))
                {
                    Year2020(ref userInput);
                }

            } while (!IsExitCondition(userInput));
        }

        private static void Year2020(ref string userInput)
        {
            do
            {
                Console.WriteLine("    1) Report Repair");
                Console.WriteLine("Choose a Day: ");
                userInput = Console.ReadLine();

                if (userInput.TrimStart().StartsWith('1'))
                {

                }
            } while (!IsExitCondition(userInput) && !IsBreakCondition(userInput));
        }

        private static bool IsBreakCondition(string userInput)
        {
            return String.Equals(userInput, "break", StringComparison.CurrentCultureIgnoreCase);
        }

        private static bool IsExitCondition(string userInput)
        {
            return exitOptions.Any(exitOption => String.Equals(userInput, exitOption, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}