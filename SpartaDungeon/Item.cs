using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    public enum ItemType { Weapon, Armor, supplies }

    public interface IItem
    {
        public void ItemUse();

        public Item ItemAdd(int Index);
    }

    internal static class Date
    {

        public static DataTable ItemDataTable = new DataTable();
        public static DataTable SuppliesDataTable = new DataTable();

        internal static void ItemDataTableSetting()
        {
            Action<DataTable, string, Type> addColumn = (table, columnName, columnType) =>
            {
                table.Columns.Add(columnName, columnType);
            };

            // 아이템 테이블 컬럼 생성 및 기본키 지정
            addColumn(ItemDataTable, "ItemIndex", typeof(int));
            addColumn(ItemDataTable, "Name", typeof(string));
            addColumn(ItemDataTable, "Explain", typeof(string));
            addColumn(ItemDataTable, "ItemType", typeof(int));
            addColumn(ItemDataTable, "ItemPrice", typeof(int));

            DataColumn[] ItemDataTableKey = new DataColumn[1];
            ItemDataTableKey[0] = ItemDataTable.Columns["ItemIndex"];
            ItemDataTable.PrimaryKey = ItemDataTableKey;

            // { Index, Name, Explain, ItemType, ItemPrice, EquipmentType, MaxHP, Speed, AD, DF }
            ItemDataTable.Rows.Add(new object[] { 0, "나무 칼", "나무로 만든 칼", 0, 20 });
            ItemDataTable.Rows.Add(new object[] { 1, "돌 칼", "돌로 만든 칼", 0, 20 });
            ItemDataTable.Rows.Add(new object[] { 2, "돌 칼", "돌로 만든 칼", 1, 20 });

            // 장비 아이템 스텟 테이블
            //addColumn(equipmentDataTable, "EquipmentType", typeof(int));
            //addColumn(equipmentDataTable, "MaxHP", typeof(int));
            //addColumn(equipmentDataTable, "Speed", typeof(int));
            //addColumn(equipmentDataTable, "AD", typeof(int));
            //addColumn(equipmentDataTable, "DF", typeof(int));
        }
    }

    public abstract class Item : IItem
    {
        public int ItemIndex { get; protected set; }
        public string Name { get; protected set; }
        public string Explain { get; protected set; }
        public int ItemType { get; protected set; }
        public int ItemPrice { get; protected set; }

        public abstract Item ItemAdd(int Index);

        public abstract void ItemUse();
    }

    public class Equipment : Item
    {
        int EquipmentType { get; }
        bool IsEquip { get; set; }
        int MaxHP { get; }
        int Speed { get; }
        int AD { get; }
        int DF { get; }

        public override Equipment? ItemAdd(int Index)
        {
            DataRow? itemdata = Date.ItemDataTable.Rows.Find(Index);

            ItemIndex = Convert.ToInt32(itemdata["ItemIndex"]);
            Name = itemdata["Name"].ToString();
            Explain = itemdata["Explain"].ToString();
            ItemType = Convert.ToInt32(itemdata["ItemType"]);
            ItemPrice = Convert.ToInt32(itemdata["ItemPrice"]);

            if (ItemType == 0)
            {
                return this;
            }
            return null;
        }

        public override void ItemUse()
        {

        }
    }

    public class Supplies : Item
    {
        int EquipmentType { get; }
        bool IsEquip { get; set; }
        int MaxHP { get; }
        int Speed { get; }
        int AD { get; }
        int DF { get; }

        public override Supplies? ItemAdd(int Index)
        {
            DataRow? itemdata = Date.ItemDataTable.Rows.Find(Index);

            ItemIndex = Convert.ToInt32(itemdata["ItemIndex"]);
            Name = itemdata["Name"].ToString();
            Explain = itemdata["Explain"].ToString();
            ItemType = Convert.ToInt32(itemdata["ItemType"]);
            ItemPrice = Convert.ToInt32(itemdata["ItemPrice"]);

            if (ItemType == 1)
            {
                return this;
            }
            return null;
        }

        public override void ItemUse()
        {

        }
    }
}

