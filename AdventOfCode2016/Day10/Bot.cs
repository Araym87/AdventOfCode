using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Day10
{
    public class Bot
    {
        public int ID { get; set; }

        public List<int> Chips { get; set; } = new List<int>();

        public int Low { get; set; }

        public int High { get; set; }

        public bool LowOutput { get; set; }

        public bool HighOutput { get; set; }
    }
}
