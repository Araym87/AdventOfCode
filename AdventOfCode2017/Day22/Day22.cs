using System;
using System.Collections.Generic;
using System.Drawing;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day22
{
    public class Day22 : DayResult
    {
        #region Protected Methods

        protected override void FirstPart()
        {

            var infected = LoadInputStatus(out var sporifica);
            
            var iteration = 0;
            var numberOfInfections = 0;
            while (iteration < 10000)
            {
                var isInfected = infected.ContainsKey(sporifica.CurrentPosition);
                if (isInfected)
                    infected.Remove(sporifica.CurrentPosition);         
                else
                {
                    infected.Add(sporifica.CurrentPosition, NodeStatus.Infected);
                    numberOfInfections++;
                }

                sporifica.Turn(isInfected ? NodeStatus.Infected : NodeStatus.Clean);
                sporifica.Move();

                iteration++;
            }

            Console.WriteLine($"{numberOfInfections}");
        }

        protected override void SecondPart()
        {
            var infected = LoadInputStatus(out var sporifica);

            var iteration = 0;
            var numberOfInfections = 0;
            while (iteration < 10000000)
            {
                var isClean = !infected.ContainsKey(sporifica.CurrentPosition);
                var currentStatus = isClean ? NodeStatus.Clean : infected[sporifica.CurrentPosition];
                if (isClean)
                {
                    infected.Add(sporifica.CurrentPosition, NodeStatus.Weakened);
                }
                else
                {
                    switch (currentStatus)
                    {
                        case NodeStatus.Weakened: infected[sporifica.CurrentPosition] = NodeStatus.Infected;
                            numberOfInfections++;
                            break;
                        case NodeStatus.Infected:
                            infected[sporifica.CurrentPosition] = NodeStatus.Flag;
                            break;
                        case NodeStatus.Flag:
                            infected.Remove(sporifica.CurrentPosition);
                            break;
                    }
                }
                sporifica.Turn(currentStatus);
                sporifica.Move();

                iteration++;
            }

            Console.WriteLine($"{numberOfInfections}");
        }

        protected override string GetStringDay()
        {
            return "Twenty two";
        }

        #endregion

        #region Private Methods

        private static Dictionary<Point, NodeStatus> LoadInputStatus(out Sporifica sporificaVirus)
        {
            var infected = new Dictionary<Point, NodeStatus>();
            var index = 0;
            var wide = 0;
            foreach (var line in AdventOfCodeHelper.FileReader("Inputs\\Input22.txt"))
            {
                if (wide == 0)
                    wide = line.Length;

                for (var i = 0; i < line.Length; i++)
                {
                    if (line[i] == '#')
                        infected.Add(new Point(i, index), NodeStatus.Infected);
                }
                index++;
            }

            var xCenter = (int)Math.Floor((double)wide / 2);
            var yCenter = (int)Math.Floor((double)index / 2);
            sporificaVirus = new Sporifica { CurrentPosition = new Point(xCenter, yCenter), Direction = Direction.Top };

            return infected;
        }

        #endregion
    }
}
