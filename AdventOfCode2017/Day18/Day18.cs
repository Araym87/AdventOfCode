using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day18
{
    public class Day18 : DayResult
    {
        #region Protected Methods

        protected override void FirstPart()
        {
            var computer = new Computer();
            foreach (var line in AdventOfCodeHelper.FileReader("Inputs\\Input18.txt"))
            {
                var instruction = ReadInputLineFirstPart(line);
                computer.AddInstruction(instruction);
            }

            Console.WriteLine($"Last frequency sent by Recovery instruction is {computer.Run()}");
        }

        protected override void SecondPart()
        {
            var computer0 = new Computer();
            computer0.ComputerArgs.Register['p'] = 0;

            var computer1 = new Computer();
            computer1.ComputerArgs.Register['p'] = 1;
            foreach (var line in AdventOfCodeHelper.FileReader("Inputs\\Input18.txt"))
            {
                computer0.AddInstruction(ReadInputLineSecondPart(line));
                computer1.AddInstruction(ReadInputLineSecondPart(line));
            }
            computer0.Initialize(computer1.InsertToQueue);
            computer1.Initialize(computer0.InsertToQueue);
            var tokenSource = new CancellationTokenSource();

            Task.Factory.StartNew(() => computer0.RunSecond(tokenSource), tokenSource.Token);
            Task.Factory.StartNew(() => computer1.RunSecond(tokenSource), tokenSource.Token);
            // Wait for a deadlock
            while (!(computer0.WaitingForInstruction && computer1.WaitingForInstruction))
            {
                Thread.Sleep(50);
            }
            tokenSource.Cancel();
            Console.WriteLine($"Program 1 has sent {computer1.SentInstructions} instructions.");
        }

        protected override string GetStringDay()
        {
            return "Eighteen";
        }

        #endregion

        #region Private Methods

        private Instruction ReadInputLineFirstPart(string line)
        {
            var words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => i.Trim()).ToList();

            switch (words[0])
            {
                case "snd": return new Sound(words[1]);
                case "set": return new Set(words[1], words[2]);
                case "add": return new Add(words[1], words[2]);
                case "mul": return new Multiply(words[1], words[2]);
                case "mod": return new Modulo(words[1], words[2]);
                case "rcv": return new Recovery(words[1]);
                case "jgz": return new Jump(words[1], words[2]);
                default: throw new Exception($"Unknown instruction {words[0]}");
            }
        }

        private Instruction ReadInputLineSecondPart(string line)
        {
            var words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => i.Trim()).ToList();

            switch (words[0])
            {
                case "snd": return new Send(words[1]);
                case "set": return new Set(words[1], words[2]);
                case "add": return new Add(words[1], words[2]);
                case "mul": return new Multiply(words[1], words[2]);
                case "mod": return new Modulo(words[1], words[2]);
                case "rcv": return new Receive(words[1]);
                case "jgz": return new Jump(words[1], words[2]);
                default: throw new Exception($"Unknown instruction {words[0]}");
            }
        }

        #endregion
    }
}
