//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace AdventOfCode2016.Day11
//{
//    public class State
//    {
//        private readonly short[][] building;

//        public short Elevator { get; set; }

//        public int Step { get; set; }

//        public State(short[][] state)
//        {
//            building = state;
//        }

//        public override bool Equals(object obj)
//        {
//            var array = obj as State;

//            if (array?.Elevator != Elevator)
//                return false;

//            for (var i = 0; i < building.Length; i++)
//            {
//                for (var j = 0; j < building[i].Length; j++)
//                {
//                    if (building[i][j] != array.building[i][j])
//                        return false;
//                }
//            }

//            return true;
//        }

//        public override int GetHashCode()
//        {
//            unchecked
//            {
//                var hashCode = 397 ^ (Elevator + 1);

//                for (var i = 0; i < building.Length; i++)
//                {
//                    for (var j = 0; j < building[i].Length; j++)
//                    {
//                        if (building[i][j] == 0)
//                            continue;
//                        hashCode *= (i + 1) * (j + 1) ^ building[i][j].GetHashCode();
//                    }
//                }

//                return hashCode;
//            }
//        }

//        public bool IsFinished()
//        {
//            return building[DayEleven.HEIGHT - 1].All(i => i > 0) && Elevator == DayEleven.HEIGHT - 1;
//        }

//        public State Clone()
//        {
//            var newArray = CopyArray(building);
//            return new State(newArray) { Elevator = Elevator, Step = Step };
//        }

//        public short[][] CopyArray(short[][] array)
//        {
//            var result = new short[array.Length][];
//            for (int i = 0; i < array.Length; i++)
//            {
//                var line = new short[array[i].Length];
//                Array.Copy(array[i], line, array[i].Length);
//                result[i] = line;
//            }

//            return result;
//        }

//        public short[] GetFloor(int floor)
//        {
//            return (short[])building[floor].Clone();
//        }

//        public void SetFloor(int floor, short[] items)
//        {
//            building[floor] = items;
//        }

//        public static bool IsFloorValid(short[] floor)
//        {
//            var generators = new List<short>();
//            var chips = new List<short>();
//            foreach (var item in floor)
//            {
//                if (item == 0)
//                    continue;

//                if (item > DayEleven.SHIFT)
//                    generators.Add((short)(item - DayEleven.SHIFT));
//                else
//                {
//                    chips.Add(item);
//                }
//            }
//            for (var i = 0; i < chips.Count; i++)
//            {
//                if (generators.Contains(chips[i]))
//                {
//                    chips.RemoveAt(i);
//                    i--;
//                }
//            }
//            if (chips.Any() && generators.Any())
//                return false;

//            return true;
//        }
//    }
//}
