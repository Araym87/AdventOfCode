using System;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day1
{
    public class Day1 : DayResult
    {
        #region Protected Methods

        protected override void FirstPart()
        {
            var inputLine = AdventOfCodeHelper.FileReader("Inputs\\Input1.txt").First();

            var x = Regex.Matches(inputLine, "([0-9])\\1+");
            var result = 0;
            for (var i = 0; i < x.Count; i++)
            {
                var number = GetNumeric(x[i].Value[0]);
                result += number * (x[i].Length - 1);
            }
            if (inputLine.Last() == inputLine.First())
            {
                var number = GetNumeric(inputLine.First());
                var repetition = 1;
                for (var i = 1; i < inputLine.Length; i++)
                {
                    if (inputLine[i] != inputLine[i - 1])
                        break;
                }
                result += repetition * number;
            }

            Console.WriteLine($"Solution for my CAPTCHA is {result}");
        }

        protected override void SecondPart()
        {
            var inputLine = AdventOfCodeHelper.FileReader("Inputs\\Input1.txt").First();

            var result = 0;
            for (var i = 0; i < inputLine.Length / 2; i++)
            {
                if (inputLine[i] == inputLine[(i + inputLine.Length / 2)])
                {
                    result += GetNumeric(inputLine[i]);
                }
            }

            Console.WriteLine($"Solution for my CAPTCHA is {result*2}");
        }

        protected override string GetStringDay()
        {
            return "One";
        }

        #endregion

        #region Private Methods

        private int GetNumeric(char c)
        {
            return (int)char.GetNumericValue(c);
        }

        #endregion
    }
}
