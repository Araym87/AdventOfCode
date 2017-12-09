using System;
using System.IO;
using System.Text;
using AdventOfCode.Common.General;

namespace AdventOfCode2016.Day2
{
    public class DayTwo : DayResult
    {
        #region Protected Methods

        protected override void FirstPart()
        {
            var panel = new Panel();
            var pass = new StringBuilder();
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input2.txt")))
            {
                foreach (var character in line)
                {
                    panel.Move(GetDirection(character));
                }
                pass.Append(panel.GetValue());
            }
            Console.WriteLine($"Password is {pass}");
        }

        protected override void SecondPart()
        {
            var panel = new SpecialPanel();
            var pass = new StringBuilder();
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input2.txt")))
            {
                foreach (var character in line)
                {
                    panel.Move(GetDirection(character));
                }
                pass.Append(panel.GetValue());
            }
            Console.WriteLine($"Password is {pass}");
        }

        #endregion

        #region Overriden Methods

        protected override string GetStringDay()
        {
            return "Two";
        }

        #endregion

        #region Private Methods

        private EDirection GetDirection(char a)
        {
            switch (a)
            {
                case 'U' : return EDirection.Up;
                case 'D': return EDirection.Down;
                case 'R': return EDirection.Right;
                case 'L': return EDirection.Left;
            }
            throw new NotImplementedException();
        }

        #endregion
    }
}
