namespace AdventOfCode2017.Day16
{
    public interface IDanceInstruction
    {
        #region Methods

        /// <summary>
        /// Perform dance step
        /// </summary>
        /// <param name="dancers">Order of dancer</param>
        void PerformDanceStep(char[] dancers);

        #endregion
    }
}
