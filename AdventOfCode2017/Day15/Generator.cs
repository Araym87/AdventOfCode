using System;

namespace AdventOfCode2017.Day15
{
    public class Generator
    {
        #region Properties

        /// <summary>
        /// Last value of generator
        /// </summary>
        public int LastValue { get; set; }

        /// <summary>
        /// Factor to multiply
        /// </summary>
        public int Factor { get; set; }

        /// <summary>
        /// Multiplication level to divide suitable numbers
        /// </summary>
        public int Multiplication { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="initialValue"></param>
        /// <param name="factor"></param>
        public Generator(int initialValue, int factor)
        {
            LastValue = initialValue;
            Factor = factor;
            Multiplication = -1;
        }

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="initialValue"></param>
        /// <param name="factor"></param>
        /// <param name="multiplication"></param>
        public Generator(int initialValue, int factor, int multiplication)
        {
            LastValue = initialValue;
            Factor = factor;
            Multiplication = multiplication;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Produce next value
        /// </summary>
        /// <returns></returns>
        public void ProduceNextValue()
        {
            var currentValue = (long)LastValue * Factor;
            LastValue = Convert.ToInt32(currentValue % int.MaxValue);
        }

        /// <summary>
        /// Produce next value
        /// </summary>
        /// <returns></returns>
        public void ProduceNextValueWithCondition()
        {
            var currentValue = (long)LastValue * Factor;
            LastValue = Convert.ToInt32(currentValue % int.MaxValue);
            if (LastValue % Multiplication != 0)
                ProduceNextValueWithCondition();
        }

        public string BinaryRepresentationLast16()
        {
            var x = Convert.ToString(LastValue, 2).PadLeft(16);
            return x.Substring(x.Length - 16, 16);
        }

        #endregion
    }
}
