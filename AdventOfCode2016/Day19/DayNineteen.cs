using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Common.General;

namespace AdventOfCode2016.Day19
{
    public class DayNineteen : DayResult
    {
        protected override void FirstPart()
        {
            //var numbers = new List<bool>();
            //const int SIZE = 3017957;
            //var diff = (int)Math.Ceiling((double)SIZE/2);
            //for (var i = 1; i <= SIZE; i++)
            //{
            //    numbers.Add(true);
            //}

            //var setFalse = false;
            //while (numbers.Count(j => j) > 1)
            //{
            //    for (var i = 0; i < numbers.Count; i++)
            //    {
            //        if (!setFalse && numbers[i])
            //        {
            //            setFalse = true;
            //        }
            //        else if (setFalse && numbers[i])
            //        {
            //            numbers[i] = false;
            //            setFalse = false;
            //        }
            //    }
            //}

            //Console.WriteLine($"Left is {numbers.FindIndex(i => i) + 1}");
        }

        //protected override void SecondPart()
        //{
        //    const int SIZE = 5;
        //    var numbers = Enumerable.Repeat(true, SIZE).ToArray();

        //    var index = 0;
        //    while (numbers.Count(j => j) > 1)
        //    {
        //        var after = numbers.Skip(index).Count(i => i);
        //        var before = numbers.Take(index).Count(i => i);
        //        var sum = after + before;

        //        var middle = (int)Math.Floor((double)sum/2);
        //        var items = 0;

        //        var item = numbers.Skip(index).SkipWhile(i =>
        //        {
        //            if (!i)
        //                return true;

        //            middle--;
        //            if (middle > 0)
        //                return true;

        //            return false;
        //        }).FirstOrDefault();
        //        if (item)
        //        {
        //            item = false;
        //        }

        //    }

        //    for (var i = 0; i < numbers.Length; i++)
        //    {
        //        if (numbers[i])
        //        {
        //            Console.WriteLine($"Left is {i + 1}");
        //            break;
        //        }
        //    }

        //}

        protected override void SecondPart()
        {
            const int SIZE = 3017957;
            var queue1 = new LinkedList<int>();
            var queue2 = new LinkedList<int>();

            for (int i = 0; i < SIZE; i++)
            {
                if (i < SIZE/2 + 1)
                    queue1.AddLast(i + 1);
                else 
                    queue2.AddLast(i + 1);
            }
            var index = 0;
            while (queue1.Count + queue2.Count > 1)
            {
                if ((queue1.Count + queue2.Count)%2 == 0)
                {
                    queue2.RemoveFirst();
                }
                else
                {
                    queue1.RemoveLast();
                }

                var nodeFromTwo = queue2.First;
                if (nodeFromTwo != null)
                {
                    queue2.RemoveFirst();
                    queue1.AddLast(nodeFromTwo);
                }


                var nodeFromOne = queue1.First;
                if (nodeFromOne != null)
                {
                    queue1.RemoveFirst();
                    queue2.AddLast(nodeFromOne);
                }

            }
            var number = -1;
            
            //Console.WriteLine($"Last item is {linkedList.First.Value}");
        }

        protected override string GetStringDay()
        {
            return "Nineteen";
        }
    }
}
