using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day10
{
    public class Day10 : DayResult
    {
        private const int SIZE = 256;
        #region Protected Methods

        protected override void FirstPart()
        {
            var input = AdventOfCodeHelper.FileReader("Inputs\\Input10.txt").First()
                .Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i.Trim())).ToList();

            var sparseHash = new int[SIZE];
            for (var i = 0; i < SIZE; i++)
                sparseHash[i] = i;

            var skipSize = 0;
            var currentPoistion = 0;
            DoKnotHashAlgorithm(input, sparseHash, ref currentPoistion, ref skipSize);
            
            Console.WriteLine($"Result is {sparseHash[0] * sparseHash[1]}");
        }

        protected override void SecondPart()
        {
            var input = AdventOfCodeHelper.FileReader("Inputs\\Input10.txt").First().Select(i => (int)i).ToList();
            input.AddRange(new List<int>{17, 31, 73, 47, 23});
            var sparseHash = new int[SIZE];
            for (var i = 0; i < SIZE; i++)
                sparseHash[i] = i;

            var skipSize = 0;
            var currentPoistion = 0;
            for (var round = 0; round < 64; round++)
            {
                DoKnotHashAlgorithm(input, sparseHash, ref currentPoistion, ref skipSize);
            }

            var denseHash = new int[16];
            for (var i = 0; i < denseHash.Length; i++)
            {
                var xoredNumber = -1;
                for (var j = 0; j < denseHash.Length; j++)
                {
                    var sparseHashIndex = i * 16 + j;
                    if (xoredNumber == -1)
                    {
                        xoredNumber = sparseHash[sparseHashIndex];
                        continue;
                    }

                    xoredNumber ^= sparseHash[sparseHashIndex];
                }

                denseHash[i] = xoredNumber;
            }

            var result = string.Empty;
            foreach (var i in denseHash)
                result += i.ToString("X2");
            
            Console.WriteLine($"Result is {result}");
        }

        protected override string GetStringDay()
        {
            return "Ten";
        }

        #endregion

        #region Private Methods

        private void DoKnotHashAlgorithm(List<int> lengths, int[] sparseHash, ref int currentPosition, ref int skipSize)
        {
            foreach (var length in lengths)
            {
                if (length > 1 && length <= SIZE)
                {
                    for (var i = 0; i < length / 2; i++)
                    {
                        var leftIndex = (currentPosition + i) % SIZE;
                        var rightIndex = (currentPosition + length - 1 - i) % SIZE;
                        var leftValue = sparseHash[leftIndex];
                        sparseHash[leftIndex] = sparseHash[rightIndex];
                        sparseHash[rightIndex] = leftValue;
                    }
                }

                currentPosition = (currentPosition + length + skipSize) % SIZE;
                skipSize++;
            }
        }

        #endregion
    }
}
