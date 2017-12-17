using System;
using System.Collections.Generic;
using AdventOfCode.Common.General;

namespace AdventOfCode2017
{
    class Program
    {
        #region Properties

        /// <summary>
        /// All Day Results
        /// </summary>
        public static List<DayResult> DayResults { get; set; } = new List<DayResult>();

        #endregion

        #region Constructors

        static void Main(string[] args)
        {
            InitializeCurrentDay();
            //InitializeDays();
            foreach (var dayResult in DayResults)
            {
                dayResult.ProvideMeSolution();
                Console.ReadLine();
            }
        }

        #endregion

        #region InitializeMethods

        private static void InitializeCurrentDay()
        {
            DayResults.Add(new Day17.Day17());
        }

        private static void InitializeDays()
        {
            DayResults.Add(new Day1.Day1());
            DayResults.Add(new Day2.Day2());
            DayResults.Add(new Day3.Day3());
            DayResults.Add(new Day4.Day4());
            DayResults.Add(new Day5.Day5());
            DayResults.Add(new Day6.Day6());
            DayResults.Add(new Day7.Day7());
            DayResults.Add(new Day8.Day8());
            DayResults.Add(new Day9.Day9());
            DayResults.Add(new Day10.Day10());
            DayResults.Add(new Day11.Day11());
            DayResults.Add(new Day12.Day12());
            DayResults.Add(new Day13.Day13());
            DayResults.Add(new Day14.Day14());
            DayResults.Add(new Day15.Day15());
            DayResults.Add(new Day16.Day16());
            DayResults.Add(new Day17.Day17());
            //DayResults.Add(new DayEighteen());
            //DayResults.Add(new DayNineteen());
            //DayResults.Add(new DayTwenty());
            //DayResults.Add(new DayTwentyOne());
            //DayResults.Add(new DayTwentyTwo());
            //DayResults.Add(new DayTwentyThree());
            //DayResults.Add(new DayTwentyFour());
            //DayResults.Add(new DayTwentyFive());
        }

        #endregion
    }
}
