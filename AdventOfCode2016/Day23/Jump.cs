using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Day23
{
    public class Jump : Instruction
    {
        private char? canJumpChar;
        private int? canJumpInt;

        private char? jumpChar;
        private int? jumpInt;

        public Jump(string first, string second)
        {
            TwoInstructions = true;
            if (int.TryParse(first, out var x))
                canJumpInt = x;
            else
                canJumpChar = first[0];

            if (int.TryParse(second, out var y))
                jumpInt = y;
            else
                jumpChar = second[0];
        }

        public override List<char> Register()
        {
            var result = new List<char>();
            if (canJumpChar.HasValue)
                result.Add(canJumpChar.Value);

            if (jumpChar.HasValue)
                result.Add(jumpChar.Value);

            return result;
        }

        public override int Process(Dictionary<char, int> register, List<int> clockSignal)
        {
            var leftParameter = canJumpInt ?? register[canJumpChar.Value];
            if (leftParameter == 0)
                return 1;

            return jumpInt ?? register[jumpChar.Value];
        }

        public override Instruction ToggleInstruction()
        {
            return new Copy(canJumpChar?.ToString() ?? canJumpInt.Value.ToString(), jumpChar?.ToString() ?? jumpInt.Value.ToString());
        }
    }
}
