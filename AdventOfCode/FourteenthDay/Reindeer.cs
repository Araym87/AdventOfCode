namespace AdventOfCode.FourteenthDay
{
    public class Reindeer
    {
        public string Name { get; set; }

        public int Speed { get; set; }

        public int RideTime { get; set; }

        public int RelaxTime { get; set; }

        public int Distance { get; set; }

        public int Points { get; set; }

        public void RideOrRelax(int seconds)
        {
            var time = seconds % (RideTime + RelaxTime);

            if (time <= RideTime && time != 0)
                Distance += Speed;
        }
    }
}
