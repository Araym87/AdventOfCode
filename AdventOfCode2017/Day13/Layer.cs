namespace AdventOfCode2017.Day13
{
    public class Layer
    {
        #region Fields

        private bool directionDown;

        #endregion

        #region Properties

        /// <summary>
        /// Size of Layer
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Position of scanner in Layer
        /// </summary>
        public int ScannerPosition { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Scanner Move
        /// </summary>
        public void Move()
        {
            if (Size == -1)
                return;

            if (!directionDown)
            {
                if (ScannerPosition == Size - 1)
                {
                    directionDown = true;
                    Move();
                    return;
                }
                ScannerPosition++;
            }
            else
            {
                if (ScannerPosition == 0)
                {
                    directionDown = false;
                    Move();
                    return;
                }
                ScannerPosition--;
            }
        }

        /// <summary>
        /// Is Caught?
        /// </summary>
        /// <returns></returns>
        public bool Caught()
        {
            return Size != -1  && ScannerPosition == 0;
        }

        /// <summary>
        /// Reinitialize Layer
        /// </summary>
        public void Reinitialize()
        {
            if (Size == -1)
                return;

            ScannerPosition = 0;
            directionDown = false;
        }

        #endregion
    }
}
