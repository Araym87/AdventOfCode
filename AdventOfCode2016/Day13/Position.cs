using System.Drawing;

namespace AdventOfCode2016.Day13
{
    public class Position
    {
        #region Properties

        public int Step { get; set; }

        #endregion

        #region Fields

        private readonly Point current;

        #endregion

        #region Constructors

        public Position(Point pCurrent)
        {
            current = pCurrent;
        }

        #endregion

        #region Public Methods

        public Point GetPosition()
        {
            return current;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Position) obj);
        }

        public override int GetHashCode()
        {
            return current.GetHashCode();
        }

        public static bool operator ==(Position left, Position right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !Equals(left, right);
        }

        #endregion

        #region Protected Methods

        protected bool Equals(Position other)
        {
            return current.Equals(other.current);
        }

        #endregion
    }
}
