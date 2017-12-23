using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day21
{
    public class Day21 : DayResult
    {
        #region Constants 

        private static readonly bool[,] PatternToStart = { { false, true, false }, { false, false, true }, { true, true, true } };

        #endregion

        #region Protected Methods

        protected override void FirstPart()
        {
            Console.WriteLine($"Number of turned on pixels after 5 iteration is {EnhancingPatterns(LoadPatterns(), PatternToStart, 5).Cast<bool>().Count(b => b)}");
        }

        protected override void SecondPart()
        {
            Console.WriteLine($"Number of turned on pixels after 18 iteration is {EnhancingPatterns(LoadPatterns(), PatternToStart, 18).Cast<bool>().Count(b => b)}");
        }

        protected override string GetStringDay()
        {
            return "Twenty one";
        }

        #endregion

        #region Private Methods

        private static Dictionary<bool[,], Pattern> LoadPatterns()
        {
            var patterns = new Dictionary<bool[,], Pattern>(new BoolArrayEqualityComparer());

            foreach (var line in AdventOfCodeHelper.FileReader("Inputs\\Input21.txt"))
            {
                var items = line.Split(new[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);
                var pattern = new Pattern(items[0], items[1]);
                patterns.Add(pattern.Input, pattern);
            }

            return patterns;
        }

        private static bool[,] EnhancingPatterns(Dictionary<bool[,], Pattern> patterns, bool[,] patternToEnhance, int numberOfIteration)
        {
            for (var iteration = 0; iteration < numberOfIteration; iteration++)
            {
                var size = (int)Math.Sqrt(patternToEnhance.Length);
                var sizeOfSmallSquare = size % 2 == 0 ? 2 : 3;
                var numberOfSquaresInRow = size / sizeOfSmallSquare;
                var newSize = numberOfSquaresInRow * (sizeOfSmallSquare + 1);
                var newPatternToEnhance = new bool[newSize, newSize];

                for (var yIncrement = 0; yIncrement < numberOfSquaresInRow; yIncrement++)
                {
                    for (var xIncrement = 0; xIncrement < numberOfSquaresInRow; xIncrement++)
                    {
                        var smallSquare = new bool[sizeOfSmallSquare, sizeOfSmallSquare];
                        for (var y = 0; y < sizeOfSmallSquare; y++)
                        {
                            for (var x = 0; x < sizeOfSmallSquare; x++)
                            {
                                smallSquare[y, x] = patternToEnhance[yIncrement * sizeOfSmallSquare + y,
                                    xIncrement * sizeOfSmallSquare + x];
                            }
                        }

                        var foundedPattern = patterns[smallSquare];

                        for (var y = 0; y < sizeOfSmallSquare + 1; y++)
                        {
                            for (var x = 0; x < sizeOfSmallSquare + 1; x++)
                            {
                                newPatternToEnhance[yIncrement * (sizeOfSmallSquare + 1) + y, xIncrement * (sizeOfSmallSquare + 1) + x] =
                                    foundedPattern.Output[y, x];
                            }
                        }

                    }
                }
                patternToEnhance = newPatternToEnhance;
            }

            return patternToEnhance;
        }

        #endregion
    }
}
