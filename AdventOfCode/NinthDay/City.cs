using System.Collections.Generic;

namespace AdventOfCode.NinthDay
{
    public class City
    {
        public string Name { get; set; }
        public List<Route> OneWays { get; set; } = new List<Route>();
    }
}
