using System;
using System.Collections.Generic;

namespace AdventOfCode2017.Day18
{
    /// <summary>
    /// Computer arguments
    /// </summary>
    public class ComputerArgs
    {
        #region Properties

        /// <summary>
        /// Register
        /// </summary>
        public Dictionary<char, long> Register { get; set; } = new Dictionary<char, long>();

        /// <summary>
        /// Pointer to register
        /// </summary>
        public long Pointer { get; set; }

        /// <summary>
        /// Last sent frequency
        /// </summary>
        public long LastFrequency { get; set; }

        /// <summary>
        /// Send action for Send instruction
        /// </summary>
        public Action<long> SendAction { get; set; }

        /// <summary>
        /// Receive action for receive instruction
        /// </summary>
        public Func<long> ReceiveAction { get; set; }

        /// <summary>
        /// Number of calls of Multiply instructions
        /// </summary>
        public int NumberOfMultiplyInstructionCall { get; set; }

        #endregion
    }
}
