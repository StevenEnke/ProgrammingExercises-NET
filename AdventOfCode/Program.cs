using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;

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
                Console.WriteLine("    2) Password Philosophy");
                Console.Write("Choose a Day: ");
                userInput = Console.ReadLine();

                if (userInput.TrimStart().StartsWith('1'))
                {
                    Console.Write("Enter file path: ");
                    var inputFile = Console.ReadLine();
                    if(String.IsNullOrWhiteSpace(inputFile))
                    {
                        inputFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "2020", "Inputs", "Day1RepairReport");
                        Console.WriteLine($"Path not given. Defaulting to: {inputFile}");
                    }

                    Console.WriteLine($"Result for 2nd Degree: {Day1ReportRepair.FixExpenseReport2ndDegree(inputFile)}");
                    Console.WriteLine($"Result for 3rd Degree: {Day1ReportRepair.FixExpenseReport3rdDegree(inputFile)}");
                }
                else if(userInput.TrimStart().StartsWith('2'))
                {
                    Console.Write("Enter file path: ");
                    var inputFile = Console.ReadLine();
                    if(String.IsNullOrWhiteSpace(inputFile))
                    {
                        inputFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "2020", "Inputs", "Day2PasswordPhilosophy");
                        Console.WriteLine($"Path not given. Defaulting to: {inputFile}");
                    }

                    Console.WriteLine($"Number of valid passwords: {Day2PasswordPhilosophy.PasswordValidator(inputFile)}");
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