namespace AdventOfCode
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class Day1ReportRepair
    {
        public static int FixExpenseReport2ndDegree(string filePath)
        {
            if (File.Exists(filePath))
            {
                var expenses = File.ReadAllLines(filePath).Select(line => int.Parse(line));
                foreach (var expense in expenses)
                {
                    var possibleExpense = 2020 - expense;
                    var possibleExpenseFound = expenses.Contains(possibleExpense);
                    if (possibleExpenseFound)
                    {
                        return expense * possibleExpense;
                    }
                }
            }

            return -1;
        }

        public static int FixExpenseReport3rdDegree(string filePath)
        {
            if(File.Exists(filePath))
            {
                var expenses = File.ReadAllLines(filePath).Select(line => int.Parse(line));
                foreach(var possibleFirstExpense in expenses)
                {
                    var possibleSecondExpense = 2020 - possibleFirstExpense;
                    foreach(var secondExpense in expenses)
                    {
                        var possibleThirdExpense = possibleSecondExpense - secondExpense;
                        var possibleExpenseTripletFound = expenses.Contains(possibleThirdExpense);
                        if(possibleExpenseTripletFound)
                        {
                            return possibleThirdExpense * secondExpense * possibleFirstExpense;
                        }
                    }
                }
            }

            return -1;
        }

        // TODO: Do this generically.
        //public static int FixExpenseReportNthDegree(string filePath, int numberOfDegrees, int startExpense)
        //{
        //    if(File.Exists(filePath))
        //    {
        //        var expenses = File.ReadAllLines(filePath).Select(line => int.Parse(line));
        //        foreach(var expense in expenses)
        //        {                    
        //            var possibleExpenseList = new List<int>();
        //            possibleExpenseList.Add(expense);
        //            while(numberOfDegrees-- > 0)
        //            {
                        
        //            }
        //        }
        //    }

        //    return -1;
        //}
    }
}