using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day19
{
    public class Day19 : DayResult
    {
        #region Constants

        private const char VERTICAL = '|';
        private const char CROSSROAD = '+';
        private const char EMPTY = ' ';

        #endregion

        #region Overriden Methods

        protected override void FirstPart()
        {
            var maze = InitializeMaze(out var currentPoint);
            var direction = new Point(0, 1);
            var result = new List<char>();
            while (true)
            {
                var item = maze[currentPoint.Y, currentPoint.X];
                if (item == ' ')
                {
                    break;
                }
                if (item >= 'A' && item <= 'Z')
                {
                    result.Add(item);
                }
                else if (item == CROSSROAD)
                {
                    direction = GetAnotherDirection(currentPoint, direction, maze);
                }

                currentPoint = new Point(currentPoint.X + direction.X, currentPoint.Y + direction.Y);
            }
            Console.WriteLine($"Packet visited letters in this order {new string(result.ToArray())}");
        }

        protected override void SecondPart()
        {
            var maze = InitializeMaze(out var currentPoint);
            var direction = new Point(0, 1);
            var numberOfSteps = 0;
            while (true)
            {
                var item = maze[currentPoint.Y, currentPoint.X];
                if (item == ' ')
                {
                    break;
                }
                if (item == CROSSROAD)
                {
                    direction = GetAnotherDirection(currentPoint, direction, maze);
                }
                numberOfSteps++;
                currentPoint = new Point(currentPoint.X + direction.X, currentPoint.Y + direction.Y);
            }
            Console.WriteLine($"Packet needs {numberOfSteps} steps");
        }

        protected override string GetStringDay()
        {
            return "Nineteen";
        }

        #endregion

        #region Private Methods

        private char[,] InitializeMaze(out Point startPoint)
        {
            var input = AdventOfCodeHelper.FileReader("Inputs\\Input19.txt").ToList();
            var maze = new char[input.Count, input[0].Length];
            startPoint = new Point(0,0);
            for (var i = 0; i < input.Count; i++)
            {
                for (var j = 0; j < input[0].Length; j++)
                {
                    maze[i, j] = input[i][j];
                }
            }

            for (var i = 0; i < input[0].Length; i++)
            {
                if (maze[0, i] == VERTICAL)
                {
                    startPoint = new Point(i, 0);
                    break;
                }
            }

            return maze;
        }

        private Point GetAnotherDirection(Point currentPoint, Point direction, char[,] maze)
        {
            if (direction.X == 0)
            {
                if (maze[currentPoint.Y, currentPoint.X - 1] != EMPTY)
                {
                    return new Point(-1, 0);
                }
                if (maze[currentPoint.Y, currentPoint.X + 1] != EMPTY)
                {
                    return new Point(1, 0);
                }
            }
            else if (direction.Y == 0)
            {
                if (maze[currentPoint.Y - 1, currentPoint.X] != EMPTY)
                {
                    return new Point(0, -1);
                }
                if (maze[currentPoint.Y + 1, currentPoint.X] != EMPTY)
                {
                    return new Point(0, 1);
                }
            }

            throw new Exception("How could I get here?");
        }

        #endregion
    }
}
