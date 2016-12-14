using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2016.Day12
{
    public class Variables
    {
        #region Properties

        public Dictionary<char, int> Variable = new Dictionary<char, int>();

        #endregion

        #region Public Methods

        public void Add(char item)
        {
            if(!Variable.ContainsKey(item))
                Variable.Add(item, 0);
        }

        #endregion

        #region Overriden Methods

        public override string ToString()
        {
            var res = new StringBuilder();
            foreach (var i in Variable)
            {
                res.Append(i.Key + ":" + i.Value + ";");
            }
            return res.ToString();
        }

        #endregion
    }
}
