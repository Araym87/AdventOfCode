using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2016.Day12;
using AdventOfCode2016.General;

namespace AdventOfCode2016.Day23
{
    public class DayTwentyThree : DayResult
    {
        protected override void FirstPart()
        {
            var computer = new Computer();
            computer.Register.Add('a', 7);
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input23.txt")))
            {
                var instruction = ReadInputLine(line);
                computer.AddInstruction(instruction);
            }
            computer.Run();
            Console.WriteLine($"Result on register 'a' is {computer.Register['a']}");
        }

        protected override void SecondPart()
        {
            var computer = new Computer();
            computer.Register.Add('a', 12);
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input23.txt")))
            {
                var instruction = ReadInputLine(line);
                computer.AddInstruction(instruction);
            }
            computer.Run();
            Console.WriteLine($"Result on register 'a' is {computer.Register['a']}");
        }

        private Instruction ReadInputLine(string line)
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
            
            if(words[0] == "jnz")
            {
                return new Jump(words[1], words[2]);
            }

            if (words[0] == "tgl")
            {
                return new Toggle(words[1]);
            }

            throw new Exception($"Unknown instructions {words[0]}");
        }


        protected override string GetStringDay()
        {
            return "Twenty three";
        }
    }
}
