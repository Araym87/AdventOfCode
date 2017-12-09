using System;
using System.Drawing;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day3
{
    public class Day3 : DayResult
    {
        #region Constants

        private const int INPUT = 325489;

        #endregion

        #region Protected Methods

        protected override void FirstPart()
        {
            var iteration = 0;
            var size = 1;

            while (true)
            {
                var lower = size * size + 1;
                size += 2;
                var higher = size * size;

                iteration++;
                if (INPUT >= lower && INPUT <= higher)
                {
                    break;
                }
            }

            var point = new Point(((int)Math.Pow(iteration * 2 + 1, 2) - INPUT) % iteration, iteration);
            var result = Math.Abs(point.X - 0) + Math.Abs(point.Y - 0);
            Console.WriteLine($"Number of steps required to carry the data access port are {result}");
        }

        protected override void SecondPart()
        {
            // Initialize board and center point
            var board = new int[300, 300];
            var centerPoint = new Point(150, 150);
            board[centerPoint.X, centerPoint.Y] = 1;
            // Do the first move and changfe direction to UP
            var currentPoint = new Point(centerPoint.X + 1, centerPoint.Y);
            board[currentPoint.X, currentPoint.Y] = 1;
            var lastDirection = Direction.Up;
            while (true)
            {
                // Get Next point to move
                currentPoint = NextPoint(currentPoint, centerPoint, lastDirection, out lastDirection);
                var newNumber = SumNeighbours(board, currentPoint);

                if (newNumber > INPUT)
                {
                    Console.WriteLine($"First value written in Spiral bigger than input is {newNumber}");
                    break;
                }

                board[currentPoint.X, currentPoint.Y] = newNumber;                
            }  
        }

        protected override string GetStringDay()
        {
            return "Three";
        }

        #endregion

        #region Private Methods

        private int SumNeighbours(int[,] board, Point currentPoint)
        {
            var sum = 0;
            for (var i = -1; i <= 1; i++)
            {
                for (var j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;

                    sum += board[currentPoint.X + i, currentPoint.Y + j];
                }
            }

            return sum;
        }

        private Point NextPoint(Point currentPoint, Point center, Direction lastDirection, out Direction newDirection)
        {
            newDirection = lastDirection;
            // Check if it is corner, then turn left, in bottom left corner, there is an exception for + 1, to expand spiral
            if (((lastDirection == Direction.Right && currentPoint.X > center.X) ? Math.Abs(currentPoint.X - 1 - center.X) : Math.Abs(currentPoint.X - center.X)) == Math.Abs(currentPoint.Y - center.Y))
                newDirection = Turn(lastDirection);

            switch (newDirection)
            {
                case Direction.Up: return new Point(currentPoint.X, currentPoint.Y + 1);
                case Direction.Down: return new Point(currentPoint.X, currentPoint.Y - 1);
                case Direction.Left: return new Point(currentPoint.X - 1, currentPoint.Y);
                case Direction.Right: return new Point(currentPoint.X + 1, currentPoint.Y);
            }
            throw new Exception("Wrong Direction");
        }

        private Direction Turn(Direction last)
        {
            switch (last)
            {
                case Direction.Down: return Direction.Right;
                case Direction.Right: return Direction.Up;
                case Direction.Up: return Direction.Left;
                case Direction.Left: return Direction.Down;
            }

            throw new Exception("Wrong Direction");
        }

        #endregion
    }
}
