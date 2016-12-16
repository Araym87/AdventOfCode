using System;
using System.Text;
using AdventOfCode2016.General;

namespace AdventOfCode2016.Day16
{
    public class DaySixteen : DayResult
    {
        #region Constants

        private const string INPUT = "10011111011011001";

        #endregion

        #region Protected Methods

        protected override void FirstPart()
        {
            const int length = 272;
            var currentString = INPUT;
            while (currentString.Length < length)
            {
                currentString = PerformStep(currentString);
            }

            Console.WriteLine($"Checksum for disk with length {length} is {GetCheckSum(currentString.Substring(0, length))}");
        }

        protected override void SecondPart()
        {
            const int length = 35651584;
            var currentString = INPUT;
            while (currentString.Length < length)
            {
                currentString = PerformStep(currentString);
            }

            Console.WriteLine($"Checksum for disk with length {length} is {GetCheckSum(currentString.Substring(0, length))}");
        }

        #endregion

        #region Private Methods

        private string PerformStep(string input)
        {
            var currentStep = new StringBuilder();
            currentStep.Append(ReverseString(input));
            currentStep.Replace('0', 'a');
            currentStep.Replace('1', '0');
            currentStep.Replace('a', '1');
            return input + "0" + currentStep;
        }

        private string ReverseString(string toReverse)
        {
            var array = toReverse.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        private string GetCheckSum(string word)
        {
            var stringBuilder = new StringBuilder();
            while (word.Length%2 == 0)
            {
                stringBuilder.Clear();
                for (var i = 0; i < word.Length; i+=2)
                {
                    stringBuilder.Append(word[i] == word[i + 1] ? "1" : "0");
                }
                word = stringBuilder.ToString();
            }
            return word;
        }

        #endregion

        #region Overriden Methods

        protected override string GetStringDay()
        {
            return "Sixteen";
        }

        #endregion
    }
}
