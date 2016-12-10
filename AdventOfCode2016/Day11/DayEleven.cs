using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2016.General;

namespace AdventOfCode2016.Day11
{
    public class DayEleven : DayResult
    {
        #region Protected Methods

        protected override void FirstPart()
        {
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input11.txt")))
            {
            }
            Console.WriteLine($"");
        }

        protected override void SecondPart()
        {
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input11.txt")))
            {
            }
            Console.WriteLine($"");
        }

        #endregion

        #region Overidden Methods

        protected override string GetStringDay()
        {
            return "Eleven";
        }

        #endregion
    }
}
