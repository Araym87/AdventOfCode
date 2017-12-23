using System.Drawing;

namespace AdventOfCode2017.Day22
{
    /// <summary>
    /// Sporifica virus
    /// </summary>
    public class Sporifica
    {
        #region Properties

        /// <summary>
        /// Current position
        /// </summary>
        public Point CurrentPosition { get; set; }

        /// <summary>
        /// Direction of Sporifica
        /// </summary>
        public Direction Direction { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Move Sporifica to another node
        /// </summary>
        public void Move()
        {
            switch (Direction)
            {
                case Direction.Bottom: CurrentPosition= new Point(CurrentPosition.X, CurrentPosition.Y + 1);
                    return;
                case Direction.Top:
                    CurrentPosition = new Point(CurrentPosition.X, CurrentPosition.Y - 1);
                    return;
                case Direction.Left:
                    CurrentPosition = new Point(CurrentPosition.X - 1, CurrentPosition.Y);
                    return;
                case Direction.Right:
                    CurrentPosition = new Point(CurrentPosition.X + 1, CurrentPosition.Y);
                    return;
            }
        }

        /// <summary>
        /// Turn Sporifica according to node status
        /// </summary>
        /// <param name="nodeStatus"></param>
        public void Turn(NodeStatus nodeStatus)
        {
            if (nodeStatus == NodeStatus.Infected)
            {
                switch (Direction)
                {
                    case Direction.Bottom:
                        Direction = Direction.Left;
                        return;
                    case Direction.Top:
                        Direction = Direction.Right;
                        return;
                    case Direction.Left:
                        Direction = Direction.Top;
                        return;
                    case Direction.Right:
                        Direction = Direction.Bottom;
                        return;
                }
            }
            else if(nodeStatus == NodeStatus.Clean)
            {
                switch (Direction)
                {
                    case Direction.Bottom:
                        Direction = Direction.Right;
                        return;
                    case Direction.Top:
                        Direction = Direction.Left;
                        return;
                    case Direction.Left:
                        Direction = Direction.Bottom;
                        return;
                    case Direction.Right:
                        Direction = Direction.Top;
                        return;
                }
            }
            else if (nodeStatus == NodeStatus.Flag)
            {
                switch (Direction)
                {
                    case Direction.Bottom:
                        Direction = Direction.Top;
                        return;
                    case Direction.Top:
                        Direction = Direction.Bottom;
                        return;
                    case Direction.Left:
                        Direction = Direction.Right;
                        return;
                    case Direction.Right:
                        Direction = Direction.Left;
                        return;
                }
            }
        }

        #endregion
    }
}
