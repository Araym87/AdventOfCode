using System.Collections.Generic;

namespace AdventOfCode2016.Day10
{
    public class Bot
    {
        #region Properties

        public int ID { get; set; }

        public List<int> Chips { get; set; } = new List<int>();

        public int Low { get; set; }

        public int High { get; set; }

        public bool LowOutput { get; set; }

        public bool HighOutput { get; set; }

        #endregion
    }
}
