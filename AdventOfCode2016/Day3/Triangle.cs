using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Day3
{
    public class Triangle
    {
        #region Fields

        private List<int> sides;

        #endregion

        #region Constructors

        public Triangle(List<int> pSides)
        {
            sides = pSides.OrderBy(i => i).ToList();
        }

        #endregion

        #region Public Methods

        public bool IsValid()
        {
            if (sides[0] < 0)
                return false;

            return sides[0] + sides[1] > sides[2];
        }

        #endregion

    }
}
