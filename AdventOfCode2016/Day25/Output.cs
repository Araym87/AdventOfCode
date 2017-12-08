using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2016.Day12;

namespace AdventOfCode2016.Day25
{
    public class Output : Instruction
    {
        #region Fields

        private readonly char? from;
        private readonly int? fromint;

        #endregion

        #region Constructors

        public Output()
        {
            Step = 1;
        }

        public Output(int item) : this()
        {
            fromint = item;
        }

        public Output(char item) : this()
        {
            @from = item;
        }

        #endregion

        public override int Perform()
        {
            if (fromint != null)
            {
                Variables.Output.Append("" + fromint);
            }
            else
            {
                Variables.Output.Append("" + @from);
            }

            return Step;
            
        }
    }
}
