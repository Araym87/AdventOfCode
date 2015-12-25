using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day23
{
    public class Instruction
    {
        public Func<int, bool> Condition { get; set; } 

        public string Name { get; set; }

        public string Id { get; set; }

        public Func<int, int> Action { get; set; }
        
        public int Offset { get; set; } 
    }
}
