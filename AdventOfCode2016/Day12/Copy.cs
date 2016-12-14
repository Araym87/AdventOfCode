namespace AdventOfCode2016.Day12
{
    public class Copy : Instruction
    {
        #region Fields

        private char? fromChar;
        private int? fromInt;

        private readonly char toChar;
        private readonly bool notMakeSense;

        #endregion

        #region Constructors

        public Copy()
        {
            Step = 1;
        }

        public Copy(int raise, int to) : this()
        {
            notMakeSense = true;
        }

        public Copy(int raise, char to) : this()
        {
            fromInt = raise;
            toChar = to;
        }

        public Copy(char raise, char to) : this()
        {
            fromChar = raise;
            toChar = to;
        }

        public Copy(char raise, int to) : this()
        {
            notMakeSense = true;
        }

        #endregion

        #region Overriden Methods

        public override int Perform()
        {
            if (notMakeSense)
                return Step;

            if (fromInt.HasValue)
            {
                Variables.Variable[toChar] = fromInt.Value;
            }
            else if (fromChar.HasValue)
            {
                Variables.Variable[toChar] = Variables.Variable[fromChar.Value];
            }

            return Step;
        }

        #endregion
    }
}
