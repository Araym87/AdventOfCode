using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Day22
{
    public class Node
    {
        public Point Position { get; set; }

        public int Used { get; set; }

        public int Avail { get; set; }

        public bool CanTransferData(Node x)
        {
            if (Used == 0)
                return false;

            if (x.Avail >= Used)
                return true;

            return false;
        }
    }
}
