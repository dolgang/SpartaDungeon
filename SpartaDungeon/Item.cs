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

        public int Atk;

        public Item (string name, Enum type, int price, int sellprice)
        {
            Name = name;
            Type = type;
            Price = price;
            Sellprice = sellprice;
        }

        public String IsEquip()
        {
            switch (Equip)
            {
                case false:
                    return "";
                    break;
                case true:
                    return "[E]";
                    break;
            }
        }
    }
}
