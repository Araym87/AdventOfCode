using System;

namespace AdventOfCode2017.Day20
{
    /// <summary>
    /// Particle class
    /// </summary>
    public class Particle
    {
        #region Properties

        /// <summary>
        /// Position of Particle
        /// </summary>
        public Vector Position { get; set; }

        /// <summary>
        /// Velocity of particle
        /// </summary>
        public Vector Velocity { get; set; }

        /// <summary>
        /// Acceleration of particle
        /// </summary>
        public Vector Acceleration { get; set; }

        /// <summary>
        /// Id of particle
        /// </summary>
        public int Id { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Resolving move of particle
        /// </summary>
        public void Move()
        {
            Velocity.X += Acceleration.X;
            Velocity.Y += Acceleration.Y;
            Velocity.Z += Acceleration.Z;
            Position.X += Velocity.X;
            Position.Y += Velocity.Y;
            Position.Z += Velocity.Z;
        }

        /// <summary>
        /// Get Distance of particle from 0,0,0
        /// </summary>
        /// <returns></returns>
        public int GetDistance()
        {
            return Math.Abs(Position.X) + Math.Abs(Position.Y) + Math.Abs(Position.Z);
        }

        #endregion
    }
}
