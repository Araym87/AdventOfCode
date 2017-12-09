using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day2
{
    public class Day2 : DayResult
    {
        protected override void FirstPart()
        {
            var checksum = 0;

            foreach (var line in AdventOfCodeHelper.FileReader("Inputs\\Input2.txt"))
            {
                var highest = -1;
                var lowest = 100000;

                foreach (var number in LineNumbers(line))
                {
                    if (number < lowest)
                        lowest = number;
                    if (number > highest)
                        highest = number;
                }
                checksum += highest - lowest;
            }
            Console.WriteLine($"Checksum for given input is {checksum}");
        }

        protected override void SecondPart()
        {
            var checksum = 0;

            foreach (var line in AdventOfCodeHelper.FileReader("Inputs\\Input2.txt"))
            {
                var list = LineNumbers(line).OrderBy(i => i).ToList();
                var found = false;

                for (var i = 0; i < list.Count; i++)
                {
                    for (var j = list.Count - 1; j > i; j--)
                    {
                        var res = list[j] / (double)list[i];
                        if (res % 1 == 0)
                        {
                            checksum += (int)res;
                            found = true;
                            break;
                        }
                    }
                    if (found)
                        break;
                }
            }
            Console.WriteLine($"Checksum for given input is {checksum}");
        }

        protected override string GetStringDay()
        {
            return "Two";
        }

        #region Private Methods

        private IEnumerable<int> LineNumbers(string line)
        {
            var items = line.Split(new[] { '\t' }, StringSplitOptions.None);
            foreach (var item in items)
            {
                yield return int.Parse(item);
            }
        }

        #endregion
    }
}
