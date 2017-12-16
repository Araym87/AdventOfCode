using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day16
{
    public class Day16 : DayResult
    {
        #region Constants

        protected const int SIZE = 16;
        protected const int NUMBER_OF_ITERATION = 1000000000;

        #endregion

        #region Protected Methods

        protected override void FirstPart()
        {
            var dancers = InitializeDanceFloor();
            var instructions = ReadInstructions();

            foreach (var danceInstruction in instructions)
            {
                danceInstruction.PerformDanceStep(dancers);
            }

            Console.WriteLine($"Dance floor after first round is {new string(dancers)}");
        }

        protected override void SecondPart()
        {
            var dancers = InitializeDanceFloor();            
            var instructions = ReadInstructions();

            var history = new Dictionary<char[], int>(new CharArrayEqualityComparer());
            for (var i = 0; i < NUMBER_OF_ITERATION; i++)
            {
                if (history.ContainsKey(dancers))
                {
                    dancers = history.First(j => j.Value == NUMBER_OF_ITERATION % (i - history[dancers])).Key;
                    break;
                }
                
                history[dancers.ToArray()] = i;
                
                foreach (var danceInstruction in instructions)
                {
                    danceInstruction.PerformDanceStep(dancers);                        
                }
            }

            Console.WriteLine($"Dance floor after one billion rounds is {new string(dancers)}");
        }

        protected override string GetStringDay()
        {
            return "Sixteen";
        }

        #endregion

        #region Private Methods

        private List<IDanceInstruction> ReadInstructions()
        {
            var instructions = new List<IDanceInstruction>();
            foreach (var instruction in AdventOfCodeHelper.FileReader("Inputs\\Input16.txt").First()
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                switch (instruction[0])
                {
                    case 's':
                    {
                        instructions.Add(new Spin(instruction.Substring(1)));
                        break;
                    }
                    case 'x':
                    {
                        var parameters = instruction.Substring(1).Split(new[] { '/' });
                        instructions.Add(new Exchange(parameters[0], parameters[1]));
                        break;
                    }
                    case 'p':
                    {
                        var parameters = instruction.Substring(1).Split(new[] { '/' });
                        instructions.Add(new Partner(parameters[0], parameters[1]));
                        break;
                    }
                }
            }

            return instructions;
        }

        private char[] InitializeDanceFloor()
        {
            var dancers = new char[SIZE];
            var start = 'a';
            for (var i = 0; i < SIZE; i++)
            {
                dancers[i] = (char)(start + i);
            }

            return dancers;
        }

        #endregion
    }
}
 