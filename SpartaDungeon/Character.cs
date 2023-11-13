using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    public enum Status { Atk, Def, Hp }


    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; private set; }
        public int AtkBonus;
        public int Def { get; private set; }
        public int DefBonus;
        public int Hp { get; }
        public int Gold { get; }
        private List<Item> inventory;

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
            inventory = new List<Item>();
        }

        public void GetItem(Item getItem)
        {
            inventory.Add(getItem);
        }
        
        public void AddStatusData(int AtkBonus, int DefBonus)
        {
            Atk += AtkBonus;
            Def += DefBonus;
            this.AtkBonus += AtkBonus;
            this.DefBonus += DefBonus;
        }

        public String AddStatusInfo(Status status)
        {
            switch (status)
            {
                case Status.Atk:
                    if (AtkBonus > 0)
                    {
                        return $"(+{AtkBonus})";
                    }
                    break;
                case Status.Def:
                    if (DefBonus > 0)
                    {
                        return $"(+{DefBonus})";
                    }
                    break;
            }
            return "";
        }


        public int InventoryCountCheck () { return inventory.Count; }
        public List<Item> Inventory { get { return inventory; } }
    }
}
