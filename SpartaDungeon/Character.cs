using System;
using System.Collections.Generic;
using System.Data;
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
        List<Item> inventory;

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

        public void GetItem(int Index)
        {
            DataRow? itemdata = Date.ItemDataTable.Rows.Find(Index);
            int itemType = Convert.ToInt32(itemdata["ItemType"]);
            switch (itemType)
            {
                case 0:
                    Equipment newEquipment = new Equipment();
                    Equipment addEquipment = newEquipment.ItemAdd(Index);
                    if (addEquipment != null) { inventory.Add(addEquipment); }
                    break;
                case 1:
                    Supplies newSupplies = new Supplies();
                    Supplies addSupplies = newSupplies.ItemAdd(Index);
                    if (addSupplies != null) { inventory.Add(addSupplies); }
                    break;
                default: 
                    break;
            }
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
