﻿namespace Store_Game
{
    internal class Program
    {
        #region struct
        struct Item
        {
            public string name;
            public string detail;
            public int price;
            public int value;
            public ItemEnforce enfo;
        }
        enum ItemEnforce
        {
            공격력, 방어력, 체력
        }
        #endregion
        #region Start
        static void Start(out Item longSword, out Item clothArmor, out Item tearOfGoddess)
        {
            longSword.name = "롱소드";
            longSword.detail = "기본적인 검이다.";
            longSword.price = 450;
            longSword.value = 15;
            longSword.enfo = ItemEnforce.공격력;

            clothArmor.name = "천갑옷";
            clothArmor.detail = "얇은 갑옷이다.";
            clothArmor.price = 450;
            clothArmor.value = 10;
            clothArmor.enfo = ItemEnforce.방어력;

            tearOfGoddess.name = "여신의 눈물";
            tearOfGoddess.detail = "희미하게 푸른빛을 품고 있는 보석이다.";
            tearOfGoddess.price = 800;
            tearOfGoddess.value = 300;
            tearOfGoddess.enfo = ItemEnforce.체력;
        }
        #endregion
        #region MainMethod
        static void Main(string[] args)
        {
            bool gameOver = false;

            int gold = 10000;
            int attack = 0;
            int defense = 0;
            int health = 0;
            List<Item> inventory = new List<Item>();

            Item longSword = new Item();
            Item clothArmor = new Item();
            Item tearOfGoddess = new Item();

            Start(out longSword, out clothArmor, out tearOfGoddess);

            Render(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
        }
        #endregion
        #region Render
        static void Render(ref int gold, Item longSword, Item clothArmor, Item tearOfGoddess, ref int attack, ref int defense, ref int health, ref List<Item> inventory)
        {
            MainMenu(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);        
        }
        #endregion
        #region MainMenu
        static void MainMenu(ref int gold, Item longSword, Item clothArmor, Item tearOfGoddess, ref int attack, ref int defense, ref int health, ref List<Item> inventory)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("************************************");
            Console.WriteLine("*********** 아이템 상점 ************");
            Console.WriteLine("************************************\n\n");
            Console.WriteLine("========== 상점 메뉴 ==========");
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("3. 아이템 확인");
            Console.Write("메뉴를 선택하세요 : ");

            MainInput(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
        }
        #endregion
        #region ItemBuyMenu
        static void ItemBuyMenu(ref int gold, Item longSword, Item clothArmor, Item tearOfGoddess, ref int attack, ref int defense, ref int health, ref List<Item> inventory)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("========= 아이템 구매 =========");
            Console.WriteLine($"보유한 골드 : {gold}G\n");
            Console.WriteLine($"1. {longSword.name}\n   가격 : {longSword.price}\n   설명 : {longSword.detail}\n   {longSword.enfo} 상승 : {longSword.value}\n");
            Console.WriteLine($"2. {clothArmor.name}\n   가격 : {clothArmor.price}\n   설명 : {clothArmor.detail}\n   {clothArmor.enfo} 상승 : {clothArmor.value}\n");
            Console.WriteLine($"3. {tearOfGoddess.name}\n   가격 : {tearOfGoddess.price}\n   설명 : {tearOfGoddess.detail}\n   {tearOfGoddess.enfo} 상승 : {tearOfGoddess.value}\n");

            BuyMenuInput(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
        }
        #endregion
        #region ItemSellMenu
        static void ItemSellMenu(ref int gold, Item longSword, Item clothArmor, Item tearOfGoddess, ref int attack, ref int defense, ref int health, ref List<Item> inventory)
        {
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            Console.WriteLine("========= 아이템 판매 =========");
            Console.WriteLine("");
            if (inventory == null || inventory.Count == 0)
            {
                Console.Write("보유하신 아이템이 없습니다. (돌아가기 0)");
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D0:
                        Render(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                        break;
                    default:
                        ItemSellMenu(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                        break;
                }
            }
            else
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {inventory[i].name}\n   가격 : {inventory[i].price}\n   설명 : {inventory[i].detail}\n   {inventory[i].enfo} 상승 : {inventory[i].value}\n");
                }
            }
            SellMenuInput(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
        }
        #endregion
        #region ItemConfigMenu
        static void ItemConfigMenu(ref int gold, Item longSword, Item clothArmor, Item tearOfGoddess, ref int attack, ref int defense, ref int health, ref List<Item> inventory)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("========= 아이템 확인 =========");
            Console.WriteLine($"플레이어 골드\t보유량 : {gold}G");
            Console.WriteLine($"플레이어 공격력\t상승량 : {attack}");
            Console.WriteLine($"플레이어 방어력\t상승량 : {defense}");
            Console.WriteLine($"플레이어 체력\t상승량 : {health}");
            Console.WriteLine("===============================\n");

            if (inventory != null)
            {
                for (int i = 0; i < 6; i++)
                {

                    if (i < inventory.Count)
                    {
                        Console.WriteLine($"{i + 1}. {inventory[i].name}\n   가격 : {inventory[i].price}\n   설명 : {inventory[i].detail}\n   {inventory[i].enfo} 상승 : {inventory[i].value}\n");
                    }
                    else
                    {
                        break;
                    }
                }
                Console.Write("계속하려면 아무키나 입력하세요 : ");
            }
            else
            {
                Console.Write("보유하신 아이템이 없습니다.\n\n계속하려면 아무키나 입력하세요 : ");
            }
            
            ConfigMenuInput(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
        }
        #endregion
        #region MainInput
        static void MainInput(ref int gold, Item longSword, Item clothArmor, Item tearOfGoddess, ref int attack, ref int defense, ref int health, ref List<Item> inventory)
        {
            string key = Console.ReadLine();

            switch (key)
            {
                case "1":
                    ItemBuyMenu(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                    break;
                case "2":
                    ItemSellMenu(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                    break;
                case "3":
                    ItemConfigMenu(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                    break;
                case "0":
                    Render(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                    break;
                default:
                    MainMenu(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                    break;
            }
        }
        #endregion
        #region BuyMenuInput
        static void BuyMenuInput(ref int gold, Item longSword, Item clothArmor, Item tearOfGoddess, ref int attack, ref int defense, ref int health, ref List<Item> inventory)
        {
            Console.Write("구매할 아이템을 선택하세요 (취소 0) : ");
            ConsoleKey key = Console.ReadKey().Key;
            Console.WriteLine("\n");

            switch (key)
            {
                case ConsoleKey.D1:
                    if (inventory.Count < 5)
                    {
                        Console.WriteLine($"{longSword.name}를 구매합니다.");
                        Console.WriteLine($"플레이어의 {longSword.enfo}이 {longSword.value} 상승하여 {attack += longSword.value}이(가) 됩니다.");
                        Console.WriteLine($"보유한 골드가 {longSword.price} 감소하여 {gold -= longSword.price}G가 됩니다.\n");
                        inventory.Add(longSword);
                        Console.Write("계속하려면 아무키나 입력하세요 (돌아가기 0) : ");
                        ConsoleKey key1 = Console.ReadKey().Key;
                        switch (key1)
                        {
                            case ConsoleKey.D0:
                                Render(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                                break;
                            default:
                                ItemBuyMenu(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                                break;
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("인벤토리가 가득 차 더 이상 구매할 수 없습니다.");
                        Console.Write("계속하려면 아무키나 입력하세요 (돌아가기 0) : ");
                        ConsoleKey key2 = Console.ReadKey().Key;
                        switch (key2)
                        {
                            case ConsoleKey.D0:
                                Render(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                                break;
                            default:
                                ItemBuyMenu(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                                break;
                        }
                    }
                    break;
                case ConsoleKey.D2:
                    if (inventory.Count < 5)
                    {
                        Console.WriteLine($"{clothArmor.name}를 구매합니다.");
                        Console.WriteLine($"플레이어의 {clothArmor.enfo}이 {clothArmor.value} 상승하여 {defense += clothArmor.value}이 됩니다.");
                        Console.WriteLine($"보유한 골드가 {clothArmor.price} 감소하여 {gold -= clothArmor.price}G가 됩니다.\n");
                        inventory.Add(clothArmor);
                        Console.Write("계속하려면 아무키나 입력하세요 (돌아가기 0) : ");
                        ConsoleKey key3 = Console.ReadKey().Key;
                        switch (key3)
                        {
                            case ConsoleKey.D0:
                                Render(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                                break;
                            default:
                                ItemBuyMenu(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("인벤토리가 가득 차 더 이상 구매할 수 없습니다.");
                        Console.Write("계속하려면 아무키나 입력하세요 (돌아가기 0) : ");
                        ConsoleKey key4 = Console.ReadKey().Key;
                        switch (key4)
                        {
                            case ConsoleKey.D0:
                                Render(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                                break;
                            default:
                                ItemBuyMenu(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                                break;
                        }
                    }
                    break;
                case ConsoleKey.D3:
                    if (inventory.Count < 5)
                    {
                        Console.WriteLine($"{tearOfGoddess.name}를 구매합니다.");
                        Console.WriteLine($"플레이어의 {tearOfGoddess.enfo}이 {tearOfGoddess.value} 상승하여 {health += tearOfGoddess.value}이 됩니다.");
                        Console.WriteLine($"보유한 골드가 {tearOfGoddess.price} 감소하여 {gold -= tearOfGoddess.price}G가 됩니다.\n");
                        inventory.Add(tearOfGoddess);
                        Console.Write("계속하려면 아무키나 입력하세요 (돌아가기 0) : ");
                        ConsoleKey key5 = Console.ReadKey().Key;
                        switch (key5)
                        {
                            case ConsoleKey.D0:
                                Render(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                                break;
                            default:
                                ItemBuyMenu(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("인벤토리가 가득 차 더 이상 구매할 수 없습니다.");
                        Console.Write("계속하려면 아무키나 입력하세요 (돌아가기 0) : ");
                        ConsoleKey key6 = Console.ReadKey().Key;
                        switch (key6)
                        {
                            case ConsoleKey.D0:
                                Render(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                                break;
                            default:
                                ItemBuyMenu(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                                break;
                        }
                    }
                    break;
                case ConsoleKey.D0:
                    Render(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                    break;
                default:
                    ItemBuyMenu(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                    break;
            }
        }
        #endregion
        #region SellMenuInput
        static void SellMenuInput(ref int gold, Item longSword, Item clothArmor, Item tearOfGoddess, ref int attack, ref int defense, ref int health, ref List<Item> inventory)
        {
            Console.Write("판매할 아이템을 선택하세요 (취소 0) : ");
            string key = Console.ReadLine();
            Console.WriteLine("");

            if (int.Parse(key) > 0 && int.Parse(key) <= inventory.Count)
            {
                for (int i = 1; i <= inventory.Count; i++)
                {
                    if (int.Parse(key) == i)
                    {
                        if (inventory[i - 1].Equals(longSword))
                        {
                            Console.WriteLine($"{inventory[i - 1].name}를 판매합니다.");
                            Console.WriteLine($"플레이어의 {inventory[i - 1].enfo}이 {inventory[i - 1].value} 감소하여 {attack -= inventory[i - 1].value}이(가) 됩니다.");
                            Console.WriteLine($"보유한 골드가 {inventory[i - 1].price} 증가하여 {gold += inventory[i - 1].price}G가 됩니다.\n");
                            inventory.Remove(inventory[i - 1]);
                            Console.Write("계속하려면 아무키나 입력하세요 (돌아가기 0) : ");
                            ConsoleKey key1 = Console.ReadKey().Key;
                            switch (key1)
                            {
                                case ConsoleKey.D0:
                                    Render(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                                    break;
                                default:
                                    ItemSellMenu(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                                    break;
                            }
                        }
                        else if (inventory[i - 1].Equals(clothArmor))
                        {
                            Console.WriteLine($"{inventory[i - 1].name}를 판매합니다.");
                            Console.WriteLine($"플레이어의 {inventory[i - 1].enfo}이 {inventory[i - 1].value} 감소하여 {defense -= inventory[i - 1].value}이(가) 됩니다.");
                            Console.WriteLine($"보유한 골드가 {inventory[i - 1].price} 증가하여 {gold += inventory[i - 1].price}G가 됩니다.\n");
                            inventory.Remove(inventory[i - 1]);
                            Console.Write("계속하려면 아무키나 입력하세요 (돌아가기 0) : ");
                            ConsoleKey key2 = Console.ReadKey().Key;
                            switch (key2)
                            {
                                case ConsoleKey.D0:
                                    Render(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                                    break;
                                default:
                                    ItemSellMenu(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                                    break;
                            }
                        }
                        else if (inventory[i - 1].Equals(tearOfGoddess))
                        {
                            Console.WriteLine($"{inventory[i - 1].name}를 판매합니다.");
                            Console.WriteLine($"플레이어의 {inventory[i - 1].enfo}이 {inventory[i - 1].value} 감소하여 {health -= inventory[i - 1].value}이(가) 됩니다.");
                            Console.WriteLine($"보유한 골드가 {inventory[i - 1].price} 증가하여 {gold += inventory[i - 1].price}G가 됩니다.\n");
                            inventory.Remove(inventory[i - 1]);
                            Console.Write("계속하려면 아무키나 입력하세요 (돌아가기 0) : ");
                            ConsoleKey key3 = Console.ReadKey().Key;
                            switch (key3)
                            {
                                case ConsoleKey.D0:
                                    Render(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                                    break;
                                default:
                                    ItemSellMenu(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                                    break;
                            }
                        }
                    }
                }
            }
            else if (key == "0")
            {
                Render(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
            }
            else
            {
                ItemSellMenu(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
            }
        }
        #endregion
        #region ConfigMenuInput
        static void ConfigMenuInput(ref int gold, Item longSword, Item clothArmor, Item tearOfGoddess, ref int attack, ref int defense, ref int health, ref List<Item> inventory)
        {
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey D0:
                    Render(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                    break;
                default:
                    Render(ref gold, longSword, clothArmor, tearOfGoddess, ref attack, ref defense, ref health, ref inventory);
                    break;
            }
        }
        #endregion
    }
}