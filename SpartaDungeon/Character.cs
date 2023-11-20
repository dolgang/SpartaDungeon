using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    public interface ICharacter
    {
        public void TakeDamage(int Damage);
    }


    public class Character : ICharacter
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Attack { get; private set; }
        public int AtkBonus;
        public int Defence { get; private set; }
        public int DefBonus;
        public int HitPoint { get; }
        public int CurrentHitPoint;
        public int Gold { get; }

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Attack = atk;
            Defence = def;
            HitPoint = hp;
            Gold = gold;
            CurrentHitPoint = HitPoint;
        }

        
        public void AddStatusData(int AtkBonus, int DefBonus)
        {
            Attack += AtkBonus;
            Defence += DefBonus;
            this.AtkBonus += AtkBonus;
            this.DefBonus += DefBonus;
        }

        public String AddStatusInfo(Status status)
        {
            switch (status)
            {
                case Status.Attack:
                    if (AtkBonus > 0)
                    {
                        return $"(+{AtkBonus})";
                    }
                    break;
                case Status.Defence:
                    if (DefBonus > 0)
                    {
                        return $"(+{DefBonus})";
                    }
                    break;
            }
            return "";
        }

        public void TakeDamage(int Damage)
        {
            CurrentHitPoint -= Damage;
        }

    }

    public class Warrior : Character
    {
        private List<Item> inventory;
        private Item[] equipmentslot = new Item[5];

        public Warrior(string name, string job, int level, int atk, int def, int hp, int gold) : base(name, job, level, atk, def, hp ,gold)
        {
            inventory = new List<Item>();
        }

        public int InventoryCountCheck() { return inventory.Count; }
        public List<Item> Inventory { get { return inventory; } }

        public void GetItem(Item getItem)
        {
            inventory.Add(getItem);
        }
    }

    public class Monster : Character
    {
        public Monster(string name, string job, int level, int atk, int def, int hp, int gold) : base(name, job, level, atk, def, hp, gold)
        {
            
        }
    }
}
