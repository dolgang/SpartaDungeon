using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
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

        public int InventoryCountCheck () { return inventory.Count; }
        public List<Item> Inventory { get { return inventory; } }
    }
}
