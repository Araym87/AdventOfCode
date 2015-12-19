namespace AdventOfCode.SixteenthDay
{
    public class Aunt
    {
        #region Properties

        public readonly string Name;

        public int? Children { get; set; }
        public int? Cats { get; set; }
        public int? Samoyeds { get; set; }
        public int? Pomeranians { get; set; }
        public int? Akitas { get; set; }
        public int? Vizslas { get; set; }
        public int? Goldfish { get; set; }
        public int? Trees { get; set; }
        public int? Cars { get; set; }
        public int? Perfumes { get; set; }

        #endregion

        #region Constructor

        public Aunt(string name)
        {
            Name = name;
        }

        #endregion

        #region Public Methods

        public void SetValue(string item, int value)
        {
            if (item.Equals(nameof(Children).ToLowerInvariant()))
                Children = value;

            if (item.Equals(nameof(Cats).ToLowerInvariant()))
                Cats = value;

            if (item.Equals(nameof(Samoyeds).ToLowerInvariant()))
                Samoyeds = value;

            if (item.Equals(nameof(Pomeranians).ToLowerInvariant()))
                Pomeranians = value;

            if (item.Equals(nameof(Akitas).ToLowerInvariant()))
                Akitas = value;

            if (item.Equals(nameof(Vizslas).ToLowerInvariant()))
                Vizslas = value;

            if (item.Equals(nameof(Goldfish).ToLowerInvariant()))
                Goldfish = value;

            if (item.Equals(nameof(Trees).ToLowerInvariant()))
                Trees = value;

            if (item.Equals(nameof(Cars).ToLowerInvariant()))
                Cars = value;

            if (item.Equals(nameof(Perfumes).ToLowerInvariant()))
                Perfumes = value;
        }

        #endregion
    }

    public static class AuntExtension
    {
        public static bool IsEqualPartTwo(this Aunt aunt, Aunt sample)
        {
            if (aunt.Children.HasValue && !aunt.Children.Value.Equals(sample.Children))
                return false;

            if (aunt.Cats.HasValue && !(aunt.Cats.Value > sample.Cats))
                return false;

            if (aunt.Samoyeds.HasValue && !aunt.Samoyeds.Value.Equals(sample.Samoyeds))
                return false;

            if (aunt.Pomeranians.HasValue && !(aunt.Pomeranians.Value < sample.Pomeranians))
                return false;

            if (aunt.Akitas.HasValue && !aunt.Akitas.Value.Equals(sample.Akitas))
                return false;

            if (aunt.Vizslas.HasValue && !aunt.Vizslas.Value.Equals(sample.Vizslas))
                return false;

            if (aunt.Goldfish.HasValue && !(aunt.Goldfish.Value < sample.Goldfish))
                return false;

            if (aunt.Trees.HasValue && !(aunt.Trees.Value > sample.Trees))
                return false;

            if (aunt.Cars.HasValue && !aunt.Cars.Value.Equals(sample.Cars))
                return false;

            if (aunt.Perfumes.HasValue && !aunt.Perfumes.Value.Equals(sample.Perfumes))
                return false;

            return true;
        }

        public static bool IsEqualPartOne(this Aunt aunt, Aunt sample)
        {
            if (aunt.Children.HasValue && !aunt.Children.Value.Equals(sample.Children))
                return false;

            if (aunt.Cats.HasValue && !aunt.Cats.Value.Equals(sample.Cats))
                return false;

            if (aunt.Samoyeds.HasValue && !aunt.Samoyeds.Value.Equals(sample.Samoyeds))
                return false;

            if (aunt.Pomeranians.HasValue && !aunt.Pomeranians.Value.Equals(sample.Pomeranians))
                return false;

            if (aunt.Akitas.HasValue && !aunt.Akitas.Value.Equals(sample.Akitas))
                return false;

            if (aunt.Vizslas.HasValue && !aunt.Vizslas.Value.Equals(sample.Vizslas))
                return false;

            if (aunt.Goldfish.HasValue && !aunt.Goldfish.Value.Equals(sample.Goldfish))
                return false;

            if (aunt.Trees.HasValue && !aunt.Trees.Value.Equals(sample.Trees))
                return false;

            if (aunt.Cars.HasValue && !aunt.Cars.Value.Equals(sample.Cars))
                return false;

            if (aunt.Perfumes.HasValue && !aunt.Perfumes.Value.Equals(sample.Perfumes))
                return false;

            return true;
        }
    }

}
