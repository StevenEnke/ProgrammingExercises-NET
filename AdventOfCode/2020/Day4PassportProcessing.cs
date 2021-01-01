using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class Day4PassportProcessing
    {
        const int EntryTypeGroup = 1;
        const int EntryValueGroup = 2;
        const string passportEntryPattern = @"([^\s]+):([^\s]+)";
        const string heightValuePattern = @"(\d+)(cm|in)";
        const string hairColorPattern = @"^#[a-f0-9]{6}$";
        const string eyeColorPattern = @"(amb|blu|brn|gry|grn|hzl|oth)";
        const string passportIdPattern = @"^\d{9}$";

        public static int HasExpectedEntries(string filePath)
        {
            var validPassports = 0;
            if (File.Exists(filePath))
            {
                string passport = string.Empty;
                foreach(var passportLine in File.ReadLines(filePath))
                {
                    if (string.IsNullOrWhiteSpace(passportLine))
                    {
                        if (passport.Contains("byr")
                            && passport.Contains("iyr")
                            && passport.Contains("eyr")
                            && passport.Contains("hgt")
                            && passport.Contains("hcl")
                            && passport.Contains("ecl")
                            && passport.Contains("pid"))
                        {
                            validPassports++;
                        }

                        passport = string.Empty;
                    }
                    else
                    {
                        passport += $" {passportLine}";
                    }
                }
            }

            return validPassports;
        }

        public static int HasValidEntries(string filePath)
        {
            var passportEntryFinder = new Regex(passportEntryPattern);

            var validPassports = 0;
            if (File.Exists(filePath))
            {
                string passport = string.Empty;
                foreach (var passportLine in File.ReadLines(filePath))
                {
                    if (string.IsNullOrWhiteSpace(passportLine))
                    {
                        var passportDissected = passportEntryFinder.Matches(passport);
                        if (HasValidBirthdate(passportDissected)
                            && HasValidIssueYear(passportDissected)
                            && HasValidExpirationYear(passportDissected)
                            && HasValidHeight(passportDissected)
                            && HasValidHairColor(passportDissected)
                            && HasValidEyeColor(passportDissected)
                            && HasValidPassportId(passportDissected))
                        {
                            validPassports++;
                        }

                        passport = string.Empty;
                    }
                    else
                    {
                        passport += $" {passportLine}";
                    }
                }
            }

            return validPassports;
        }
        
        private static bool HasValidBirthdate(IEnumerable<Match> passportEntries)
        {
            return passportEntries
                .Where(entry => string.Equals("byr", entry.Groups[EntryTypeGroup].Value))
                .Any(birthdate => int.TryParse(birthdate.Groups[EntryValueGroup].Value, out var result)
                && result is >= 1920 and <= 2002);
        }


        private static bool HasValidIssueYear(IEnumerable<Match> passportEntries)
        {
            return passportEntries
                .Where(entry => string.Equals("iyr", entry.Groups[EntryTypeGroup].Value))
                .Any(issuance => int.TryParse(issuance.Groups[EntryValueGroup].Value, out var result)
                && result is >= 2010 and <= 2020);
        }

        private static bool HasValidExpirationYear(IEnumerable<Match> passportEntries)
        {
            return passportEntries
                .Where(entry => string.Equals("eyr", entry.Groups[EntryTypeGroup].Value))
                .Any(expiration => int.TryParse(expiration.Groups[EntryValueGroup].Value, out var result)
                && result is >= 2020 and <= 2030);
        }

        private static bool HasValidHeight(IEnumerable<Match> passportEntries)
        {
            return passportEntries
                .Where(entry => string.Equals("hgt", entry.Groups[EntryTypeGroup].Value))
                .Select(height => Regex.Match(height.Groups[EntryValueGroup].Value, heightValuePattern))
                .Select(heightValue => (Value: heightValue.Groups[EntryTypeGroup].Value, Unit: heightValue.Groups[EntryValueGroup].Value))
                .Any(heightValue => int.TryParse(heightValue.Value, out int height)
                                    && ((heightValue.Unit.Equals("cm", System.StringComparison.OrdinalIgnoreCase) && height is >= 150 and <= 193)
                                     || (heightValue.Unit.Equals("in", System.StringComparison.Ordinal) && height is >= 59 and <= 76)));
        }

        private static bool HasValidHairColor(IEnumerable<Match> passportEntries)
        {
            return passportEntries
                .Where(entry => string.Equals("hcl", entry.Groups[EntryTypeGroup].Value))
                .Any(hairColor => Regex.IsMatch(hairColor.Groups[EntryValueGroup].Value, hairColorPattern));
        }

        private static bool HasValidEyeColor(IEnumerable<Match> passportEntries)
        {
            return passportEntries
                .Where(entry => string.Equals("ecl", entry.Groups[EntryTypeGroup].Value))
                .Any(eyeColor => Regex.IsMatch(eyeColor.Groups[EntryValueGroup].Value, eyeColorPattern));
        }

        private static bool HasValidPassportId(IEnumerable<Match> passportEntries)
        {
            return passportEntries
                .Where(entry => string.Equals("pid", entry.Groups[EntryTypeGroup].Value))
                .Any(passportId => Regex.IsMatch(passportId.Groups[EntryValueGroup].Value, passportIdPattern));
        }
    }
}
