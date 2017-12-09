using System;
using System.Linq;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day9
{
    public class Day9 : DayResult
    {
        #region Protected Methods

        protected override void FirstPart()
        {
            var inputLine = AdventOfCodeHelper.FileReader("Inputs\\Input9.txt").First();

            bool keepNextChar = false;
            var garbageStart = -1;
            for (var i = 0; i < inputLine.Length; i++)
            {
                if (keepNextChar)
                {
                    keepNextChar = false;
                    continue;
                }

                if (inputLine[i] == '!')
                {
                    keepNextChar = true;
                    continue;
                }

                if (inputLine[i] == '<' && garbageStart == -1)
                {
                    garbageStart = i;
                    continue;
                }

                if (inputLine[i] == '>')
                {
                    inputLine = inputLine.Remove(garbageStart, i - garbageStart + 1);
                    i = garbageStart;
                    garbageStart = -1;
                }
            }

            var position = 0;
            var points = 0;
            BracesRecursion(inputLine, ref position, 0, ref points);

            Console.WriteLine($"Total scores of all groups are {points}");
        }

        protected override void SecondPart()
        {
            var inputLine = AdventOfCodeHelper.FileReader("Inputs\\Input9.txt").First();

            bool keepNextChar = false;
            var garbageStart = -1;
            var numberOfEscapedChars = 0;
            var garbageChars = 0;
            for (var i = 0; i < inputLine.Length; i++)
            {
                if (keepNextChar)
                {
                    keepNextChar = false;
                    numberOfEscapedChars += 2;
                    continue;
                }

                if (inputLine[i] == '!')
                {
                    keepNextChar = true;
                    continue;
                }

                if (inputLine[i] == '<' && garbageStart == -1)
                {
                    garbageStart = i;
                    continue;
                }

                if (inputLine[i] == '>')
                {
                    inputLine = inputLine.Remove(garbageStart, i - garbageStart + 1);
                    garbageChars += i - garbageStart + 1 - 2 - numberOfEscapedChars;
                    i = garbageStart;
                    garbageStart = -1;
                    numberOfEscapedChars = 0;
                }
            }

            Console.WriteLine($"Length of garbage characted is {garbageChars}");
        }

        protected override string GetStringDay()
        {
            return "Nine";
        }

        #endregion

        #region Private Methods

        private void BracesRecursion(string line, ref int position, int levelOfRecursion, ref int points)
        {
            for (; position < line.Length; position++)
            {
                if (line[position] == '{')
                {
                    position++;
                    BracesRecursion(line, ref position, levelOfRecursion + 1, ref points);
                    continue;
                }
                if (line[position] == '}')
                {
                    points += levelOfRecursion;
                    return;
                }
            }
        }

        #endregion
    }
}
