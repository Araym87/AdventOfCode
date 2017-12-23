using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AdventOfCode.Common.General;
using AdventOfCode2017.Day18;

namespace AdventOfCode2017.Day23
{
    public class Day23 : DayResult
    {
        #region Protected Methods

        protected override void FirstPart()
        {
            var computer = new Computer();

            foreach (var line in AdventOfCodeHelper.FileReader("Inputs\\Input23.txt"))
            {
                computer.AddInstruction(ReadInputLineFirstPart(line));
            }

            computer.RunSimple();
            Console.WriteLine($"Program called exactly {computer.ComputerArgs.NumberOfMultiplyInstructionCall} Multiply instructions");
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        protected override void SecondPart()
        {
            var nonPrime = 0;
            // Constants from input instructions
            const int START = 109300;
            const int END = 126300;
            const int STEP = 17;
            for (var i = START; i <= END; i+= STEP)
            {
                if (!IsPrimeNumber(i))
                    nonPrime++;
            }

            Console.WriteLine($"Value of h register is {nonPrime}");
        }

        protected override string GetStringDay()
        {
            return "Twenty Three";
        }

        #endregion

        #region Private Methods

        private static Instruction ReadInputLineFirstPart(string line)
        {
            var words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => i.Trim()).ToList();

            switch (words[0])
            {
                case "set": return new Set(words[1], words[2]);
                case "sub": return new Decrease(words[1], words[2]);
                case "mul": return new Multiply(words[1], words[2]);
                case "jnz": return new JumpNotZero(words[1], words[2]);
                default: throw new Exception($"Unknown instruction {words[0]}");
            }
        }

        public static bool IsPrimeNumber(int nr)
        {
            if (nr <= 1) return false;
            if (nr == 2) return true;
            if (nr % 2 == 0) return false;
            for (var i = 3; i <= Math.Sqrt(nr); i += 2)
            {
                if (nr % i == 0) return false;
            }
            return true;
        }

        #endregion
    }
}
