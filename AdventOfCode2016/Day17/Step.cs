using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AdventOfCode2016.Day17
{
    public class Step
    {
        public Point Position { get; set; }

        public string CurrentString { get; set; }
    }

    public static class StepExtensions
    {
        private static readonly int[] possibleMovements = new[] { -1, 1 };
        public static MD5 mdAlgorithm = MD5.Create();

        public static IEnumerable<Step> GetAllMoves(this Step step)
        {
            var hashedString = ReturnBytesFromHashedPassword(step.CurrentString);


            for (var i = 0; i < possibleMovements.Length; i++)
            {
                if (i == 0 && CanTurn(hashedString[2]) || i == 1 && CanTurn(hashedString[3]))
                {
                    var newX = step.Position.X + possibleMovements[i];
                    if (newX >= 0 && newX < 4)
                        yield return
                            new Step
                            {
                                CurrentString = step.CurrentString + (possibleMovements[i] < 0 ? "L" : "R"),
                                Position = new Point(newX, step.Position.Y)
                            };
                }

                if (i == 0 && CanTurn(hashedString[0]) || i == 1 && CanTurn(hashedString[1]))
                {
                    var newY = step.Position.Y + possibleMovements[i];
                    if (newY >= 0 && newY < 4)
                        yield return
                            new Step
                            {
                                CurrentString = step.CurrentString + (possibleMovements[i] < 0 ? "U" : "D"),
                                Position = new Point(step.Position.X, newY)
                            };
                }
            }
        }

        private static char[] possibleChars = new[] {'b', 'c', 'd', 'e', 'f',};

        private static bool CanTurn(char a)
        {
            return possibleChars.Contains(a);
        }

        private static string ReturnBytesFromHashedPassword(string word)
        {
            var bytes = mdAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(word));
            return BitConverter.ToString(bytes.Take(2).ToArray()).Replace("-", "").ToLower();
        }
    } 
}


