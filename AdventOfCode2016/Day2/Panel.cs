using System.Drawing;

namespace AdventOfCode2016.Day2
{
    public class Panel
    {
        #region Constants

        private const int SIZE = 2;

        #endregion

        #region Fields

        private Point position;

        #endregion

        #region Constructors

        public Panel()
        {
            position = new Point(1,1);
        }

        #endregion

        #region Public Methods

        public void Move(EDirection direction)
        {
            if (direction == EDirection.Left)
            {
                if (position.X > 0)
                    position.X -= 1;
            }
            else if(direction == EDirection.Right)
            {
                if (position.X < SIZE)
                    position.X += 1;
            }
            else if (direction == EDirection.Down)
            {
                if (position.Y < SIZE)
                    position.Y += 1;
            }
            else if (direction == EDirection.Up)
            {
                if (position.Y > 0)
                    position.Y -= 1;
            }
        }

        public int GetValue()
        {
            return position.Y*3 + position.X + 1;
        }

        #endregion

    }
}
