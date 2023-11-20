﻿using System.ComponentModel;
using System.Numerics;

namespace SpartaDungeon
{
    internal class Program
    {
        public static GameManager GameManager = new GameManager();

        static void Main(string[] args)
        {
            GameManager.GameDataSetting();
            GameManager.DisplayGameIntro();
        }
    }
    
    public class GameManager
    {
        public static Warrior player;

        public void GameDataSetting()
        {
            // 캐릭터 정보 세팅

            player = new Warrior("Chad", "전사", 1, 10, 5, 100, 1500);

            // 아이템 정보 세팅
            Equipment sword = new Equipment("철 검", ItemType.Equipment, EquipmentType.Weapon, 100, 20, 3);
            Equipment armor = new Equipment("가죽 갑옷", ItemType.Equipment, EquipmentType.Armor, 150, 30, 0, 2);
            player.GetItem(sword);
            player.GetItem(armor);
        }

        public void DisplayGameIntro()
        {
            Console.Clear();

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int input = CheckValidInput(1, 2);
            switch (input)
            {
                case 1:
                    DisplayMyInfo();
                    break;

                case 2:
                    // 작업해보기
                    DisplayInventory();
                    break;
            }
        }

        public void DisplayMyInfo()
        {
            Console.Clear();

            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보를 표시합니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Level}");
            Console.WriteLine($"{player.Name}({player.Job})");
            Console.WriteLine($"공격력 :{player.Attack} {player.AddStatusInfo(Status.Attack)}");
            Console.WriteLine($"방어력 : {player.Defence} {player.AddStatusInfo(Status.Defence)}");
            Console.WriteLine($"체력 : {player.HitPoint}");
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }

        public void DisplayInventory()
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 확인 할 수 있습니다.");
            Console.WriteLine("");

            for (int i = 0; i < player.InventoryCountCheck(); i++)
            {
                Item currentItem = player.Inventory[i];

                Console.WriteLine($"- {currentItem.IsEquip()} {currentItem.Name}");
            }

            Console.WriteLine("");
            Console.WriteLine("1. 장착관리");
            Console.WriteLine("0. 나가기");

            int input = CheckValidInput(0, 1);
            switch (input)
            {
                case 1:
                    DisplayEquipControl();
                    break;

                case 0:
                    DisplayGameIntro();
                    break;
            }
        }

        public void DisplayEquipControl()
        {
            Console.Clear();
            Console.WriteLine("장착관리");
            Console.WriteLine("아이템의 숫자를 입력하면 장비를 장착 및 해제할 수 있습니다.");
            Console.WriteLine("");

            for (int i = 0; i < player.InventoryCountCheck(); i++)
            {
                Item currentItem = player.Inventory[i];

                Console.WriteLine($"- {i + 1}. {currentItem.IsEquip()} {currentItem.Name}");
            }

            Console.WriteLine("");
            Console.WriteLine("0. 나가기");

            int input = CheckValidInput(0, player.InventoryCountCheck());
            if (input == 0)
            {
                DisplayInventory();
            }
            else
            {
                EquipmentSet(input);
                DisplayEquipControl();
            }
            
        }

        public void EquipmentSet(int input)
        {
            Item currentItem = player.Inventory[input - 1];
            currentItem.Equip = !currentItem.Equip;
            if (currentItem.Equip)
            {
                currentItem.EquipmentStatusInfo(out int AtkBonus, out int DefBonus);
                player.AddStatusData(AtkBonus, DefBonus);
            }
            else
            {
                currentItem.EquipmentStatusInfo(out int AtkBonus, out int DefBonus);
                player.AddStatusData(AtkBonus *= -1, DefBonus * -1);
            }
        }


        public int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }
}
