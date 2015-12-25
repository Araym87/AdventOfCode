using System.Collections.Generic;

namespace AdventOfCode.Day22
{
    public class HeroMagic
    {
        #region Fields

        private readonly int baseHitPoints;
        private readonly int baseManaPoints;

        #endregion

        #region Properties

        public int HitPoints { get; set; }

        public int ManaPoints { get; set; }

        public string Name { get; set; }

        public List<ActiveSpell> ActiveSpells { get; set; }

        public bool IsDead => HitPoints <= 0;

        public int Armor
        {
            get
            {
                var armorIncrease = 0; 
                ActiveSpells.ForEach(i => armorIncrease += i.Spell.ArmorIncrease);

                return armorIncrease;
            }
        }

        public int Damage { get; }

        #endregion

        #region Constructor

        public HeroMagic(int baseDamage, int baseHitPoints, int baseManaPoints)
        {
            Damage = baseDamage;
            this.baseHitPoints = baseHitPoints;
            this.baseManaPoints = baseManaPoints;
            
        }

        #endregion

        #region Public Methods

        public void ResetBaseStats()
        {
            HitPoints = baseHitPoints;
            ManaPoints = baseManaPoints;
            ActiveSpells = new List<ActiveSpell>();
        }

        public void ProcessSpells()
        {
            var spellToRemove = new List<ActiveSpell>();
            foreach (var activeSpell in ActiveSpells)
            {
                HitPoints -= activeSpell.Spell.Damage;
                HitPoints += activeSpell.Spell.HitPointsRestore;
                ManaPoints += activeSpell.Spell.ManaRestore;

                activeSpell.Lasts--;
                if(activeSpell.Lasts <= 0)
                    spellToRemove.Add(activeSpell);
            }

            spellToRemove.ForEach(i => ActiveSpells.Remove(i));


        }

        public void SpellCasted(Spell spell)
        {
            ActiveSpells.Add(new ActiveSpell
            {
                Lasts = spell.Lasts,
                Spell = (Spell)spell.Clone(),
            });
        }

        #endregion
    }
}
