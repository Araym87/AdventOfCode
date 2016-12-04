using System;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode2016.General;

namespace AdventOfCode2016.Day1
{
    public class DayOne : DayResult
    {
        #region Protected Methods

        protected override void FirstPart(StringBuilder stringBuilder)
        {
            var headingDirection = EHeadingDirection.North;
            var position = new Position(0, 0);

            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input1.txt")))
            {
                var instructions = line.Split(new [] { ',' }, StringSplitOptions.None).ToList();
                foreach (var instruction in instructions.Select(i => i.Trim()))
                {
                    headingDirection = Turn(headingDirection, instruction);
                    var distance = GetDistance(instruction);

                    if (headingDirection == EHeadingDirection.East)
                        position.Horizontal += distance;
                    else if (headingDirection == EHeadingDirection.West)
                        position.Horizontal -= distance;
                    else if (headingDirection == EHeadingDirection.North)
                        position.Vertical += distance;
                    else
                        position.Vertical -= distance;
                }
            }

            stringBuilder.AppendLine($"Distance is {position.GetDistanceFromStartPoint()} blocks.");            
        }

        protected override void SecondPart(StringBuilder stringBuilder)
        {
            var headingDirection = EHeadingDirection.North;
            var arraySize = 400;
            bool[,] map = new bool[arraySize, arraySize];
            var position = new Position(arraySize/2, arraySize/2);            
            map[position.Horizontal, position.Vertical] = true;
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input1.txt")))
            {
                var instructions = line.Split(new [] { ',' }, StringSplitOptions.None).ToList();
                var found = false;
                foreach (var instruction in instructions.Select(i => i.Trim()))
                {
                    headingDirection = Turn(headingDirection, instruction);
                    var distance = GetDistance(instruction);

                    var newHorizontal = position.Horizontal;
                    var newVertical = position.Vertical;
                    if (headingDirection == EHeadingDirection.East)
                        newHorizontal += distance;
                    else if (headingDirection == EHeadingDirection.West)
                        newHorizontal -= distance;
                    else if (headingDirection == EHeadingDirection.North)                    
                        newVertical += distance;                        
                    else
                        newVertical -= distance;

                    var directionDenominator = headingDirection == EHeadingDirection.East || headingDirection == EHeadingDirection.South ? -1 : 1;
                    var boundaries = Math.Abs(position.Horizontal - newHorizontal);
                    for (var i = 1; i <= boundaries; i++)
                    {
                        position.Horizontal += directionDenominator;
                        if (AlreadyVisitiedNode(map, position))
                        {
                            found = true;
                            break;
                        }
                    }
                    boundaries = Math.Abs(position.Vertical - newVertical);
                    for (var i = 1; i <= boundaries; i++)
                    {
                        position.Vertical += directionDenominator;
                        if (AlreadyVisitiedNode(map, position))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (found)
                        break;
                }
            }

            stringBuilder.AppendLine($"Distance is {position.GetDistanceFromStartPoint()} blocks.");
        }

        #endregion

        #region Overriden Methods

        protected override string GetStringDay()
        {
            return "One";
        }

        #endregion

        #region Private Methods

        private EHeadingDirection Turn(EHeadingDirection originalDirection, string instruction)
        {
            var turn = instruction.StartsWith("R") ? 1 : -1;
            originalDirection += turn;
            if (originalDirection == EHeadingDirection.NoneN)
                originalDirection = EHeadingDirection.West;
            if (originalDirection == EHeadingDirection.NoneW)
                originalDirection = EHeadingDirection.North;

            return originalDirection;            
        }

        private int GetDistance(string instruction)
        {
            return Convert.ToInt32(instruction.Substring(1));
        }

        private bool AlreadyVisitiedNode(bool[,] map, Position position)
        {
            if (map[position.Horizontal, position.Vertical])
            {
                return true;
            }

            map[position.Horizontal, position.Vertical] = true;
            return false;
        }

        #endregion
    }
}
