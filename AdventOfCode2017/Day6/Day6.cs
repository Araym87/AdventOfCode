using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day6
{
    public class Day6 : DayResult
    {
        #region Protected Methods

        protected override void FirstPart()
        {
            var actualArray = AdventOfCodeHelper.FileReader("Inputs\\Input6.txt").First().Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => Convert.ToInt32(i)).ToList();

            var allCombinations = new Dictionary<List<int>, int>(new IntListComparer()) {{actualArray, 0}};

            var step = 0;
            while (true)
            {
                actualArray = actualArray.ToList();
                var indexOfMax = actualArray.IndexOf(actualArray.Max());
                var itemsToMove = actualArray[indexOfMax];
                actualArray[indexOfMax] = 0;

                var indexToAlter = indexOfMax + 1;
                while (itemsToMove > 0)
                {
                    if (indexToAlter >= actualArray.Count)
                        indexToAlter = 0;

                    actualArray[indexToAlter++]++;
                    itemsToMove--;
                }

                step++;

                if (!allCombinations.ContainsKey(actualArray))
                    allCombinations.Add(actualArray, step);
                else
                {
                    Console.WriteLine($"{step} redistribution cycles must be performed.");
                    break;
                }

            }
        }

        protected override void SecondPart()
        {
            var actualArray = AdventOfCodeHelper.FileReader("Inputs\\Input6.txt").First().Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => Convert.ToInt32(i)).ToList();

            var allCombinations = new Dictionary<List<int>, int>(new IntListComparer()) { { actualArray, 0 } };

            var step = 0;
            while (true)
            {
                actualArray = actualArray.ToList();
                var indexOfMax = actualArray.IndexOf(actualArray.Max());
                var itemsToMove = actualArray[indexOfMax];
                actualArray[indexOfMax] = 0;

                var indexToAlter = indexOfMax + 1;
                while (itemsToMove > 0)
                {
                    if (indexToAlter >= actualArray.Count)
                        indexToAlter = 0;

                    actualArray[indexToAlter++]++;
                    itemsToMove--;
                }

                step++;

                if (!allCombinations.ContainsKey(actualArray))
                    allCombinations.Add(actualArray, step);
                else
                {
                    var lastStep = allCombinations[actualArray];
                    Console.WriteLine($"{step - lastStep} redistribution steps was performed to reach known state");
                    break;
                }

            }
        }

        protected override string GetStringDay()
        {
            return "Six";
        }

        #endregion
    }
}
