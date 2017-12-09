using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day8
{
    public class Day8 : DayResult
    {
        #region Protected Methods

        protected override void FirstPart()
        {
            Console.WriteLine($"The biggest value in the register is {Initialize(out var _).OrderByDescending(i => i.Value).ToList()[0].Value}");
        }

        protected override void SecondPart()
        {
            Initialize(out var maximum);
            Console.WriteLine($"The biggest value which were presented in the register was {maximum}");
        }

        protected override string GetStringDay()
        {
            return "Eight";
        }

        #endregion

        #region Private Methods

        private Dictionary<string, int> Initialize(out int maximum)
        {
            maximum = -1;
            var registers = new Dictionary<string, int>();
            foreach (var line in AdventOfCodeHelper.FileReader("Inputs\\Input8.txt"))
            {
                var parts = line.Split(new[] { "if" }, StringSplitOptions.RemoveEmptyEntries);
                var coef = parts[0].Contains("inc") ? 1 : -1;
                var register = parts[0].Split(new[] { "dec", "inc" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim();
                if (!registers.ContainsKey(register))
                    registers[register] = 0;

                var value = int.Parse(parts[0].Split(new[] { "dec", "inc" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());

                var conditions = parts[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(i => i.Trim()).ToList();

                var registerToCompare = conditions[0];
                var condition = conditions[1];
                var numberToCompare = int.Parse(conditions[2]);
                if (!registers.ContainsKey(registerToCompare))
                    registers[registerToCompare] = 0;

                if (ComputeRegister(registers[registerToCompare], condition, numberToCompare))
                {
                    var newValue = registers[register] + coef * value;
                    registers[register] = newValue;
                    if (newValue > maximum)
                        maximum = newValue;
                }
            }

            return registers;
        }

        private bool ComputeRegister(int leftValue, string condition, int rightValue)
        {
            switch (condition)
            {
                case ">": return leftValue > rightValue;
                case ">=": return leftValue >= rightValue;
                case "==": return leftValue == rightValue;
                case "!=": return leftValue != rightValue;
                case "<": return leftValue < rightValue;
                case "<=": return leftValue <= rightValue;
            }
            throw new Exception($"UnknownOperation {condition}");
        }

        #endregion
    }
}
