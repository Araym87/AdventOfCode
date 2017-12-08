using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2016.General;

namespace AdventOfCode2016.Day18
{
    public class DayEighteen : DayResult
    {
        #region Constants

        private const string INPUT = "^..^^.^^^..^^.^...^^^^^....^.^..^^^.^.^.^^...^.^.^.^.^^.....^.^^.^.^.^.^.^.^^..^^^^^...^.....^....^.";

        #endregion

        #region Protected Methods

        protected override void FirstPart()
        {
            var length = 40;
            var items = new List<bool[]> { ConvertInputString(INPUT) };

            for (var i = 1; i < length; i++)
            {
                items.Add(ProcessRow(items[i - 1]));
            }

            var sum = 0;
            items.ForEach(i => sum += i.Count(j => !j));
            Console.WriteLine($"{sum}");
        }

        protected override void SecondPart()
        {
            var length = 400000;
            var items = new List<bool[]> { ConvertInputString(INPUT) };

            for (var i = 1; i < length; i++)
            {                
                items.Add(ProcessRow(items[i-1]));
            }

            var sum = 0;
            items.ForEach(i => sum += i.Count(j => !j));
            Console.WriteLine($"{sum}");
        }

        #endregion

        #region Private Methods

        private bool[] ProcessRow(bool[] previousRow)
        {
            var currentRow = new bool[previousRow.Length];
            var previous = new List<bool>();

            for (var j = 0; j < previousRow.Length; j++)
            {
                if (j == 0)
                {
                    previous.Add(false);
                    previous.Add(previousRow[j]);
                    previous.Add(previousRow[j + 1]);
                }
                else if (j == previousRow.Length - 1)
                {
                    previous.RemoveAt(0);
                    previous.Add(false);
                }
                else
                {
                    previous.RemoveAt(0);
                    previous.Add(previousRow[j + 1]);
                }

                currentRow[j] = ApplyConditions(previous);

            }

            return currentRow;            
        }

        private bool[] ConvertInputString(string input)
        {
            var startRow = new bool[input.Length];
            for (var i = 0; i < input.Length; i++)
            {
                startRow[i] = input[i] != '.';
            }

            return startRow;
        }

        private bool ApplyConditions(IList<bool> previousRow)
        {
            // Its left and center tiles are traps, but its right tile is not.
            if (previousRow[0] && previousRow[1] && !previousRow[2])
                return true;
            // Its center and right tiles are traps, but its left tile is not.
            if (!previousRow[0] && previousRow[1] && previousRow[2])
                return true;
            // Only its left tile is a trap.
            if (previousRow[0] && !previousRow[1] && !previousRow[2])
                return true;
            // Only its right tile is a trap.
            if (!previousRow[0] && !previousRow[1] && previousRow[2])
                return true;

            return false;
        }

        #endregion

        #region Protected Methods

        protected override string GetStringDay()
        {
            return "Eighteen";
        }

        #endregion
    }
}
