namespace AdventOfCode2016.Day12
{
    public class Jump : Instruction
    {
        #region Fields

        private int? conditionInt;
        private char? conditionChar;

        #endregion

        #region Constructors

        public Jump(int step)
        {
            Step = step;
        }

        public Jump(char item, int step) : this(step)
        {
            conditionChar = item;
        }

        public Jump(int item, int step) : this(step)
        {
            conditionInt = item;
        }

        #endregion

        #region Overriden Methods

        public override int Perform()
        {
            if (conditionInt.HasValue)
            {
                if (conditionInt.Value != 0)
                    return Step;
            }else if (conditionChar.HasValue)
            {
                if (Variables.Variable[conditionChar.Value] != 0)
                    return Step;
            }

            return 1;
        }

        #endregion
    }
}
