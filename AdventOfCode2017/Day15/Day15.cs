using System;
using System.Linq;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day15
{
    public class Day15 : DayResult
    {
        #region Protected Methods

        protected override void FirstPart()
        {
            var generatorA = new Generator(Convert.ToInt32(AdventOfCodeHelper.FileReader("Inputs\\Input15.txt").First().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Last()), 16807);
            var generatorB = new Generator(Convert.ToInt32(AdventOfCodeHelper.FileReader("Inputs\\Input15.txt").Skip(1).First().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Last()), 48271);

            var count = 0;
            for (var i = 0; i < 40000000; i++)
            {
                if (generatorA.BinaryRepresentationLast16() == generatorB.BinaryRepresentationLast16())
                    count++;

                generatorA.ProduceNextValue();
                generatorB.ProduceNextValue();
            }
            Console.WriteLine($"Final count of numbers with same last 16bits is {count + 1}");
        }

        protected override void SecondPart()
        {
            var generatorA = new Generator(Convert.ToInt32(AdventOfCodeHelper.FileReader("Inputs\\Input15.txt").First().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Last()), 16807, 4);
            var generatorB = new Generator(Convert.ToInt32(AdventOfCodeHelper.FileReader("Inputs\\Input15.txt").Skip(1).First().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Last()), 48271, 8);
            var count = 0;
            for (var i = 0; i < 5000000; i++)
            {
                if (generatorA.BinaryRepresentationLast16() == generatorB.BinaryRepresentationLast16())
                    count++;

                generatorA.ProduceNextValueWithCondition();
                generatorB.ProduceNextValueWithCondition();
            }
            Console.WriteLine($"Final count of numbers with same last 16bits is {count}");
        }

        protected override string GetStringDay()
        {
            return "Fifteen";
        }

        #endregion        
    }
}
