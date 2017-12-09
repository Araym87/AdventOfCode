using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode.Common.General;

namespace AdventOfCode2016.Day6
{
    public class DaySix : DayResult
    {
        #region Fields

        private readonly List<Dictionary<char, int>> frequentialForPosition = new List<Dictionary<char, int>>();

        #endregion

        #region Protected Methods

        protected override void FirstPart()
        {
            frequentialForPosition.Clear();
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input6.txt")))
            {
                FrequentialAnalysis(line.Trim(), frequentialForPosition);
            }
            var result = frequentialForPosition.Select(top => top.ToList().OrderByDescending(i => i.Value).First().Key.ToString())
                .Aggregate((l, m) => l + m);
            Console.WriteLine($"Send word is {result}");

        }

        protected override void SecondPart()
        {
            frequentialForPosition.Clear();
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input6.txt")))
            {
                FrequentialAnalysis(line.Trim(), frequentialForPosition);
            }
            var result = frequentialForPosition.Select(top => top.ToList().OrderBy(i => i.Value).First().Key.ToString())
                .Aggregate((l, m) => l + m);
            Console.WriteLine($"Send word is {result}");
        }

        protected override string GetStringDay()
        {
            return "Six";
        }

        #endregion

        #region Private Methods

        private void FrequentialAnalysis(string input, IList<Dictionary<char, int>> freq)
        {
            if (frequentialForPosition.Count == 0)
            {
                for (var i = 0; i < input.Length; i++)
                {
                    frequentialForPosition.Add(new Dictionary<char, int>());
                }
            }

            for (var i = 0; i < input.Length; i++)
            {
                var @char = input[i];
                var dict = freq[i];
                if (!dict.ContainsKey(@char))
                    dict.Add(@char, 0);

                dict[@char] += 1;
            }
        }

        #endregion
    }
}
