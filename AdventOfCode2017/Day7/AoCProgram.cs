using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2017.Day7
{
    public class AoCProgram
    {
        #region Properties

        /// <summary>
        /// Parent program
        /// </summary>
        public AoCProgram Parent { get; set; }

        /// <summary>
        /// Child Programs
        /// </summary>
        public List<AoCProgram> Programs { get; set; } = new List<AoCProgram>();

        /// <summary>
        /// Weight of program
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Name of program
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whole weight of this program and all his childs
        /// </summary>
        public int WholeWight => Weight + Programs.Sum(i => i.WholeWight);

        #endregion

        #region Public Methods

        /// <summary>
        /// Is all sub programs same weight
        /// </summary>
        /// <returns></returns>
        public bool IsSameWeight()
        {
            var weight = Programs[0].WholeWight;
            return Programs.All(i => i.WholeWight == weight);
        }

        /// <summary>
        /// What should be the right weight
        /// </summary>
        /// <returns></returns>
        public int WhatShouldBeTheWeight()
        {
            return Weight + (Parent.Programs.First(i => i.Name != Name).WholeWight - WholeWight);
        }

        /// <summary>
        /// Get Sub Programs branches with inconsistent weight
        /// </summary>
        /// <returns></returns>
        public List<AoCProgram> GetBranchWithNotConsistentWeight()
        {
            if (Programs.Count == 2)
                return Programs;

            var grouped = Programs.GroupBy(item => item.WholeWight, item => item, (key, value) => new { Weight = key, Items = value.ToList() }).ToList();

            return grouped.First(i => i.Items.Count == 1).Items;
        }

        #endregion
    }
}
