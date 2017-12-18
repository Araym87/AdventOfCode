using System.Collections.Generic;

namespace AdventOfCode2017.Day18
{
    /// <summary>
    /// Instruction for Modulo
    /// </summary>
    public class Modulo : Instruction
    {
        #region Fields

        private char? xChar;
        private long? xLong;

        private char? yChar;
        private long? yLong;

        #endregion

        #region Constructor

        public Modulo(string x, string y)
        {
            if (long.TryParse(x, out var xValue))
                xLong = xValue;
            else
                xChar = x[0];

            if (long.TryParse(y, out var yValue))
                yLong = yValue;
            else
                yChar = y[0];           
        }

        #endregion

        #region Overriden Methods

        public override List<char> Register()
        {
            var result = new List<char>();
            if(xChar.HasValue)
                result.Add(xChar.Value);

            if(yChar.HasValue)
                result.Add(yChar.Value);

            return result;
        }

        public override bool Process(ComputerArgs computerArgs)
        {
            if (!xChar.HasValue)
            {
                computerArgs.Pointer++;
                return true;
            }

            computerArgs.Register[xChar.Value] = computerArgs.Register[xChar.Value] % (yChar.HasValue ? computerArgs.Register[yChar.Value] : yLong.Value);
            computerArgs.Pointer++;
            return true;
        }

        #endregion
    }
}
