using System;

namespace AdventOfCode2016.Day1
{
    public class Position
    {
        #region Fields

        private readonly int startHorizontal;
        private readonly int startVertical;

        #endregion

        #region Properties

        public int Horizontal { get; set; }
        public int Vertical { get; set; }

        #endregion

        #region Constructors

        public Position(int horizontal, int vertical)
        {
            startHorizontal = horizontal;
            Horizontal = horizontal;
            startVertical = vertical;
            Vertical = vertical;
        }

        #endregion

        #region Public Methods

        public int GetDistanceFromStartPoint()
        {
            return Math.Abs(Horizontal - startHorizontal) + Math.Abs(Vertical - startVertical);
        }

        #endregion
    }
}
