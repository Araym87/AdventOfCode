using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common.General;

namespace AdventOfCode2017.Day20
{
    public class Day20 : DayResult
    {
        #region Overriden Methods

        protected override void FirstPart()
        {
            var particles = GetParticles();
            var closestItem = particles.OrderBy(i => i.GetDistance()).First().Id;
            var numberOfIteration = 1;
            while (numberOfIteration < 500)
            {
                particles.ForEach(i => i.Move());
                var newClosestItem = particles.OrderBy(i => i.GetDistance()).First().Id;
                if (closestItem == newClosestItem)
                {
                    numberOfIteration++;
                }
                else
                {
                    closestItem = newClosestItem;
                    numberOfIteration = 1;
                }
            }

            Console.WriteLine($"Closest particle is {closestItem}.");
        }

        protected override void SecondPart()
        {
            var particles = GetParticles();            

            var numberOfIteration = 1;
            while (numberOfIteration < 50)
            {
                particles.ForEach(i => i.Move());
                var wasRemoved = false;
                foreach (var item in particles.GroupBy(i => i.Position, i => i, (position, id) => new { Position = position, Particles = id.ToList() }))
                {
                    if(item.Particles.Count == 1)
                        continue;

                    foreach (var particle in item.Particles)
                    {
                        particles.Remove(particle);
                    }
                    wasRemoved = true;
                }
                if (wasRemoved)
                    numberOfIteration = 1;
                else
                {
                    numberOfIteration++;
                }
            }

            Console.WriteLine($"After resolving collisions there is {particles.Count} particles left.");
        }

        protected override string GetStringDay()
        {
            return "Twenty";
        }

        #endregion

        #region Private Methods

        private List<Particle> GetParticles()
        {
            var particles = new List<Particle>();
            var index = 0;
            foreach (var line in AdventOfCodeHelper.FileReader("Inputs\\Input20.txt"))
            {
                var items = line.Split(new[] { '<', '>' }, StringSplitOptions.RemoveEmptyEntries);
                var p = new Particle
                {
                    Id = index++,
                    Position = GetVector(items[1]),
                    Velocity = GetVector(items[3]),
                    Acceleration = GetVector(items[5])
                };
                particles.Add(p);
            }

            return particles;
        }

        private Vector GetVector(string item)
        {
            var important = item.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            return new Vector
            {
                X = int.Parse(important[0].Trim()),
                Y = int.Parse(important[1].Trim()),
                Z = int.Parse(important[2].Trim())
            };
        }

        #endregion
    }
}
