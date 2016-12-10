using System;
using System.Linq;

namespace AdventOfCode2016.Day5
{
    public class HashThreadFirst : HashThread
    {
        #region Constructor 

        public HashThreadFirst(Func<Tuple<int, int>> pFunc, Action<char, int, int> pAction, string pPassword, int id) : base(pFunc, pAction, pPassword, id)
        {
        }

        #endregion

        #region Overriden Methods

        protected override void Start()
        {
            while ((boundaries = getNewBoundaries()) != null)
            {
                for (var i = boundaries.Item1; i<boundaries.Item2; i++)
                {
                    var result = ReturnBytesFromHashedPassword(i, 3);
                    if (result.StartsWith(CONDITION))
                    {
                        resultFounded(result.Last(), i, -1);
                    }
                }
            }
            Dispose();
        }

        #endregion
    }
}
