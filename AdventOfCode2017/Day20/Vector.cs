namespace AdventOfCode2017.Day20
{
    /// <summary>
    /// Vector class
    /// </summary>
    public class Vector
    {
        #region Properties

        /// <summary>
        /// X coord
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y coord
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Z coord
        /// </summary>
        public int Z { get; set; }

        #endregion

        #region Overriden Methods

        public override int GetHashCode()
        {
            return X ^ 197 * Y ^ 397 * Z ^ 91;
        }

        public override bool Equals(object obj)
        {
            var typedObj = obj as Vector;
            if (typedObj == null)
                return false;

            return typedObj.X == X && typedObj.Y == Y && typedObj.Z == Z;
        }

        #endregion
    }
}
