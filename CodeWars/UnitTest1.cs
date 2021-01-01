using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodeWars
{
    [TestClass]
    public class UnitTest1
    {
        private const double EulerMascheroniConstant = 0.57721566490153286060651209008240243104215933593992;

        [TestMethod]
        public void NumberOfTrailingZeroesForNFactorial()
        {
            var factorialTests = new int[] { 6, 12 };
            foreach(var factorial in factorialTests)
            {
                var zeroes = CalculateNumberOfZeroesForFactorialOfN(factorial);
                Console.WriteLine($"{factorial}! has {zeroes} trailing zeroes.");
            }
        }

        private long CalculateNumberOfZeroesForFactorialOfN(int factorial)
        {
            double seriesSumExpression(int step)
            {
                return Math.Pow(-1, step) * (RiemannZeta(step) - 1) * (Math.Pow(factorial, step) / step);
            }

            var logOfFactorial = -Math.Log10(1 + factorial) + factorial * (1 - EulerMascheroniConstant) + SeriesSum(2, factorial+10, seriesSumExpression);

            return (long)logOfFactorial;
        }

        private static double SeriesSum(int min, int max, Func<int, double> innerExpression)
        {
            var seriesSum = 0.0;

            for (int i = min; i < max; i++)
            {
                seriesSum += innerExpression.Invoke(i);
            }

            return seriesSum;
        }

        private static double RiemannZeta(int n)
        {
            return SeriesSum(1, n+10, (int k) => 1 / Math.Pow(k, n));
        }
    }
}
