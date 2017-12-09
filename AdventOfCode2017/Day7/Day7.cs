using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day7
{
    public class Day7 : DayResult
    {
        #region Protected Methods

        protected override void FirstPart()
        {
            var allItems = InitializeProgramStructure();
            Console.WriteLine($"Name of the bottom program is {allItems.Values.First(i => i.Parent == null).Name}");
        }

        protected override void SecondPart()
        {
            var allItems = InitializeProgramStructure();
            var queue = new Queue<AoCProgram>();
            queue.Enqueue(allItems.Values.First(i => i.Parent == null));

            while (true)
            {
                var currentItem = queue.Dequeue();
                var isSameWeight = currentItem.IsSameWeight();
                if (queue.Count == 0 && isSameWeight)
                {
                    // Result
                    Console.WriteLine($"Correct weight of inconsistent program should be {currentItem.WhatShouldBeTheWeight()}");
                    break;
                }

                if (queue.Count > 0 && isSameWeight)
                    continue;

                currentItem.GetBranchWithNotConsistentWeight().ForEach(i => queue.Enqueue(i));
            }
        }

        protected override string GetStringDay()
        {
            return "Seven";
        }

        #endregion

        #region Private Methods

        private Dictionary<string, AoCProgram> InitializeProgramStructure()
        {
            var allItems = new Dictionary<string, AoCProgram>();
            foreach (var line in AdventOfCodeHelper.FileReader("Inputs\\Input7.txt"))
            {
                var parts = line.Split(new[] { "->" }, StringSplitOptions.RemoveEmptyEntries);

                //Name
                var name = parts[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
                if (!allItems.ContainsKey(name))
                    allItems.Add(name, new AoCProgram { Name = name });

                var newItem = allItems[name];
                newItem.Weight = int.Parse(parts[0].Split(new[] { '(' })[1].TrimEnd(new[] { ')', ' ' }));

                if (parts.Length == 1)
                    continue;

                var toIgnore = parts[1].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(i => new AoCProgram { Name = i.Trim(), Parent = newItem }).ToList();

                foreach (var aoCProgram in toIgnore)
                {
                    if (!allItems.ContainsKey(aoCProgram.Name))
                    {
                        allItems.Add(aoCProgram.Name, aoCProgram);
                    }

                    var item = allItems[aoCProgram.Name];
                    item.Parent = newItem;
                    newItem.Programs.Add(item);
                }
            }

            return allItems;
        }

        #endregion
    }
}
