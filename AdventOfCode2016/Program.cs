using System;
using System.Collections.Generic;
using AdventOfCode2016.Day1;
using AdventOfCode2016.Day10;
using AdventOfCode2016.Day11;
using AdventOfCode2016.Day12;
using AdventOfCode2016.Day13;
using AdventOfCode2016.Day14;
using AdventOfCode2016.Day2;
using AdventOfCode2016.Day3;
using AdventOfCode2016.Day4;
using AdventOfCode2016.Day5;
using AdventOfCode2016.Day6;
using AdventOfCode2016.Day7;
using AdventOfCode2016.Day8;
using AdventOfCode2016.Day9;
using AdventOfCode2016.General;

namespace AdventOfCode2016
{
    class Program
    {
        #region Properties

        public static List<DayResult> dayResults { get; set; } = new List<DayResult>();

        #endregion

        static void Main(string[] args)
        {
            InitializeCurrentDay();
            //InitializeDays();
            foreach (var dayResult in dayResults)
            {
                dayResult.ProvideMeSolution();
                Console.ReadLine();
            }         
        }

        #region InitializeMethods

        private static void InitializeCurrentDay()
        {
            dayResults.Add(new DayEleven());
        }

        private static void InitializeDays()
        {
            dayResults.Add(new DayOne());
            dayResults.Add(new DayTwo());
            dayResults.Add(new DayThree());
            dayResults.Add(new DayFour());
            dayResults.Add(new DayFive());
            dayResults.Add(new DaySix());
            dayResults.Add(new DaySeven());
            dayResults.Add(new DayEight());
            dayResults.Add(new DayNine());
            dayResults.Add(new DayTen());
            dayResults.Add(new DayEleven());
            dayResults.Add(new DayTwelve());
            dayResults.Add(new DayThirteen());
            dayResults.Add(new DayFourteen());

        }

        #endregion

    }
}
