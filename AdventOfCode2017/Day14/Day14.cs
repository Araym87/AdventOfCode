using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day14
{
    public class Day14 : DayResult
    {
        #region Constants

        private const string INPUT = "amgozmfv";
        private const char USED = '#';
        private const char FREE = '.';
        private const int SIZE = 128;

        #endregion

        #region Protected Methods

        protected override void FirstPart()
        {
            var result = 0;
            for (var i = 0; i < SIZE; i++)
            {
                var rowResult = KnotHashAlgorithm.BitDenseHash(INPUT, $"-{i}");
                result += rowResult.Count(j => j == '1');
            }

            Console.WriteLine($"There is {result} squares used.");
        }

        protected override void SecondPart()
        {
            var array = new char[SIZE, SIZE];
            for (var i = 0; i < SIZE; i++)
            {
                var rowResult = KnotHashAlgorithm.BitDenseHash(INPUT, $"-{i}");
                for (var j = 0; j < rowResult.Length; j++)
                {
                    var character = rowResult[j] == '1' ? USED : FREE;
                    array[i, j] = character;
                }
            }

            var groups = NumberOfGroups(array);
            Console.WriteLine($"There is {groups} groups.");
        }

        protected override string GetStringDay()
        {
            return "Fourteen";
        }

        #endregion

        #region Private Methods

        private int NumberOfGroups(char[,] disk)
        {
            var groups = 0;
            for (var y = 0; y < SIZE; y++)
            {
                for (var x = 0; x < SIZE; x++)
                {
                    if (disk[y, x] != USED)
                        continue;

                    var queue = new Queue<Point>();
                    queue.Enqueue(new Point(x, y));
                    while (queue.Count > 0)
                    {
                        var current = queue.Dequeue();
                        var nextPossibilities = GetPointsAround(disk, current);
                        nextPossibilities.ForEach(i => disk[i.Y, i.X] = FREE);
                        nextPossibilities.ForEach(queue.Enqueue);
                    }
                    groups++;
                }
            }

            return groups;
        }

        private List<Point> GetPointsAround(char[,] disk, Point location)
        {
            var result = new List<Point>();
            ShouldBeAdded(new Point(location.X, location.Y - 1));
            ShouldBeAdded(new Point(location.X, location.Y + 1));
            ShouldBeAdded(new Point(location.X - 1, location.Y));
            ShouldBeAdded(new Point(location.X + 1, location.Y));

            void ShouldBeAdded(Point x)
            {
                if (x.X >= 0 && x.X < SIZE && x.Y >= 0 && x.Y < SIZE && disk[x.Y, x.X] == USED)
                    result.Add(x);
            }

            return result;
        }

        #endregion
    }
}
