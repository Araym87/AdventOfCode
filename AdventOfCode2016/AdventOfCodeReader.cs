using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public static class AdventOfCodeReader
    {
        public static IEnumerable<string> ReadReaderLineByLine(StreamReader reader)
        {
            var line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }

    }
}
