using System;

namespace AdventOfCode2016.Day5
{
    public class HashThreadSecond : HashThread
    {
        #region Constructor 

        public HashThreadSecond(Func<Tuple<int, int>> pFunc, Action<char, int, int> pAction, string pPassword, int id) : base(pFunc, pAction, pPassword, id)
        {
        }

        #endregion

        #region Overriden Methods

        protected override void Start()
        {
            while ((boundaries = getNewBoundaries()) != null)
            {
                for (var i = boundaries.Item1; i < boundaries.Item2; i++)
                {
                    var result = ReturnBytesFromHashedPassword(i, 4);
                    if (result.StartsWith(CONDITION))
                    {
                        var position = (int)char.GetNumericValue(result[5]);

                        resultFounded(result[6], i, position);
                    }
                }
            }
            Dispose();
        }

        #endregion
    }
}
