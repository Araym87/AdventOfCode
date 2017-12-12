using System;
using System.Linq;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day11
{
    public class Day11 : DayResult
    {
        #region Protected Methods

        protected override void FirstPart()
        {
            var input = AdventOfCodeHelper.FileReader("Inputs\\Input11.txt").First()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(i => Enum.Parse(typeof(Directions), i, true)).Cast<Directions>().ToList();

            var point = new ThreeDeePoint();
            foreach (var directionse in input)
            {
                point.Move(directionse);
            }

            Console.WriteLine($"The fewest steps to reach child process is {point.CurrentDistance()}");
        }

        protected override void SecondPart()
        {
            var input = AdventOfCodeHelper.FileReader("Inputs\\Input11.txt").First()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(i => Enum.Parse(typeof(Directions), i, true)).Cast<Directions>().ToList();

            var point = new ThreeDeePoint();
            var longestDistance = -1;
            foreach (var directionse in input)
            {
                point.Move(directionse);
                var dist = point.CurrentDistance();
                if (dist > longestDistance)
                    longestDistance = dist;
            }

            Console.WriteLine($"The furthest distance where to child process was {longestDistance}");
        }

        protected override string GetStringDay()
        {
            return "Eleven";
        }

        #endregion
    }
}
