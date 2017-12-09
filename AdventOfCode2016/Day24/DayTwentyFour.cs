using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using AdventOfCode.Common.General;

namespace AdventOfCode2016.Day24
{
    public class DayTwentyFour : DayResult
    {
        private const int WALL = -100;
        private const int EMPTY = -1;
        protected override void FirstPart()
        {
            var fileLines = AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input24.txt")).ToList();
            var maze = new int[fileLines[0].Length, fileLines.Count];
            var y = 0;
            var foundNumbers = new List<int>();
            foreach (var fileLine in fileLines)
            {
                var x = 0;
                foreach (var letter in fileLine)
                {
                    switch (letter)
                    {
                        case '#': maze[x, y] = WALL;
                            break;
                        case '.': maze[x, y] = EMPTY;
                            break;

                        default: var foundNumber = (int)char.GetNumericValue(letter);
                            maze[x, y] = foundNumber;
							foundNumbers.Add(foundNumber);
                            break; 
                    }
                    x++;
                }
				y++;
            }
            var allPaths = new List<Path>();
			foundNumbers = foundNumbers.OrderBy(i => i).ToList();
            for (var i = 0; i < foundNumbers.Count; i++)
            {
                for (var j = i; j < foundNumbers.Count; j++)
                {
                    if(i == j)
						continue;

                    var distance = GetNumberOfStepToFound(maze, i, j);

                    allPaths.Add(new Path{StartPoint = i, EndPoint = j, Distance = distance });
					allPaths.Add(new Path{StartPoint = j, EndPoint = i, Distance = distance });
                }
            }

            var shortestPath = int.MaxValue;
			ShortestPath(new List<int>(), 0, 0, allPaths, false, ref shortestPath);
			Console.WriteLine($"Shortest path to visit all numbers is {shortestPath}");
        }

        protected override void SecondPart()
        {
            var fileLines = AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input24.txt")).ToList();
            var maze = new int[fileLines[0].Length, fileLines.Count];
            var y = 0;
            var foundNumbers = new List<int>();
            foreach (var fileLine in fileLines)
            {
                var x = 0;
                foreach (var letter in fileLine)
                {
                    switch (letter)
                    {
                        case '#':
                            maze[x, y] = WALL;
                            break;
                        case '.':
                            maze[x, y] = EMPTY;
                            break;

                        default:
                            var foundNumber = (int)char.GetNumericValue(letter);
                            maze[x, y] = foundNumber;
                            foundNumbers.Add(foundNumber);
                            break;
                    }
                    x++;
                }
                y++;
            }
            var allPaths = new List<Path>();
            foundNumbers = foundNumbers.OrderBy(i => i).ToList();
            for (var i = 0; i < foundNumbers.Count; i++)
            {
                for (var j = i; j < foundNumbers.Count; j++)
                {
                    if (i == j)
                        continue;

                    var distance = GetNumberOfStepToFound(maze, i, j);

                    allPaths.Add(new Path { StartPoint = i, EndPoint = j, Distance = distance });
                    allPaths.Add(new Path { StartPoint = j, EndPoint = i, Distance = distance });
                }
            }

            var shortestPath = int.MaxValue;
            ShortestPath(new List<int>(), 0, 0, allPaths, true, ref shortestPath);
            Console.WriteLine($"Shortest path to visit all numbers and go back to 0 is {shortestPath}");
        }

        private void ShortestPath(List<int> visitedNumbers, int currentNumber, int currentDistance, List<Path> allPaths, bool getBack, ref int shortestDistance)
        {
			visitedNumbers.Add(currentNumber);
            var possibleMoves = allPaths
                .Where(i => i.StartPoint == currentNumber && !visitedNumbers.Contains(i.EndPoint)).ToList();

            if (possibleMoves.Count == 0 && (getBack ? (currentDistance + allPaths.First(i => i.StartPoint == currentNumber && i.EndPoint == 0).Distance) : currentDistance) < shortestDistance)
            {
                shortestDistance = getBack ? currentDistance + allPaths.First(i => i.StartPoint == currentNumber && i.EndPoint == 0).Distance : currentDistance;
            }

            foreach (var possibleMove in possibleMoves)
            {
                ShortestPath(visitedNumbers.ToList(), possibleMove.EndPoint, currentDistance + possibleMove.Distance, allPaths, getBack, ref shortestDistance);
            }

        }

		

        private int GetNumberOfStepToFound(int[,] maze, int startPoint, int lookingNumber)
        {
            var visitedPlaces = new HashSet<Point>();            
            var queue = new Queue<Progress>();
            var startPosition = GetPosition(startPoint, maze);
            queue.Enqueue(startPosition);
            visitedPlaces.Add(startPosition.Position);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                
                var place = maze[current.Position.X, current.Position.Y];
                if (place == lookingNumber)
                    return current.Moves;

                foreach (var possibleMove in GetPossibleMoves(current.Position, maze))
                {
                    if (visitedPlaces.Contains(possibleMove))
                        continue;

                    visitedPlaces.Add(possibleMove);
                    queue.Enqueue(new Progress { Position = possibleMove, Moves = current.Moves + 1 });
                }
            }

			throw new Exception("Not Found");
        }

        private List<Point> GetPossibleMoves(Point currentPosition, int[,] maze)
        {
            var result = new List<Point>();
            // Move Up
			if(maze[currentPosition.X, currentPosition.Y - 1] != WALL)
				result.Add(new Point(currentPosition.X, currentPosition.Y - 1));

			// Down
            if (maze[currentPosition.X, currentPosition.Y + 1] != WALL)
                result.Add(new Point(currentPosition.X, currentPosition.Y + 1));

			// Left
            if (maze[currentPosition.X - 1, currentPosition.Y] != WALL)
                result.Add(new Point(currentPosition.X - 1, currentPosition.Y));

			// Right
            if (maze[currentPosition.X + 1, currentPosition.Y] != WALL)
                result.Add(new Point(currentPosition.X + 1, currentPosition.Y));

            return result;
        }

        private Progress GetPosition(int value, int[,] maze)
        {
            for (var y = 0; y < maze.GetLength(1); y++)
            {
                for (var x = 0; x < maze.GetLength(0); x++)
                {
                    if (maze[x, y] == value)
                        return new Progress {Position = new Point(x, y), Moves = 0};
                }
            }

			throw new Exception("Not Found");
        }

        protected override string GetStringDay()
        {
            return "Twent Four";
        }
    }
}