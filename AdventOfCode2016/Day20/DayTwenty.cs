using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Common.General;

namespace AdventOfCode2016.Day20
{
    public class DayTwenty : DayResult
    {
        private List<Tuple<uint, uint>> items = new List<Tuple<uint, uint>>();

        protected override void FirstPart()
        {
            var blackList = new BlackList();
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input20.txt")))
            {
                var words = line.Split(new[] {'-'}, StringSplitOptions.None);
                var lower = Convert.ToUInt32(words[0].Trim());
                var higher = Convert.ToUInt32(words[1].Trim());
                blackList.Add(lower, higher);
            }

            Console.WriteLine($"Lowest IP is {blackList.GetMinimum()}");
        }

        protected override void SecondPart()
        {
            var blackList = new BlackList();
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input20.txt")))
            {
                var words = line.Split(new[] { '-' }, StringSplitOptions.None);
                var lower = Convert.ToUInt32(words[0].Trim());
                var higher = Convert.ToUInt32(words[1].Trim());
                blackList.Add(lower, higher);
            }

            Console.WriteLine($"Total allowed IPs are {blackList.TotalAllowedIps()}");
        }

        protected override string GetStringDay()
        {
            return "Twenty";
        }
    }
}
