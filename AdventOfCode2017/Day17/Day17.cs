using System;
using System.Collections.Generic;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day17
{
    public class Day17 : DayResult
    {
        #region Constants

        private const int INPUT = 337;

        #endregion

        #region Protected Methods

        protected override void FirstPart()
        {
            var maximumNumber = 2017;

            var numberToInsert = 0;
            var currentIndex = 0;
            var buffer = new List<int> {numberToInsert++};
            while (numberToInsert <= maximumNumber)
            {
                currentIndex = (currentIndex + INPUT) % buffer.Count + 1;
                buffer.Insert(currentIndex, numberToInsert++);
            }

            Console.WriteLine($"Value for short-cutting the spin lock is {buffer[buffer.IndexOf(maximumNumber) + 1]}");

        }

        protected override void SecondPart()
        {
            var maximumNumber = 50000000;

            var numberToInsert = 1;
            var currentIndex = 0;
            var lastValue = -1;
            while (numberToInsert <= maximumNumber)
            {
                currentIndex = (currentIndex + INPUT) % numberToInsert + 1;
                if (currentIndex == 1)
                    lastValue = numberToInsert;
      
                numberToInsert++;
            }

            Console.WriteLine($"Value for short-cutting the spin lock is {lastValue}");
        }

        protected override string GetStringDay()
        {
            return "Seventeen";
        }

        #endregion
    }
}
