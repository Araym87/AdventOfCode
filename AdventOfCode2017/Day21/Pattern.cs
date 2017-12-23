using System.Linq;

namespace AdventOfCode2017.Day21
{
    /// <summary>
    /// Class for Holding patterns and its outputs
    /// </summary>
    public class Pattern
    {
        #region Properties

        /// <summary>
        /// Pattern to compare
        /// </summary>
        public bool[,] Input { get; set; }

        /// <summary>
        /// Output pattern
        /// </summary>
        public bool[,] Output { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// The Constructor
        /// </summary>
        /// <param name="input">Input pattern</param>
        /// <param name="output">Output pattern</param>
        public Pattern(string input, string output)
        {
            Input = LoadFromString(input);
            Output = LoadFromString(output);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Load pattern from string
        /// </summary>
        /// <param name="item">Pattern in string representation</param>
        /// <returns>Pattern</returns>
        private static bool[,] LoadFromString(string item)
        {
            var items = item.Split('/').ToList().Select(i => i.Trim()).ToArray();
            var pattern = new bool[items.Length, items.Length];
            for (var i = 0; i < items.Length; i++)
            {
                for (var j = 0; j < items[i].Length; j++)
                {
                    pattern[i, j] = items[i][j] == '#';
                }
            }

            return pattern;
        }

        #endregion
    }
}
