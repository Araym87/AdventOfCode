using System;

namespace AdventOfCode2017.Day16
{
    public class Spin : IDanceInstruction
    {
        #region Fields

        private readonly int numberOfSpin;

        #endregion

        #region Constructors

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="input"></param>
        public Spin(string input)
        {
            numberOfSpin = Convert.ToInt32(input);
        }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public void PerformDanceStep(char[] dancers)
        {
            var order = new string(dancers);
            var length = dancers.Length;
            for (var i = 0; i < length; i++)
            {
                var newIndex = i < length - numberOfSpin ? i + numberOfSpin : (i + numberOfSpin) % length;
                dancers[newIndex] = order[i];
            }
        }

        #endregion
    }
}
