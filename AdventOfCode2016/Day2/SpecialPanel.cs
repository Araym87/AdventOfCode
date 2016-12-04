using System.Drawing;

namespace AdventOfCode2016.Day2
{
    public class SpecialPanel
    {
        #region Constants

        private const char NULL_VALUE = 'X';

        #endregion

        #region Fields

        private char[][] panel;
        private Point position;

        #endregion

        #region Constructors

        public SpecialPanel()
        {
            InitializeJaggedArray();
            position = new Point(0, 2);
        }

        #endregion

        #region Public Methods

        public void Move(EDirection direction)
        {
            if (direction == EDirection.Left)
            {
                if (position.X - 1 < 0 || panel[position.Y][position.X - 1] == NULL_VALUE)
                    return;

                position.X -= 1;
            }
            else if (direction == EDirection.Right)
            {
                if (position.X + 1 > 4 || panel[position.Y][position.X + 1] == NULL_VALUE)
                    return;

                position.X += 1;
            }
            else if (direction == EDirection.Down)
            {
                if (position.Y + 1 > 4 || panel[position.Y + 1][position.X] == NULL_VALUE)
                    return;

                position.Y += 1;
            }
            else if (direction == EDirection.Up)
            {
                if (position.Y - 1 < 0 || panel[position.Y - 1][position.X] == NULL_VALUE)
                    return;

                position.Y -= 1;
            }
        }

        public char GetValue()
        {
            return panel[position.Y][position.X];
        }

        #endregion

        #region Private Methods

        private void InitializeJaggedArray()
        {
            panel = new char[5][];
            panel[0] = new[] { NULL_VALUE, NULL_VALUE, '1', NULL_VALUE, NULL_VALUE };
            panel[1] = new[] { NULL_VALUE, '2', '3', '4', NULL_VALUE };
            panel[2] = new[] { '5', '6', '7', '8', '9' };
            panel[3] = new[] { NULL_VALUE, 'A', 'B', 'C', NULL_VALUE };
            panel[4] = new[] { NULL_VALUE, NULL_VALUE, 'D', NULL_VALUE, NULL_VALUE };            
        }

        #endregion
    }
}
