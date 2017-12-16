using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day16
{
    public class CharArrayEqualityComparer : IEqualityComparer<char[]>
    {
        #region Overriden Methods

        /// <summary>
        /// Equality of two char[]
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(char[] x, char[] y)
        {
            if (x.Length != y.Length)
                return false;

            return !x.Where((t, i) => t != y[i]).Any();
        }

        /// <summary>
        /// Hashcode of char[]
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(char[] obj)
        {
            unchecked
            {
                return obj.Aggregate(17, (current, element) => current * 31 + element.GetHashCode());
            }
        }

        #endregion
    }
}
