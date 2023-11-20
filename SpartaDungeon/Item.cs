using SpartaDungeon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    interface IItem
    {

        public void ItemUse(Warrior warrior);
    }

    public class Item : IItem
    {
        public bool Equip { get; set; }
        public string Name { get; }
        public Enum ItemType { get; }
        public int Price { get; }
        public int Sellprice { get; }

        public int AttackBonus;
        public int HitPointBonus;
        public int DefenceBonus;

        public Item (string name, Enum type, int price = 0, int sellprice = 0, int atkbonus = 0, int defbonus = 0)
        {
            Name = name;
            ItemType = type;
            Price = price;
            Sellprice = sellprice;
            AttackBonus = atkbonus;
            DefenceBonus = defbonus;
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

        public virtual void ItemUse(Warrior warrior) { }

        public void EquipmentStatusInfo(out int AttackBonus, out int DefenceBonus)
        {
            AttackBonus = this.AttackBonus;
            DefenceBonus = this.DefenceBonus;
        }
    }
}

public class Equipment : Item
{
    public Enum EquipmentType { get; }

    public Equipment(string name, Enum type, Enum equiptype, int price = 0, int sellprice = 0, int atkbonus = 0, int defbonus = 0) : base(name, type, price, sellprice, atkbonus, defbonus)
    {
        EquipmentType = equiptype;
    }
}