using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Common.General;

namespace AdventOfCode2016.Day17
{
    public class DaySeventeen : DayResult
    {
        protected override void FirstPart()
        {
            var currentStep = new Step {CurrentString = "vwbaicqe", Position = new Point(0, 0)};
            Step found = null;
            var queue = new Queue<Step>();
            queue.Enqueue(currentStep);
            while (queue.Count > 0 && found == null)
            {
                var current = queue.Dequeue();
                foreach (var nextMove in current.GetAllMoves())
                {
                    if (nextMove.Position.X == 3 && nextMove.Position.Y == 3 && found == null)
                        found = nextMove;
                    queue.Enqueue(nextMove);
                }
            }

            Console.WriteLine($"Direction is {found.CurrentString}");
        }

        protected override void SecondPart()
        {
            var startString = "vwbaicqe";
            var currentStep = new Step { CurrentString = startString, Position = new Point(0, 0) };
            var longest = 0;
            var queue = new Queue<Step>();
            queue.Enqueue(currentStep);
            Recursion(currentStep, ref longest);

            Console.WriteLine($"Longest is {longest - startString.Length}");
        }

        private void Recursion(Step step, ref int longest)
        {
            foreach (var nextMove in step.GetAllMoves())
            {
                if (nextMove.Position.X == 3 && nextMove.Position.Y == 3)
                {
                    longest = nextMove.CurrentString.Length > longest ? nextMove.CurrentString.Length : longest;
                    break;
                }
                Recursion(nextMove, ref longest);
            }
        }

        protected override string GetStringDay()
        {
            return "Seventeen";
        }
    }
}
