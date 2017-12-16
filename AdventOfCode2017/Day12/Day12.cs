using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day12
{
    public class Day12 : DayResult
    {
        #region Protected Methods

        protected override void FirstPart()
        {
            var hashSet = InitializePipes();

            var visitedNodes = new HashSet<int>();
            Recursion(hashSet, visitedNodes, 0);
            Console.WriteLine($"There is {visitedNodes.Count} programs in group 0.");
        }

        protected override void SecondPart()
        {
            var hashSet = InitializePipes();
            var allNodes = new HashSet<int>();
            hashSet.ToList().ForEach(i => { allNodes.Add(i.OneEnd); allNodes.Add(i.SecondEnd); });

            var groups = 0;
            var visitedNodes = new HashSet<int>();
            foreach (var allNode in allNodes.ToList().OrderBy(i => i))
            {
                if (visitedNodes.Contains(allNode))
                    continue;

                Recursion(hashSet, visitedNodes, allNode);
                groups++;
            }

            Console.WriteLine($"There is {groups} groups in total.");
        }

        protected override string GetStringDay()
        {
            return "Twelve";
        }

        #endregion

        #region Private Methods

        private static HashSet<Pipe> InitializePipes()
        {
            var hashSet = new HashSet<Pipe>();
            foreach (var line in AdventOfCodeHelper.FileReader("Inputs\\Input12.txt"))
            {
                var leftSide = Convert.ToInt32(line.Split(new[] { "<->" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                var rightSide = line.Split(new[] { "<->" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(',')
                    .Select(i => Convert.ToInt32(i.Trim())).ToList();

                foreach (var right in rightSide)
                    hashSet.Add(new Pipe { OneEnd = leftSide, SecondEnd = right });
            }

            return hashSet;
        }

        private static void Recursion(HashSet<Pipe> pipes, HashSet<int> visitedNodes, int currentNode)
        {
            var possibleWays = pipes.Where(i => i.OneEnd == currentNode || i.SecondEnd == currentNode).Select(i =>
            {
                if (i.OneEnd == currentNode)
                    return i.SecondEnd;
                if (i.SecondEnd == currentNode)
                    return i.OneEnd;

                throw new Exception();
            }).Where(i => !visitedNodes.Contains(i)).ToList();

            if (possibleWays.Count == 0)
                return;

            possibleWays.ForEach(i => visitedNodes.Add(i));
            foreach (var possibleWay in possibleWays)
            {
                Recursion(pipes, visitedNodes, possibleWay);
            }
        }

        #endregion
    }
}
