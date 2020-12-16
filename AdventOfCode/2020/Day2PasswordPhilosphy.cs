using System;
namespace AdventOfCode
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class Day2PasswordPhilosophy
    {
        private const int PasswordPolicyCaptureGroups = 5; // min, max, char enforced, password, entire match.
        private const string PasswordPolicyPattern = @"(\d+)-(\d+)\s(\w): (\w+)";
        private static readonly Regex PasswordPolicyRegex = new Regex(PasswordPolicyPattern);

        public static int PasswordValidator(string fileInput)
        {
            int validPasswords = 0;
            if (File.Exists(fileInput))
            {
                foreach (var passwordLine in File.ReadLines(fileInput))
                {
                    // Password line should have 4 components. Skip otherwise.
                    var captureGroups = PasswordPolicyRegex.Match(passwordLine).Groups;
                    if (captureGroups.Count == PasswordPolicyCaptureGroups)
                    {
                        // Group 0 is whole match which we do not need here.
                        int.TryParse(captureGroups[1].Value, out var minRepeat);
                        int.TryParse(captureGroups[2].Value, out var maxRepeat);
                        var characterToEnforce = captureGroups[3].Value[0];
                        var password = captureGroups[4].Value;

                        var characterCount = password.Count(c => c.Equals(characterToEnforce));
                        if(characterCount >= minRepeat && characterCount <= maxRepeat)
                        {
                            validPasswords++;
                        }
                    }
                }
            }

            return validPasswords;
        }
    }
}