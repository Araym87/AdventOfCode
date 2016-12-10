using System.Drawing;
using System.Linq;

namespace AdventOfCode2016.Day8
{
    public class DoorPanel
    {
        #region Fields

        private readonly bool[][] panel;

        #endregion

        #region Constructors

        public DoorPanel(int pWidth, int pHeight)
        {
            panel = new bool[pHeight][];
            for (var i = 0; i < panel.Length; i++)
            {
             panel[i] = new bool[pWidth];   
            }
        }

        #endregion

        #region Public Methods

        public void LightPixels(EInstruction instruction, int x, int y)
        {
            if(instruction == EInstruction.Rectangle)
                TurnOnRectangle(new Size(x, y));
            else if(instruction == EInstruction.RotateRow) 
                Rotate(x, y, true);
            else
            {
                Rotate(x, y, false);
            }
        }

        public string GetPixels(int row)
        {
            return panel[row].Select(i =>
            {
                if (!i)
                    return " ";

                return "#";
            }).Aggregate((l, m) => l + m);
        }

        public int LightenUp()
        {
            return panel.Select(i => i.Count(j => j)).Sum();
        }

        #endregion

        #region Private Methods

        private void Rotate(int rowColumn, int shift, bool isRow)
        {
            if (isRow)
            {
                var rowList = panel[rowColumn].Take(panel[rowColumn].Length - shift).ToList();
                rowList.InsertRange(0, panel[rowColumn].Skip(panel[rowColumn].Length - shift));
                panel[rowColumn] = rowList.ToArray();
            }
            else
            {
                var column = new bool[panel.Length];
                for (var i = 0; i < column.Length; i++)
                {
                    column[i] = panel[i][rowColumn];
                }
                var columnList = column.Take(column.Length - shift).ToList();
                columnList.InsertRange(0, column.Skip(column.Length - shift));
                column = columnList.ToArray();
                for (var i = 0; i < column.Length; i++)
                {
                    panel[i][rowColumn] = column[i];
                }
            }
        }

        private void TurnOnRectangle(Size size)
        {
            for (var i = 0; i < size.Height; i++)
            {
                for (var j = 0; j < size.Width; j++)
                {
                    panel[i][j] = true;
                }
            }
        }

        #endregion
    }
}
