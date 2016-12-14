using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2016.Day11;
using AdventOfCode2016.General;

namespace AdventOfCode2016.Day13
{
    public class DayThirteen : DayResult
    {
        #region Constants

        private const int SPECIAL_NUMBER = 1358;
        private const int MAX_DEEP = 50;

        #endregion

        #region Fields

        private readonly int[] possibleMovements = new[] {1, -1};
        private readonly Point startPosition = new Point(1,1);
        private readonly Position finalPosition = new Position(new Point(31, 39));

        #endregion

        protected override void FirstPart()
        {
            var cache = new HashSet<Position>();

            var queue = new Queue<Position>();
            var currentPosition = new Position(startPosition);
            queue.Enqueue(currentPosition);
            cache.Add(queue.Peek());

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                for (var i = 0; i < possibleMovements.Length; i++)
                {
                    for (var j = 0; j < 2; j++)
                    {
                        var newMove = current.GetMove(i == 0 ? new Point(possibleMovements[j], 0) : new Point(0, possibleMovements[j]));

                        if (newMove == null || IsWall(newMove.GetPosition()))
                            continue;

                        if (cache.Add(newMove))
                        {
                            if (newMove == finalPosition)
                            {
                                Console.WriteLine($"Minimum steps to reach a target is {newMove.Step}");
                            }

                            queue.Enqueue(newMove);
                        }
                    }
                }      
            }            
        }

        protected override void SecondPart()
        {
            var cache = new HashSet<Position>();

            var queue = new Queue<Position>();
            var currentPosition = new Position(startPosition);
            queue.Enqueue(currentPosition);
            cache.Add(queue.Peek());

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.Step == MAX_DEEP)
                    break;
                for (var i = 0; i < possibleMovements.Length; i++)
                {
                    for (var j = 0; j < 2; j++)
                    {
                        var newMove = current.GetMove(i == 0 ? new Point(possibleMovements[j], 0) : new Point(0, possibleMovements[j]));

                        if (newMove == null || IsWall(newMove.GetPosition()))
                            continue;

                        if (cache.Add(newMove))
                        {
                            queue.Enqueue(newMove);
                        }
                    }
                }
            }

            Console.WriteLine($"Number of visitied fields in max 50 depth is {cache.Count}");
        }

        #region Private Methods

        private bool IsWall(Point point)
        {
            var number = (point.X*point.X) + (3*point.X) + (2*point.X*point.Y) + point.Y + (point.Y*point.Y) + SPECIAL_NUMBER;
            int count = 0;
            while (number != 0)
            {
                count++;
                number &= (number - 1);
            }
            return count % 2 == 1;
        }

        #endregion

        #region Overriden Methods

        protected override string GetStringDay()
        {
            return "Thirteen";
        }

        #endregion
    }
}
