using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Day23
{
    public class Decrease : Instruction
    {
        private char? registerName;
        private int? number;

        public Decrease(string register)
        {
            TwoInstructions = false;
            if (int.TryParse(register, out var x))
                number = x;
            else
                registerName = register[0];
        }

        public override List<char> Register()
        {
            return registerName.HasValue ? new List<char> { registerName.Value } : new List<char>();
        }

        public override int Process(Dictionary<char, int> register, List<int> clockSignal)
        {
            if (registerName.HasValue)
                register[registerName.Value]--;
            return 1;
        }

        public override Instruction ToggleInstruction()
        {
            return new Increase(registerName?.ToString() ?? number.Value.ToString());
        }
    }
}
