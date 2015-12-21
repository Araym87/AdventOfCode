using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day21
{
    public abstract class Item
    {
        public int Damage { get; set; }

        public int Armor { get; set; }

        public int Cost { get; set; }
    }
}
