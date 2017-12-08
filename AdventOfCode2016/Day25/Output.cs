using System;
using System.Collections.Generic;
using AdventOfCode2016.Day23;

namespace AdventOfCode2016.Day25
{
    public class Output : Instruction
    {
        private char? registerName;
        private int? number;

        public Output(string register)
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
            clockSignal.Add(registerName.HasValue ? register[registerName.Value] : number.Value);
            return 1;
        }

        public override Instruction ToggleInstruction()
        {
            return new Increase(registerName?.ToString() ?? number.Value.ToString());
        }
    }
}
