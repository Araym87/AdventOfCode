using System.Drawing;

namespace AdventOfCode2016.Day13
{
    public static class PositionExtensions
    {
        #region Extension Methods

        public static Position GetMove(this Position position, Point diff)
        {
            var point = position.GetPosition();
            var newX = point.X + diff.X;
            var newY = point.Y + diff.Y;
            if (newX < 0 || newY < 0)
                return null;

            return new Position(new Point(newX, newY)) { Step = position.Step + 1 };
        }

        #endregion
    }
}
