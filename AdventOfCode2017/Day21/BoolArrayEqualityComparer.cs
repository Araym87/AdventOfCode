using System.Collections.Generic;

namespace AdventOfCode2017.Day21
{
    /// <summary>
    /// Comparer for bool 2D arrays
    /// </summary>
    public class BoolArrayEqualityComparer : IEqualityComparer<bool[,]>
    {
        #region Private Constants

        private static readonly int[,] MaskForThree = { { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 } };
        private static readonly int[,] MaskForTwo = { { 1, 1 }, { 1, 1 } };

        #endregion

        #region IEqualityComparer

        public bool Equals(bool[,] x, bool[,] y)
        {
            var temp = y;
            for (var i = 0; i < 3; i++)
            {
                if (Same(temp, x))
                    return true;

                if (Same(FlipHorizontal(temp), x))
                    return true;

                if (Same(FlipVertical(temp), x))
                    return true;

                temp = TurnRight(temp);
            }

            return false;
        }

        public int GetHashCode(bool[,] obj)
        {
            var size = obj.GetUpperBound(0) + 1;
            var mask = size == 2 ? MaskForTwo : MaskForThree;
            var hashCode = size ^ 197;
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    hashCode *= mask[i, j] ^ 397 * (obj[i, j] ? 0 : 1);
                }
            }

            return hashCode;
        }

        #endregion

        #region Private Static Methods

        private static bool[,] TurnRight(bool[,] input)
        {
            var size = input.GetUpperBound(0) + 1;
            var result = new bool[size, size];
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    result[j, size - 1 - i] = input[i, j];
                }
            }

            return result;
        }

        private static bool[,] FlipVertical(bool[,] input)
        {
            var size = input.GetUpperBound(0) + 1;
            var result = new bool[size, size];
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    result[size - 1 - i, j] = input[i, j];
                }
            }

            return result;
        }

        private static bool[,] FlipHorizontal(bool[,] input)
        {
            var size = input.GetUpperBound(0) + 1;
            var result = new bool[size, size];
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    result[i, size - 1 - j] = input[i, j];
                }
            }

            return result;
        }

        private static bool Same(bool[,] first, bool[,] second)
        {
            var size = first.GetUpperBound(0) + 1;
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    if (first[i, j] != second[i, j])
                        return false;
                }
            }

            return true;
        }

        #endregion
    }
}
