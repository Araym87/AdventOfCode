namespace AdventOfCode2016.Day12
{
    public abstract class Instruction
    {
        #region Properties

        public Variables Variables { get; set; }

        public int Step { get; set; }

        #endregion

        #region Abstract Methods

        public abstract int Perform();

        #endregion

        #region Overriden Methods

        public override string ToString()
        {
            return Variables.ToString();
        }

        #endregion
    }
}
