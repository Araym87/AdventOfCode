using System;

namespace AdventOfCode2017.Day11
{
    public class ThreeDeePoint
    {
        #region Properties

        /// <summary>
        /// X coordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y coordinate
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Z coordinate
        /// </summary>
        public int Z { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Change location according to direction
        /// </summary>
        /// <param name="direction"></param>
        public void Move(Directions direction)
        {
            switch (direction)
            {
                case Directions.N:
                {
                    Y++;
                    X--;
                    break;
                }
                case Directions.S:
                {
                    Y--;
                    X++;
                    break;
                }
                case Directions.NE:
                {
                    X--;
                    Z++;
                    break;
                }
                case Directions.SW:
                {
                    X++;
                    Z--;
                    break;
                }
                case Directions.NW:
                {
                    Y++;
                    Z--;
                    break;
                }
                case Directions.SE:
                {
                    Y--;
                    Z++;
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

        }

        /// <summary>
        /// Current Distance from the point zero
        /// </summary>
        /// <returns></returns>
        public int CurrentDistance()
        {
            return Math.Max(Math.Max(Math.Abs(X), Math.Abs(Y)), Math.Abs(Z));
        }

        #endregion
    }
}
