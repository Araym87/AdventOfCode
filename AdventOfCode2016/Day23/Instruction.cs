using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Day23
{
    public abstract class Instruction : ISupportToggle
    {
        public bool TwoInstructions { get; set; }

        public abstract List<char> Register();

        public abstract int Process(Dictionary<char, int> register);

        public abstract Instruction ToggleInstruction();
    }
}
