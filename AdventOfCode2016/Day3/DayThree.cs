using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2016.General;

namespace AdventOfCode2016.Day3
{
    public class DayThree : DayResult
    {
        #region Protected Methods

        protected override void FirstPart()
        {
            var validTriangles = 0;

            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input3.txt")))
            {
                var sides = line.Trim().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(i => Convert.ToInt32(i)).ToList();
                var triangle = new Triangle(sides);
                if (triangle.IsValid())
                    validTriangles++;
            }

            Console.WriteLine($"Number of valid triangles: {validTriangles}");
        }

        protected override void SecondPart()
        {
            var validTriangles = 0;
            var cachedSides = new List<List<int>>();

            var index = 0;
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input3.txt")))
            {
                index++;
                var sides = line.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => Convert.ToInt32(i)).ToList();
                cachedSides.Add(sides);

                if (index%3 == 0)
                {
                    for (var i = 0; i < cachedSides.Count; i++)
                    {
                        var translatedSides = new List<int>();
                        for (var j = 0; j < cachedSides[i].Count; j++)
                        {
                            translatedSides.Add(cachedSides[j][i]);                            
                        }
                        var triangle = new Triangle(translatedSides);
                        if (triangle.IsValid())
                            validTriangles++;
                    }
                    cachedSides.Clear();
                }
            }

            Console.WriteLine($"Number of valid triangles: {validTriangles}");
        }

        #endregion

        protected override string GetStringDay()
        {
            return "Three";
        }
    }
}
