using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    /// <summary>
    /// Implementation of Knot hash algorithm
    /// </summary>
    public static class KnotHashAlgorithm
    {
        #region Constants

        private const int SIZE = 256;

        #endregion

        #region Public Methods

        /// <summary>
        /// String dense hash
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="salt">Salt</param>
        /// <returns>String dense hash</returns>
        public static string StringDenseHash(string input, string salt = "")
        {
            var result = string.Empty;
            foreach (var i in DenseHash(input, salt))
                result += i.ToString("X2");

            return result;
        }

        /// <summary>
        /// Bit dense hash
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="salt">Salt</param>
        /// <returns>Bit dense hash</returns>
        public static string BitDenseHash(string input, string salt = "")
        {
            var denseHash = DenseHash(input, salt);
            var stringBuilder = new StringBuilder();
            foreach (var character in denseHash)
            {
                stringBuilder.Append(Convert.ToString(character, 2).PadLeft(8, '0'));
            }

            return stringBuilder.ToString();
        }

        #endregion

        #region Private Methods

        private static int[] SparseHash(List<int> input, int[] sparseHash, ref int currentPosition, ref int skipSize)
        {
            foreach (var length in input)
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

            return sparseHash;
        }

        private static int[] DenseHash(string input, string salt = "")
        {
            var converted = StringToIntConversion(input + salt);
            converted.AddRange(new List<int> { 17, 31, 73, 47, 23 });
            var sparseHash = new int[SIZE];
            for (var i = 0; i < SIZE; i++)
                sparseHash[i] = i;

            var skipSize = 0;
            var currentPoistion = 0;
            for (var round = 0; round < 64; round++)
            {
                sparseHash = SparseHash(converted, sparseHash, ref currentPoistion, ref skipSize);
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

            return denseHash;
        }

        private static List<int> StringToIntConversion(string input)
        {
            return input.Trim().Select(i => (int)i).ToList();
        }

        #endregion
    }
}
