using System.Collections.Generic;

namespace AdventOfCode2017.Day18
{
    /// <summary>
    /// Receive instructions
    /// </summary>
    public class Receive : Instruction
    {
        #region Fields

        private char? xChar;
        private long? xLong;

        #endregion

        #region Constructor

        public Receive(string x)
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
            if (!xChar.HasValue)
            {
                computerArguments.Pointer++;
                return true;
            }
            computerArguments.Register[xChar.Value] = computerArguments.ReceiveAction.Invoke();
            computerArguments.Pointer++;
            return true;
        }

        #endregion
    }
}
