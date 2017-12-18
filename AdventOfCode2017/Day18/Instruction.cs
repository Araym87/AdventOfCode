using System.Collections.Generic;

namespace AdventOfCode2017.Day18
{
    /// <summary>
    /// Abstract class for instructions
    /// </summary>
    public abstract class Instruction
    {
        #region Abstract Methods

        public abstract List<char> Register();

        public abstract bool Process(ComputerArgs computerArguments);

        #endregion

    }
}
