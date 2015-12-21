using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day21
{
    public class Hero
    {
        private readonly int baseArmor;
        private readonly int baseDamage;
        private readonly int baseHitPoints;

        public int HitPoints { get; private set; }

        public string Name { get; set; }

        public List<Item> Equip { get; set; }

        public int Damage
        {
            get
            {
                var dmg = baseDamage;
                Equip.ForEach(i => dmg += i.Damage);
                return dmg;
            }
        }

        public int Armor
        {
            get
            {
                var arm = baseArmor;
                Equip.ForEach(i => arm += i.Armor);
                return arm;
            }
        }

        public int TotalCost
        {
            get
            {
                var cost = 0;
                Equip.ForEach(i => cost += i.Cost);
                return cost;
            }
        }

        public bool IsDead => HitPoints <= 0;

        public Hero(int baseArmor, int baseDamage, int baseHitPoints)
        {
            this.baseArmor = baseArmor;
            this.baseDamage = baseDamage;
            this.baseHitPoints = baseHitPoints;
            Equip = new List<Item>();
        }

        public void ResteHitPoints()
        {
            HitPoints = baseHitPoints;
        }

        public void Defense(int attack)
        {
            attack = attack - Armor;
            HitPoints -= attack <= 0 ? 1 : attack;
        }
    }
}
