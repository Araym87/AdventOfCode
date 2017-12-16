using System;
using System.Collections.Generic;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day13
{
    public class Day13 : DayResult
    {
        #region Protected Methods

        protected override void FirstPart()
        {
            var firewall = new List<Layer>();
            foreach (var line in AdventOfCodeHelper.FileReader("Inputs\\Input13.txt"))
            {
                var layer = new Layer
                {
                    Size = Convert.ToInt32(line.Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries)[1].Trim())
                };
                var index = Convert.ToInt32(line.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[0].Trim());

                while (firewall.Count != index)
                    firewall.Add(new Layer{Size = -1});

                firewall.Add(layer);
            }

            var currentLocation = -1;
            var result = 0;
            while (currentLocation != firewall.Count - 1)
            {
                currentLocation++;
                if (firewall[currentLocation].Caught())
                    result += currentLocation * firewall[currentLocation].Size;

                firewall.ForEach(i => i.Move());
            }

            Console.WriteLine($"Severity of packet travel is {result}");
        }

        protected override void SecondPart()
        {
            var firewall = new List<Layer>();
            foreach (var line in AdventOfCodeHelper.FileReader("Inputs\\Input13.txt"))
            {
                var layer = new Layer();
                layer.Size = Convert.ToInt32(line.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());
                var index = Convert.ToInt32(line.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[0].Trim());

                while (firewall.Count != index)
                    firewall.Add(new Layer { Size = -1 });

                firewall.Add(layer);
            }

            var waitedPicoseconds = 0;
            while(true)
            { 
                var found = true;
                for (var j = 0; j < firewall.Count; j++)
                {
                    if (firewall[j].Size == -1)
                        continue;

                    var current = waitedPicoseconds + j;
                    if(current < 0)
                        continue;

                    if (current % ((firewall[j].Size - 1) * 2) == 0)
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    Console.WriteLine($"Packet needs to be delayed be {waitedPicoseconds} picoseconds.");
                    break;
                }
                waitedPicoseconds++;
            }

        }

        protected override string GetStringDay()
        {
            return "Thirteen";
        }

        #endregion
    }
}
