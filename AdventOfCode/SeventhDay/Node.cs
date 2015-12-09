using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.SeventhDay
{
    public class Node
    {
        public Operation Operation { get; set; }

        public string Root { get; set; }

        public List<string> Childs { get; set; }

        public ushort? KnownChildValue { get; set; }
    }
}
