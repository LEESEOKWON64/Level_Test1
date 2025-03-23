namespace Store_Game
{
    internal class Program
    {
        /*1. 상점에서는 다음 작업들이 가능하다.
            A. 아이템 구매
            B. 아이템 판매
            C. 아이템 확인

          2. 아이템은 기본적으로 이름, 설명, 가격을 가지고 있으며, 
             무기는 공격력, 방어구는 방어력, 장신구는 체력을 상승시키는 수치를 가진다.

          3. 아이템 구매 메뉴 선택시 상점이 소유하고 있는 아이템들 목록이 제공되고, 
             구매하고자 하는 아이템을 선택시 구매를 진행한다. 
             단, 돈이 부족하다면 구매는 진행되지 않는다.
             구매가 완료되면 소유한 아이템에 구매한 아이템이 추가되며, 
             아이템에 의해 플레이어 능력이 상승한다.
          4. 아이템 판매 메뉴 선택시 플레이어가 소유하고 있는 아이템들 목록이 제공되고, 
             판매하고자 하는 아이템을 선택시 판매를 진행한다. 
             단, 소유한 아이템이 없다면 진행되지 않는다.
             판매가 완료되면 소유한 아이템에 판매한 아이템이 제거되며, 
             아이템에 의해 플레이어 능력이 하락한다.
          5. 아이템 확인 메뉴 선택시 플레이어가 소유하고 있는 아이템들 목록이 제공되고, 
             아이템들에 의해 상승한 플레이어 최종 능력치를 보여준다.
             플레이어는 최대 6개의 아이템을 소유할 수 있으며 빈칸은 보여주지 않는다.*/
        #region struct
        struct Item
        {
            public string name;
            public string detail;
            public int price;
            public ItemType type;
            public int value;
        }
        enum ItemType
        {
            weapon, shield, accessory
        }

        struct Inventory
        {
            List<Item> inventory;
        }
        #endregion
        #region Start
        static void Start(out Item longSword, out Item clothArmor, out Item tearOfGoddess)
        {            
            longSword.name = "롱소드";
            longSword.detail = "기본적인 검이다.";
            longSword.price = 450;
            longSword.type = ItemType.weapon;
            longSword.value = 15;

            clothArmor.name = "천갑옷";
            clothArmor.detail = "얇은 갑옷이다.";
            clothArmor.price = 450;
            clothArmor.type = ItemType.shield;
            clothArmor.value = 10;

            tearOfGoddess.name = "여신의 눈물";
            tearOfGoddess.detail = "희미하게 푸른빛을 품고 있는 보석이다.";
            tearOfGoddess.price = 800;
            tearOfGoddess.type = ItemType.accessory;
            tearOfGoddess.value = 300;


            // 아이템 정보 - 구조체 형식으로 표현
            // 메인 메뉴 타이틀 형식
            // 보유 골드 : 10000G
        }
        #endregion
        #region MainMethod
        static void Main(string[] args)
        {
            bool gameOver = false;

            int gold = 10000;
            int attack = 0;
            int defense = 0;
            int Health = 0;

            Item longSword = new Item();
            Item clothArmor = new Item();
            Item tearOfGoddess = new Item();

            Start(out longSword, out clothArmor, out tearOfGoddess);

            while (gameOver = false)
            {
                Render();
                Input();
                Update();
            }

            End();
        }
        #endregion
        #region Render
        static void Render()
        {
            MainMenu();       // 상점 메인 메뉴

            ItemBuyMenu();    // 아이템 구매 메뉴 
            ItemSellMenu();   // 아이템 판매 메뉴
            ItemConfigMenu(); // 아이템 확인 메뉴
        }
        #endregion
        #region MainMenu
        static void MainMenu()
        {
            // 아이템 구매, 판매, 확인 메뉴로 갈 수 있는 허브
            // 상점 메뉴 (1. 아이템 구매, 2. 아이템 판매, 3. 아이템 확인)
            // 메뉴를 선택하세요 : 
        }
        #endregion
        #region ItemBuyMenu
        static void ItemBuyMenu()
        {
            //보유한 골드 : 10000G
            //아이템 목록 : 1. 롱소드(attack), 2. 천갑옷(shield), 3. 여신의 눈물(accesory)
            //아이템 정보 : 가격, 설명, 상승 수치
            //구매할 아이템 선택해주세요.(취소 : 0) :
            //{}을 구매합니다.
            //플레이어의 공격력이 {}상승하여 {}이 됩니다.
            //보유한 골드가 {}G 감소하여 {]G가 됩니다.
        }
        #endregion
        #region ItemSellMenu
        static void ItemSellMenu()
        {
            //아이템 목록 : 1. 롱소드(attack), 2. 천갑옷(shield), 3. 여신의 눈물(accesory)
            //아이템 정보 : 가격, 설명, 하락 수치
            //판매할 아이템 선택해주세요.(취소 : 0) :
            //{}을 판매합니다.
            //플레이어의 공격력이 {}감소하여 {}이 됩니다.
            //보유한 골드가 {}G 상승하여 {]G가 됩니다.
        }
        #endregion
        #region ItemConfigMenu
        static void ItemConfigMenu()
        {
            //=======아이템 확인=======
            //플레이어 골드 보유량 : {}G
            //플레이어 공격력 상승량 : {}
            //플레이어 방어력 상승량 : {}
            //플레이어 체력 상승량 : {}
            //1. 여신의 눈물
            //2. 롱소드
            //인벤토리 기능
            //계속하려면 아무키나 입력하세요 : 
        }
        #endregion
        #region Input
        static void Input()
        {
            Console.ReadKey();  //0,1,2,3 으로 움직이는거면 굳이 리드키?
        }
        #endregion
        #region Update
        static void Update()
        {
            Gold();
            Value();
        }
        #endregion
        #region Gold
        static void Gold()
        {
            //아이템 샀을 때 감소
            //아이템 팔 때 감소
            //골드 보유량 ref 타입
        }
        #endregion
        #region Value
        static void Value()
        {
            //아이템에 따른 수치 증가량
            //attack
            //defense
            //Health
        }
        #endregion
        #region End
        static void End()
        {

        }
        #endregion
    }
}
