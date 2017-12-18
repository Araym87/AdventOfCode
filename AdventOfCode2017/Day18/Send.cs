using System.Collections.Generic;

namespace AdventOfCode2017.Day18
{
    /// <summary>
    /// Send Instructions
    /// </summary>
    public class Send : Instruction
    {
        #region Fields

        private char? xChar;
        private long? xLong;

        #endregion

        #region Constructor

        public Send(string x)
        {
            if (long.TryParse(x, out var xValue))
                xLong = xValue;
            else
                xChar = x[0];            
        }

        #endregion

        #region Overriden Methods

        public override List<char> Register()
        {
            return xChar.HasValue ? new List<char>{xChar.Value} : new List<char>();
        }

        public override bool Process(ComputerArgs computerArguments)
        {
            var xValue = xChar.HasValue ? computerArguments.Register[xChar.Value] : xLong.Value;
            computerArguments.SendAction.Invoke(xValue);
            computerArguments.Pointer++;
            return true;
        }

        #endregion
    }
}
