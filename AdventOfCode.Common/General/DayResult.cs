using System;

namespace AdventOfCode.Common.General
{
    public abstract class DayResult
    {
        #region Public Methods

        public void ProvideMeSolution()
        {
            
            var firstRow = $"#########  Results for Day {GetStringDay()}  #########";
            Console.WriteLine(firstRow);
            Console.WriteLine("FirstPart:");
            FirstPart();
            Console.WriteLine("SecondPart:");
            SecondPart();
            Console.WriteLine(new string('-', firstRow.Length));
        }

        #endregion

        #region Protected Methods

        protected virtual void FirstPart()
        {
            Console.WriteLine("Not Implemented Yet.");
        }

        protected virtual void SecondPart()
        {
            Console.WriteLine("Not Implemented Yet.");
        }

        #endregion

        #region Abstract Methods

        protected abstract string GetStringDay();

        #endregion
    }
}
