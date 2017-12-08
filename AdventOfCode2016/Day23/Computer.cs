using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Day23
{
    public class Computer
    {
        public Dictionary<char, int> Register = new Dictionary<char, int>();

        public List<Instruction> Instructions { get; set; } = new List<Instruction>();

        public int Pointer { get; set; }

        public Computer()
        {
            Pointer = 0;
        }

        public void AddInstruction(Instruction ins)
        {
            foreach (var register in ins.Register())
            {
                if(!Register.ContainsKey(register))
                    Register.Add(register, 0);
            }

            Instructions.Add(ins);
        }

        public void Run()
        {
            while (Pointer >= 0 && Pointer < Instructions.Count)
            {
                var instruction = Instructions[Pointer];
                var difference = instruction.Process(Register);

                var toggleInstruction = instruction as Toggle;
                if (toggleInstruction == null)
                {
                    Pointer += difference;
                    continue;
                }

                var togglePointer = Pointer + difference;
                Pointer++;

                if(togglePointer < 0 || togglePointer >= Instructions.Count)
                    continue;
                
                var newInstruction = Instructions[togglePointer].ToggleInstruction();
                Instructions.RemoveAt(togglePointer);
                Instructions.Insert(togglePointer, newInstruction);
                
            }
        }
    }
}
