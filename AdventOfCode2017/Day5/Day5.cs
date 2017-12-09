using System;
using System.Collections.Generic;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day5
{
    public class Day5 : DayResult
    {
        #region Protected Methods

        protected override void FirstPart()
        {
            var instructions = new List<int>();
            foreach (var line in AdventOfCodeHelper.FileReader("Inputs\\Input5.txt"))
                instructions.Add(int.Parse(line));

            var steps = 0;
            var currentPosition = 0;
            while (true)
            {
                steps++;
                var nextPosition = currentPosition + instructions[currentPosition];
                instructions[currentPosition] = instructions[currentPosition] + 1;
                if (nextPosition < 0 || nextPosition >= instructions.Count)
                    break;

                currentPosition = nextPosition;
            }
            Console.WriteLine($"Number of steps to reach exit {steps}");
        }

        protected override void SecondPart()
        {
            var instructions = new List<int>();
            foreach (var line in AdventOfCodeHelper.FileReader("Inputs\\Input5.txt"))
                instructions.Add(int.Parse(line));

            var steps = 0;
            var currentPosition = 0;
            while (true)
            {
                steps++;
                var nextPosition = currentPosition + instructions[currentPosition];
                instructions[currentPosition] = instructions[currentPosition] >= 3 ? instructions[currentPosition] - 1 : instructions[currentPosition] + 1;
                if (nextPosition < 0 || nextPosition >= instructions.Count)
                    break;

                currentPosition = nextPosition;
            }
            Console.WriteLine($"Number of steps to reach exit {steps}");
        }

        protected override string GetStringDay()
        {
            return "Five";
        }

        #endregion
    }
}
