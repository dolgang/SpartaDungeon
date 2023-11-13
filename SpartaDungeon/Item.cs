using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    public enum ItemType { Weapon, Armor, supplies }

    public class Item
    {
        public bool Equip { get; set; }
        public string Name { get; }
        public Enum Type { get; }
        public int Price { get; }
        public int Sellprice { get; }

        public int AtkBonus;
        public int DefBonus;

        public Item (string name, Enum type, int price, int sellprice, int atkbonus, int defbonus)
        {
            Name = name;
            Type = type;
            Price = price;
            Sellprice = sellprice;
            AtkBonus = atkbonus;
            DefBonus = defbonus;
        }

        public String IsEquip()
        {
            switch (Equip)
            {
                case false:
                    return "";
                case true:
                    return "[E]";
            }
        }

        public void EquipmentStatusInfo(out int AtkBonus, out int DefBonus)
        {
            AtkBonus = this.AtkBonus;
            DefBonus = this.DefBonus;
        }
    }
}
