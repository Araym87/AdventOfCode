using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode2016.General;

namespace AdventOfCode2016.Day7
{
    public class DaySeven : DayResult
    {
        #region Protected Methods

        protected override void FirstPart()
        { 
            var count = 0;
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input7.txt")))
            {
                var brackets = new List<Point>();

                var e = Regex.Matches(line, @"(.)(.)\2\1");
                var indexesOfLeft = Regex.Matches(line, @"\[");
                var indexesOfRight = Regex.Matches(line, @"\]");
                for (var i = 0; i < indexesOfLeft.Count; i++)
                {
                    brackets.Add(new Point(indexesOfLeft[i].Index, indexesOfRight[i].Index));
                }
                var found = false;
                foreach (Match match in e)
                {
                    if(match.Value[0] == match.Value[1])
                        continue;

                    if (brackets.Any(i => i.X < match.Index && i.Y > match.Index))
                    {
                        found = false;
                        break;
                    }

                    found = true;
                }

                if (found)
                    count++;
            }

            Console.WriteLine($"Number of correct IP addresses is {count}");

        }

        protected override void SecondPart()
        {
            var count = 0;
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input7.txt")))
            {
                if (GetABAAndBAB(line))
                    count++;
            }

            Console.WriteLine($"Number of correct IP addresses is {count}");
        }

        protected override string GetStringDay()
        {
            return "Seven";
        }

        #endregion

        #region Private Methods

        // ReSharper disable once InconsistentNaming
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private bool GetABAAndBAB(string line)
        {
            var inBAB = false;
            var ABA = new List<string>();
            var BAB = new List<string>();

            for (var i = 0; i < line.Length - 2; i++)
            {
                if (line[i] == '[')
                {
                    inBAB = true;
                    continue;
                }
                if (line[i] == ']')
                {
                    inBAB = false;
                }

                if (line[i] == line[i + 2])
                {
                    if (inBAB)
                        BAB.Add($"{line[i]}{line[i + 1]}{line[i]}");
                    else
                        ABA.Add($"{line[i]}{line[i + 1]}{line[i]}");
                }
            }

            if (ABA.Any(i => BAB.Contains(Switch(i))))
                return true;

            return false;
        }

        private string Switch(string match)
        {
            return $"{match[1]}{match[0]}{match[1]}";
        }

        #endregion
    }
}
