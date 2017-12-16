using System;

namespace AdventOfCode2017.Day16
{
    public class Exchange : IDanceInstruction
    {
        #region Fields

        private readonly int leftIndex;
        private readonly int rightIndex;

        #endregion

        #region Constructor

        public Exchange(string left, string right)
        {
            leftIndex = Convert.ToInt32(left);
            rightIndex = Convert.ToInt32(right);
        }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public void PerformDanceStep(char[] dancers)
        {
            var leftValue = dancers[leftIndex];
            dancers[leftIndex] = dancers[rightIndex];
            dancers[rightIndex] = leftValue;
        }

        #endregion
    }
}
