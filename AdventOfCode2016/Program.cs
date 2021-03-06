﻿using System;
using System.Collections.Generic;
using AdventOfCode.Common.General;
using AdventOfCode2016.Day1;
using AdventOfCode2016.Day10;
using AdventOfCode2016.Day11;
using AdventOfCode2016.Day12;
using AdventOfCode2016.Day13;
using AdventOfCode2016.Day14;
using AdventOfCode2016.Day15;
using AdventOfCode2016.Day16;
using AdventOfCode2016.Day17;
using AdventOfCode2016.Day18;
using AdventOfCode2016.Day19;
using AdventOfCode2016.Day2;
using AdventOfCode2016.Day20;
using AdventOfCode2016.Day21;
using AdventOfCode2016.Day22;
using AdventOfCode2016.Day23;
using AdventOfCode2016.Day24;
using AdventOfCode2016.Day25;
using AdventOfCode2016.Day3;
using AdventOfCode2016.Day4;
using AdventOfCode2016.Day5;
using AdventOfCode2016.Day6;
using AdventOfCode2016.Day7;
using AdventOfCode2016.Day8;
using AdventOfCode2016.Day9;

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
            dayResults.Add(new DayTwentyFive());
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
            dayResults.Add(new DayFifteen());
            dayResults.Add(new DaySixteen());
            dayResults.Add(new DaySeventeen());
            dayResults.Add(new DayEighteen());
            dayResults.Add(new DayNineteen());
            dayResults.Add(new DayTwenty());
            dayResults.Add(new DayTwentyOne());
            dayResults.Add(new DayTwentyTwo());
            dayResults.Add(new DayTwentyThree());
            dayResults.Add(new DayTwentyFour());
            dayResults.Add(new DayTwentyFive());
        }

        #endregion

    }
}
