using System;

namespace AdventOfCode2017.Day16
{
    public class Partner : IDanceInstruction
    {
        #region Fields

        private readonly char leftChar;
        private readonly char rightChar;

        #endregion

        #region Constructor

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public Partner(string left, string right)
        {
            leftChar = left[0];
            rightChar = right[0];
        }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public void PerformDanceStep(char[] dancers)
        {
            var leftIndex = GetIndexOf(dancers, leftChar);
            var rightIndex = GetIndexOf(dancers, rightChar);
            var leftValue = dancers[leftIndex];
            dancers[leftIndex] = dancers[rightIndex];
            dancers[rightIndex] = leftValue;
        }

        #endregion

        #region Private Methods

        private int GetIndexOf(char[] dancers, char letter)
        {
            for (int i = 0; i < dancers.Length; i++)
            {
                if (dancers[i] == letter)
                    return i;
            }
            throw new Exception("Not Found");
        }

        #endregion
    }
}
