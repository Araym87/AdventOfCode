using System;
using System.Collections.Generic;
using System.IO;
using AdventOfCode.Common.General;

namespace AdventOfCode2016.Day12
{
    public class DayTwelve : DayResult
    {
        #region Protected Methods

        protected override void FirstPart()
        {
            var variables = new Variables();
            var instructions = new List<Instruction>();

            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input12.txt")))
            {
                var instruction = ReadInputLine(line, variables);
                instruction.Variables = variables;
                instructions.Add(instruction);
            }
            var index = 0;
            while (index >= 0 && index < instructions.Count)
            {
                index += instructions[index].Perform();
            }

            Console.WriteLine($"Result on register 'a' is {variables.Variable['a']}");
        }

        protected override void SecondPart()
        {
            var variables = new Variables();
            var instructions = new List<Instruction>();

            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input12.txt")))
            {
                var instruction = ReadInputLine(line, variables);
                instruction.Variables = variables;
                instructions.Add(instruction);
            }
            variables.Variable['c'] = 1;
            var index = 0;
            while (index >= 0 && index < instructions.Count)
            {
                index += instructions[index].Perform();
            }

            Console.WriteLine($"Result on register 'a', when c starts at 1 is {variables.Variable['a']}");
        }

        #endregion

        #region Private Methods

        private Instruction ReadInputLine(string line, Variables variables)
        {
            var words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (words[0] == "cpy")
            {
                int intFrom;
                var copyTo = words[2][0];
                variables.Add(copyTo);
                if (int.TryParse(words[1], out intFrom))
                {
                    return new Copy(intFrom, copyTo);
                }

                var charFrom = words[1][0];
                variables.Add(charFrom);
                return new Copy(charFrom, copyTo);
            }

            if (words[0] == "inc")
            {
                int intFrom;
                if (int.TryParse(words[1], out intFrom))
                {
                    return new Increment(intFrom);
                }
                
                var charFrom = words[1][0];
                variables.Add(charFrom);
                return new Increment(charFrom);
                
            }

            if (words[0] == "dec")
            {
                int intFrom;
                if (int.TryParse(words[1], out intFrom))
                {
                    return new Decrement(intFrom);
                }

                var charFrom = words[1][0];
                variables.Add(charFrom);
                return new Decrement(charFrom);
            }
            else
            {
                int intFrom;
                var step = Convert.ToInt32(words[2]);
                if (int.TryParse(words[1], out intFrom))
                {
                    return new Jump(intFrom, step);
                }

                var charFrom = words[1][0];
                variables.Add(charFrom);
                return new Jump(charFrom, step);
            }
        }

        #endregion

        #region Overriden Methods

        protected override string GetStringDay()
        {
            return "Twelve";
        }

        #endregion
    }
}
