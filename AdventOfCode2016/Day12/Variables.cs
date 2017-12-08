using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2016.Day12
{
    public class Variables
    {
        #region Properties

        public Dictionary<char, int> Variable = new Dictionary<char, int>();

        public List<Instruction> Instructions;

        public StringBuilder Output = new StringBuilder();

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

        public Variables EmptyClone()
        {
            var x = new Variables();
            x.Variable = new Dictionary<char, int>();
            foreach (var i in Variable)
            {
                x.Variable.Add(i.Key, i.Value);
            }
            x.Instructions = Instructions;
            Output = new StringBuilder();

            return x;
        }
    }
}
