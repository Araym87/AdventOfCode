using System;
using System.IO;
using System.Linq;
using AdventOfCode2016.General;

namespace AdventOfCode2016.Day8
{
    public class DayEight : DayResult
    {
        #region Constants

        private const int WIDTH = 50;
        private const int TALL = 6;
        private const string RECTANGLE = "rect";
        private const string ROW = "row";
        private const char SPLITTER = 'x';
        private const char WORD_SPLITTER = ' ';
        private const char EQUAL_SPLITTER = '=';

        #endregion

        #region Protected Methods

        protected override void FirstPart()
        {
            var panel = new DoorPanel(WIDTH, TALL);
            
            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input8.txt")))
            {
                var words = line.Split(new[] {WORD_SPLITTER}, StringSplitOptions.RemoveEmptyEntries);
                if (words[0].Equals(RECTANGLE))
                {
                    var dim = words[1].Split(new[] {SPLITTER}, StringSplitOptions.RemoveEmptyEntries);
                    panel.LightPixels(EInstruction.Rectangle, Convert.ToInt32(dim[0]), Convert.ToInt32(dim[1]));
                }
                else
                {
                    var instruction = words[1] == ROW ? EInstruction.RotateRow : EInstruction.RotateColumn;
                    var shift = Convert.ToInt32(words.Last());
                    var rowColumn = Convert.ToInt32(words[2].Split(new[] {EQUAL_SPLITTER}, StringSplitOptions.RemoveEmptyEntries)[1]);
                    panel.LightPixels(instruction, rowColumn, shift);
                }
            }

            Console.WriteLine($"Number of lighten pixels is {panel.LightenUp()}");
        }

        protected override void SecondPart()
        {
            var panel = new DoorPanel(WIDTH, TALL);

            foreach (var line in AdventOfCodeReader.ReadReaderLineByLine(new StreamReader("Inputs\\input8.txt")))
            {
                var words = line.Split(new[] { WORD_SPLITTER }, StringSplitOptions.RemoveEmptyEntries);
                if (words[0].Equals(RECTANGLE))
                {
                    var dim = words[1].Split(new[] { SPLITTER }, StringSplitOptions.RemoveEmptyEntries);
                    panel.LightPixels(EInstruction.Rectangle, Convert.ToInt32(dim[0]), Convert.ToInt32(dim[1]));
                }
                else
                {
                    var instruction = words[1] == ROW ? EInstruction.RotateRow : EInstruction.RotateColumn;
                    var shift = Convert.ToInt32(words.Last());
                    var rowColumn = Convert.ToInt32(words[2].Split(new[] { EQUAL_SPLITTER }, StringSplitOptions.RemoveEmptyEntries)[1]);
                    panel.LightPixels(instruction, rowColumn, shift);
                }
            }
            Console.WriteLine($"Lighten up screen");
            for (var i = 0; i < TALL; i++)
            {
                Console.WriteLine($"{panel.GetPixels(i)}");
            }
            
        }

        #endregion

        #region Overriden Methods

        protected override
            string GetStringDay()
        {
            return "Eight";
        }

        #endregion
    }
}
