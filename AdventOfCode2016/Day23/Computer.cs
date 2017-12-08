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
            var clockSignal = new List<int>();
            while (Pointer >= 0 && Pointer < Instructions.Count)
            {
                var instruction = Instructions[Pointer];
                var difference = instruction.Process(Register, clockSignal);

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

        private void ClearRegisters()
        {
            foreach (var registerKey in Register.Keys.ToList())
            {
                Register[registerKey] = 0;
            }
        }

        public bool RunWithClockSignal(int inputForRegisterA)
        {
            ClearRegisters();
            Pointer = 0;
            var clockSignal = new List<int>();
            Register['a'] = inputForRegisterA;
            while (Pointer >= 0 && Pointer < Instructions.Count)
            {
                var instruction = Instructions[Pointer];
                var difference = instruction.Process(Register, clockSignal);

                if (!CheckClockSignal(clockSignal))
                    return false;

                if (clockSignal.Count > 20)
                    break;

                var toggleInstruction = instruction as Toggle;
                if (toggleInstruction == null)
                {
                    Pointer += difference;
                    continue;
                }

                var togglePointer = Pointer + difference;
                Pointer++;

                if (togglePointer < 0 || togglePointer >= Instructions.Count)
                    continue;

                var newInstruction = Instructions[togglePointer].ToggleInstruction();
                Instructions.RemoveAt(togglePointer);
                Instructions.Insert(togglePointer, newInstruction);

            }

            return true;
        }

        private static bool CheckClockSignal(List<int> clockSignal)
        {
            for (var i = 0; i < clockSignal.Count; i++)
            {
                if (i % 2 == 0 && clockSignal[i] != 0 || i % 2 == 1 && clockSignal[i] != 1)
                    return false;
            }

            return true;
        }
    }
}
