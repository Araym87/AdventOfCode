using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode2016.Day1;
using AdventOfCode2016.Day2;
using AdventOfCode2016.Day3;
using AdventOfCode2016.Day4;
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
            var result = new StringBuilder();
            //InitializeCurrentDay();
            InitializeDays();
            foreach (var dayResult in dayResults)
            {
                dayResult.ProvideMeSolution(result);
            }
            Console.WriteLine(result.ToString());
            Console.ReadLine();
        }

        #region InitializeMethods

        private static void InitializeCurrentDay()
        {
            dayResults.Add(new DayFour());
        }

        private static void InitializeDays()
        {
           dayResults.Add(new DayOne());
           dayResults.Add(new DayTwo());
           dayResults.Add(new DayThree());
           dayResults.Add(new DayFour());
        }

        #endregion

    }
}
