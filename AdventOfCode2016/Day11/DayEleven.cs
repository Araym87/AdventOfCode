using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AdventOfCode.Common.General;

namespace AdventOfCode2016.Day11
{
    public class DayEleven : DayResult
    {
        #region Fields

        // ReSharper disable once InconsistentNaming
        public static short SHIFT = 100;
        // ReSharper disable once InconsistentNaming
        public static int HEIGHT = 4;

        #endregion

        #region Protected Methods

        protected override void FirstPart()
        {
            var mapping = new Dictionary<string, short>();
            var cache = new HashSet<State>();
            var queue = new Queue<State>();

            var building = LoadBuilding("input11.txt", mapping);
            var state = new State(building) {Elevator = 0, Step = 0};
            queue.Enqueue(state);
            cache.Add(queue.Peek());
            var watch = new Stopwatch();
            watch.Start();
            while (queue.Count > 0)
            {
                var currentState = queue.Dequeue();
                foreach (var possibleTransformation in currentState.GetPossibleTransformations())
                {
                    if (cache.Add(possibleTransformation))
                    {
                        if (possibleTransformation.IsFinished())
                        {
                            Console.WriteLine($"Nejlepsi: {possibleTransformation.Step} in {watch.ElapsedMilliseconds}ms");                            
                            return;
                        }

                        queue.Enqueue(possibleTransformation);
                    }
                }
            }  
        }

        protected override void SecondPart()
        {
            var mapping = new Dictionary<string, short>();
            var cache = new HashSet<State>();
            var queue = new Queue<State>();

            var building = LoadBuilding("input11a.txt", mapping);
            var state = new State(building) { Elevator = 0, Step = 0 };
            queue.Enqueue(state);
            cache.Add(queue.Peek());
            var watch = new Stopwatch();
            watch.Start();
            while (queue.Count > 0)
            {
                var currentState = queue.Dequeue();
                foreach (var possibleTransformation in currentState.GetPossibleTransformations())
                {
                    if (cache.Add(possibleTransformation))
                    {
                        if (possibleTransformation.IsFinished())
                        {
                            Console.WriteLine($"Nejlepsi: {possibleTransformation.Step} in {watch.ElapsedMilliseconds}ms");
                            return;
                        }

                        queue.Enqueue(possibleTransformation);
                    }
                }
            }
        }

        #endregion

        #region Private Methods

        private short[][] LoadBuilding(string path, Dictionary<string, short> mapping)
        {
            var currentLength = 0;
            var floor = 0;
            var building = new short[HEIGHT][];
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader($"Inputs\\{path}")))
            {
                var words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Skip(4).ToArray();
                var elements = new List<short>();
                if (words[0].Contains("nothing"))
                    building[floor] = new short[currentLength];
                else
                {
                    words = words.Aggregate((l, m) => l + " " + m).Split(new[] { ",", "and" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in words)
                    {
                        var items = word.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        var isGen = items.Last().Contains("generator");
                        var id = isGen
                            ? items[1]
                            : items[1].Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[0];

                        if (!mapping.ContainsKey(id))
                            mapping.Add(id, (short)(mapping.Count + 1));

                        elements.Add(isGen ? (short)(mapping[id] + SHIFT) : mapping[id]);
                    }

                }
                ResizeAllArrays(ref building, currentLength + elements.Count);
                for (var i = 0; i < elements.Count; i++)
                {
                    building[floor][currentLength + i] = elements[i];
                }
                currentLength += elements.Count;
                floor++;
            }

            return building;
        }

        private void ResizeAllArrays(ref short[][] array, int length)
        {
            for (var i = 0; i < array.Length; i++)
            {
                Array.Resize(ref array[i], length);
            }
        }

        #endregion

        #region Overidden Methods

        protected override string GetStringDay()
        {
            return "Eleven";
        }

        #endregion
    }
}
