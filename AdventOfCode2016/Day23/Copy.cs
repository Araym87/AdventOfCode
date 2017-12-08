using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Day23
{
    public class Copy : Instruction
    {
        private char? fromChar;
        private int? fromInt;

        private char? toChar;
        private int? toInt;
        
        public Copy(string from, string to)
        {
            TwoInstructions = true;
            if (int.TryParse(to, out var x))
                toInt = x;
            else
                toChar = to[0];
            if (int.TryParse(from, out var y))
                fromInt = y;
            else
                fromChar = from[0];           
        }

        public override List<char> Register()
        {
            var result = new List<char>();
            if(fromChar.HasValue)
                result.Add(fromChar.Value);

            if(toChar.HasValue)
                result.Add(toChar.Value);

            return result;
        }

        public override int Process(Dictionary<char, int> register)
        {
            if (!toChar.HasValue)
                return 1;

            var leftValue = fromChar.HasValue ? register[fromChar.Value] : fromInt.Value;
            register[toChar.Value] = leftValue;
            return 1;
        }

        public override Instruction ToggleInstruction()
        {
            return new Jump(fromChar.HasValue ? fromChar.ToString() : fromInt.ToString(), toChar.HasValue ? toChar.ToString() : toInt.ToString());
        }
    }
}
