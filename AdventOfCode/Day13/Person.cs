using System.Collections.Generic;

namespace AdventOfCode.ThirteenthDay
{
    public class Person
    {
        public string Name { set; get; }
        public Dictionary<string, int> Relations { get; set; }

        public Person()
        {
            Relations = new Dictionary<string, int>();
        }
    }
}
