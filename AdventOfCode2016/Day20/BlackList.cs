using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016.Day20
{
    public class BlackList
    {
        public List<Tuple<uint, uint>> items = new List<Tuple<uint, uint>>();

        public void Add(uint low, uint high)
        {
            items.Add(Tuple.Create(low, high));
            items = items.OrderBy(i => i.Item1).ToList();
            Join();
        }

        public uint GetMinimum()
        {
            return items[0].Item2 + 1;
        }

        public uint TotalAllowedIps()
        {
            uint sum = 0;
            for (var i = 0; i < items.Count; i++)
            {
                if (i + 1 >= items.Count)
                    break;
                var tuple = items[i];
                var nextTuple = items[i + 1];
                sum += nextTuple.Item1 - tuple.Item2 - 1;
            }
            return sum;
        }

        private void Join()
        {
            for (var i = 0; i < items.Count; i++)
            {
                if (i + 1 >= items.Count)
                    break;
                var tuple = items[i];
                var nextTuple = items[i + 1];

                if (tuple.Item2 + 1 == nextTuple.Item1 || tuple.Item2 > nextTuple.Item1)
                {
                    items.RemoveAt(i + 1);
                    items.RemoveAt(i);
                    Tuple<uint, uint> newItem = null;
                    if (tuple.Item2 < nextTuple.Item2)
                        newItem = Tuple.Create(tuple.Item1, nextTuple.Item2);
                    else
                        newItem = Tuple.Create(tuple.Item1, tuple.Item2);

                    items.Insert(i, newItem);
                    i--;
                }
            }
        }

    }
}
