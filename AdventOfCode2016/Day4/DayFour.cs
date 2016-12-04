using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode2016.General;

namespace AdventOfCode2016.Day4
{
    public class DayFour : DayResult
    {
        #region Protected Methods

        protected override void FirstPart(StringBuilder results)
        {
            var sumOfSectorIds = 0;
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input4.txt")))
            {
                var parts = SplittedInput(line);
                var room = new Room(parts[0], parts[1], Convert.ToInt32(parts[2]));
                if (room.IsRealRoom())
                    sumOfSectorIds += room.SectorId;
            }

            results.AppendLine($"Sum of all real room is {sumOfSectorIds}");
        }

        protected override void SecondPart(StringBuilder results)
        {
            var realRooms = new List<Room>();
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input4.txt")))
            {
                var parts = SplittedInput(line);
                var room = new Room(parts[0], parts[1], Convert.ToInt32(parts[2]));
                if (room.IsRealRoom())
                {
                    room.DecryptName();
                    realRooms.Add(room);
                }

            }

            results.AppendLine($"SectorID of room, where North Pole objects are stored is {realRooms.First(i => i.DecryptedName.Contains("northpole")).SectorId}");
        }

        #endregion

        #region Private Methods

        private string[] SplittedInput(string line)
        {
            var parts = line.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            var name = parts.Take(parts.Length - 1).Aggregate((i, j) => i + '-' + j);
            var sectorCheckSum = parts[parts.Length - 1].Split(new[] { '[', ']' },
                StringSplitOptions.RemoveEmptyEntries);
            return new[] {name, sectorCheckSum[1], sectorCheckSum[0] };
        }

        #endregion

        #region Overriden Methods

        protected override string GetStringDay()
        {
            return "Four";
        }

        #endregion
    }
}
