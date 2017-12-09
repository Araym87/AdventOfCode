using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode.Common.General;

namespace AdventOfCode2016.Day14
{
    public class DayFourteen : DayResult
    {
        #region Constants

        private const string REGULAR_ONE = @"(.)\1{2,}";
        private const string REGULAR_TWO = @"(.)\1{4,}";
        private const int ITEM = 63;
        private const int YEAR = 2016;
        private const int THOUSAND = 1000;

        #endregion

        #region Fields

        private readonly Dictionary<int, char> threeChars = new Dictionary<int, char>();
        private readonly List<int> foundedInts = new List<int>();
        private readonly MD5 mdAlgorithm = MD5.Create();

        #endregion

        #region Protected Methods

        protected override void FirstPart()
        {
            var salt = "qzyelonm";
            threeChars.Clear();
            foundedInts.Clear();

            var found = -1;
            for (var i = 0; i < decimal.MaxValue; i++)
            {
                if (found != -1 && i == found)
                    break;

                var hash = ReturnBytesFromHashedPassword(salt, i);
                FoundSubstrings(hash, i);

                if (foundedInts.Count >= ITEM && found == -1)
                {
                    found = i + THOUSAND;
                }

                if (i >= THOUSAND)
                {
                    threeChars.Remove(i-THOUSAND);
                }
            }
            Console.WriteLine($"Number of 64th key is {foundedInts.OrderBy(j => j).ToList()[ITEM]}");
        }

        protected override void SecondPart()
        {
            var salt = "qzyelonm";
            threeChars.Clear();
            foundedInts.Clear();

            for (var i = 0; i < decimal.MaxValue; i++)
            {
                var hash = ReturnBytesFromHashedPassword(salt, i);
                for (var j = 1; j <= YEAR; j++)
                {
                    hash = ReturnBytesFromHashedPassword(hash);
                }

                FoundSubstrings(hash, i);

                if (foundedInts.Count >= ITEM)
                {
                    Console.WriteLine($"Number of 64th key is {foundedInts.OrderBy(j => j).ToList()[ITEM]}");
                    break;
                }

                if (i >= THOUSAND)
                {
                    threeChars.Remove(i - THOUSAND);
                }
            }           
        }

        #endregion

        #region Private Methods

        private string ReturnBytesFromHashedPassword(string salt, decimal modifiedNumber = -1)
        {
            var bytes = modifiedNumber == -1 ? mdAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(salt)) : mdAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(salt + modifiedNumber));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        private void FoundSubstrings(string hash, int i)
        {
            var matchesFive = Regex.Matches(hash, REGULAR_TWO);
            foreach (Match match in matchesFive)
            {
                if (match.Length < 5)
                    continue;

                var letter = match.Value[4];
                foreach (var source in threeChars.Where(j => j.Value.Equals(letter)).Select(k => k.Key).ToList())
                {
                    foundedInts.Add(source);
                    threeChars.Remove(source);
                }
            }

            var matches = Regex.Matches(hash, REGULAR_ONE);
            foreach (Match match in matches)
            {
                if (match.Length < 3)
                    continue;

                threeChars.Add(i, match.Value[2]);
                break;
            }
        }

        #endregion

        #region Overriden Methods

        protected override string GetStringDay()
        {
            return "Fourteen";
        }

        #endregion
    }
}
