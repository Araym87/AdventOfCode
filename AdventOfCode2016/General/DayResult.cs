using System;
using System.Text;

namespace AdventOfCode2016.General
{
    public abstract class DayResult
    {
        #region Public Methods

        public void ProvideMeSolution(StringBuilder results)
        {
            var firstRow = $"#########  Results for Day {GetStringDay()}  #########";
            results.AppendLine(firstRow);
            results.AppendLine("FirstPart:");
            FirstPart(results);
            results.AppendLine("SecondPart:");
            SecondPart(results);
            results.AppendLine(new string('-', firstRow.Length));
        }

        #endregion

        #region Protected Methods

        protected virtual void FirstPart(StringBuilder results)
        {
            results.AppendLine("Not Implemented Yet.");
        }

        protected virtual void SecondPart(StringBuilder results)
        {
            results.AppendLine("Not Implemented Yet.");
        }

        #endregion

        #region Abstract Methods

        protected abstract string GetStringDay();

        #endregion
    }
}
