namespace AdventOfCode2017.Day12
{
    /// <summary>
    /// Class representing Pipe
    /// </summary>
    public class Pipe
    {
        #region Properties

        /// <summary>
        /// One end of pipe
        /// </summary>
        public int OneEnd { get; set; }

        /// <summary>
        /// Second end of pipe
        /// </summary>
        public int SecondEnd { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Does it contain end
        /// </summary>
        /// <param name="end">End to be contained in pipe</param>
        /// <returns></returns>
        public bool Contains(int end)
        {
            return OneEnd == end || SecondEnd == end;
        }

        #endregion

        #region Overriden Methods

        public override bool Equals(object obj)
        {
            var typedObj = obj as Pipe;
            if (typedObj == null)
                return false;

            if ((OneEnd == typedObj.OneEnd || OneEnd == typedObj.SecondEnd) &&
                (SecondEnd == typedObj.OneEnd || SecondEnd == typedObj.SecondEnd))
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return OneEnd.GetHashCode() * 23 * SecondEnd.GetHashCode() ^ 23;
        }

        #endregion
    }
}
