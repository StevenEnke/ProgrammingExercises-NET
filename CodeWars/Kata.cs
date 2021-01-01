using System;
using System.Linq;

public static class Kata
{
    public static string Solve(string a, string b)
    {
        var aCharacterSet = a.Select(c => c);
        var bCharacterSet = b.Select(c => c);
        var commonElements = a.Intersect(b);
        var uniqueElements = (a.Concat(b)).Where(c => !commonElements.Contains(c));
        return string.Join(string.Empty, uniqueElements);
    }
}