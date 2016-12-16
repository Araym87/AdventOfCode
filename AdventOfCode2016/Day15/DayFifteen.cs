using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode2016.General;

namespace AdventOfCode2016.Day15
{
    public class DayFifteen : DayResult
    {
        #region Constants

        private const int HIGHEST = 2100000;

        #endregion

        #region Protected Methods

        protected override void FirstPart()
        {
            var discs = new List<HashSet<int>>();
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input15.txt")))
            {
                var words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                discs.Add(GetNumbers(Convert.ToInt32(words[3]), Convert.ToInt32(words.Last().Substring(0, 1)), discs.Count));
            }
            var intersection = discs.Skip(1).Aggregate(discs.First(),(h, e) => { h.IntersectWith(e); return h; }).OrderBy(i => i).First();
            Console.WriteLine($"{intersection}");
        }

        protected override void SecondPart()
        {
            var discs = new List<HashSet<int>>();
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input15.txt")))
            {
                var words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);                
                discs.Add(GetNumbers(Convert.ToInt32(words[3]), Convert.ToInt32(words.Last().Substring(0, 1)), discs.Count));
            }
            discs.Add(GetNumbers(11, 0, discs.Count));
            var intersection = discs.Skip(1).Aggregate(discs.First(), (h, e) => { h.IntersectWith(e); return h; }).OrderBy(i => i).First();
            Console.WriteLine($"{intersection}");
        }

        #endregion

        #region Private Methods

        private HashSet<int> GetNumbers(int positions, int currentPosition, int discCount)
        {
            var disc = new HashSet<int>();
            var time = positions - currentPosition;
            var count = discCount;
            while (time < HIGHEST)
            {
                var changed = time - (count + 1);
                if (changed >= 0)
                    disc.Add(changed);

                time += positions;
            }

            return disc;
        }

        #endregion

        #region Overriden Methods

        protected override string GetStringDay()
        {
            return "Fifteen";
        }

        #endregion
    }
}
