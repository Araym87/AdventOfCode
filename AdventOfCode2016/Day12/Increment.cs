namespace AdventOfCode2016.Day12
{
    public class Increment : Instruction
    {
        #region Fields

        private readonly char from;
        private readonly bool notMakesense;

        #endregion

        #region Constructors

        public Increment()
        {
            Step = 1;
        }

        public Increment(int item) : this()
        {
            notMakesense = false;
        }

        public Increment(char item) : this()
        {
            @from = item;
        }

        #endregion

        #region Overriden Methods

        public override int Perform()
        {
            if (notMakesense)
                return Step;

            var value = Variables.Variable[from];
            Variables.Variable[from] = value + 1;

            return Step;
        }

        #endregion
    }
}
