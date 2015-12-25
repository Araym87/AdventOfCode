using System;

namespace AdventOfCode.Day22
{
    public class Spell : ICloneable
    {
        #region Properties

        public int ManaCost { get; set; }

        public int Damage { get; set; }

        public int HitPointsRestore { get; set; }

        public int ArmorIncrease { get; set; }

        public int ManaRestore { get; set; }

        public int Lasts { get; set; }

        public string Name { get; set; }

        #endregion

        #region ICloneable

        public object Clone()
        {
            var cloned = new Spell
            {
                ManaCost = ManaCost,
                ArmorIncrease = ArmorIncrease,
                Damage = Damage,
                HitPointsRestore = HitPointsRestore,
                Lasts = Lasts,
                ManaRestore = ManaRestore,
                Name = Name,
            };

            return cloned;
        }

        #endregion

        #region Overriden Methods

        public override string ToString()
        {
            return Name;
            
        }

        #endregion
    }
}
