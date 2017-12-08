using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2016.Day12;

namespace AdventOfCode2016.Day23
{
    public class Toggle : Instruction
    {
        private char letter;

        public Toggle()
        {
            Step = 1;
        }

        public Toggle(char c) : this()
        {
            letter = c;
        }

        public override int Perform()
        {
            var value = Variables.Variable[letter];
            var indexOfStep = Variables.Instructions.FindIndex(i => i.Equals(this));
            var newValue = indexOfStep + value;
            if (newValue >= Variables.Instructions.Count)
                return Step;

            var stepToChange = Variables.Instructions[newValue];
            //if()

            return Step;
        }
    }
}
