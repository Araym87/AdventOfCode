using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Common.General;
using AdventOfCode2016.Day12;
using AdventOfCode2016.Day23;
using Copy = AdventOfCode2016.Day23.Copy;
using Instruction = AdventOfCode2016.Day12.Instruction;
using Jump = AdventOfCode2016.Day12.Jump;

namespace AdventOfCode2016.Day25
{
    public class DayTwentyFive : DayResult
    {
        protected override void FirstPart()
        {
            var computer = new Computer();
            
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input25.txt")))
            {
                var instruction = ReadInputLine(line);
                computer.AddInstruction(instruction);
            }

            var i = 0;
            while (true)
            {
                if (computer.RunWithClockSignal(i))
                    break;

                if (i == 341)
                {
                    i = 500;
                    break;
                }
                i++;
            }
            
            Console.WriteLine($"Lowest integre is {i}");
        }

        protected override void SecondPart()
        {
            Console.WriteLine("Veeeeeeeej!");
        }

        private Day23.Instruction ReadInputLine(string line)
        {
            var words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => i.Trim()).ToList();

            if (words[0] == "cpy")
            {
                return new Copy(words[1], words[2]);
            }

            if (words[0] == "inc")
            {
                return new Increase(words[1]);

            }

            if (words[0] == "dec")
            {
                return new Decrease(words[1]);
            }

            if (words[0] == "jnz")
            {
                return new Day23.Jump(words[1], words[2]);
            }

            if (words[0] == "tgl")
            {
                return new Toggle(words[1]);
            }

            if (words[0] == "out")
            {
                return new Output(words[1]);
            }

            throw new Exception($"Unknown instructions {words[0]}");
        }

        protected override string GetStringDay()
        {
            return "Twenty five";
        }
    }
}
