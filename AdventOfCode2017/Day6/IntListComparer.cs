using System.Collections.Generic;

namespace AdventOfCode2017.Day6
{
    public class IntListComparer : IEqualityComparer<List<int>>
    {
        #region Public Methods

        public bool Equals(List<int> x, List<int> y)
        {
            if (x.Count != y.Count)
                return false;

            for (var i = 0; i < x.Count; i++)
            {
                if (x[i] != y[i])
                    return false;
            }

            return true;
        }

        public int GetHashCode(List<int> obj)
        {
            var hashCode = 0;
            for (int i = 0; i < obj.Count; i++)
            {
                hashCode += ((i + 1) * (obj[i] ^ 197)) ^ 397;
            }
            return hashCode;
        }

        #endregion
    }
}
