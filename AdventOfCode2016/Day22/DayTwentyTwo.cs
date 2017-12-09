using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Common.General;

namespace AdventOfCode2016.Day22
{
    public class DayTwentyTwo : DayResult
    {
        protected override void FirstPart()
        {
            var nodes = new List<Node>();
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input22.txt")))
            {
                if(!line.StartsWith("/"))
                    continue;

                var node = new Node();
                var words = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var position = words[0].Split(new[] {'-'}, StringSplitOptions.RemoveEmptyEntries);
                var x = Convert.ToInt32(position[1].Substring(1));
                var y = Convert.ToInt32(position[2].Substring(1));
                node.Position = new Point(x, y);
                node.Used = Convert.ToInt32(words[2].Trim().Substring(0, words[2].Trim().Length - 1));
                node.Avail = Convert.ToInt32(words[3].Trim().Substring(0, words[3].Trim().Length - 1));
                nodes.Add(node);
            }
            var count = 0;
            for (var i = 0; i < nodes.Count; i++)
            {
                for (var j = 0; j < nodes.Count; j++)
                {
                   if(i == j)
                        continue;

                    if (nodes[i].CanTransferData(nodes[j]))
                        count++;
                }
            }

            Console.WriteLine($"Viable pairs : {count}");
        }

        protected override string GetStringDay()
        {
            return "Twenty two";
        }
    }
}
