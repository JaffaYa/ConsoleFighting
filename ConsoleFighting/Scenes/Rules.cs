using System;

namespace ConsoleFighting.Scenes
{
    internal class Rules : Scene
    {
        internal enum RulesMenuItems
        {
            Game = 1,
            Stats,
            Back,
        }
        public delegate void RulesDelegate();
        //public event RulesDelegate RulesPage;

        //public Rules()
        //{
        //    RulesPage = new RulesDelegate(() => { });
        //}


        public override void Show()
        {
            do
            {
                Clear();
                Console.WriteLine("Правила гри:\n");
                ShowMenu();
            } while (!MakeChoise());

            //Console.ReadKey(true);
        }

        public void ShowMenu()
        {
            foreach (RulesMenuItems item in Enum.GetValues(typeof(RulesMenuItems)))
            {
                Console.WriteLine("{0}. {1}", (int)item, Translations.__(item));
            }
        }

        public bool MakeChoise()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            //int num = int.Parse(key.KeyChar.ToString());
            int num;
            if (int.TryParse(key.KeyChar.ToString(), out num))
            {
                switch (num)
                {
                    case (int)RulesMenuItems.Game:
                        ShowRulesPage(ShowGameRules);
                        return false;
                    case (int)RulesMenuItems.Stats:
                        ShowRulesPage(ShowStatsInfo);
                        return false;
                    case (int)RulesMenuItems.Back:
                        return true;
                    default:
                        return false;
                }
            }
            //Console.ReadKey(true);
            return false;
        }

        void ShowRulesPage(RulesDelegate RulesPage)
        {
            Clear();
            Console.WriteLine("Правила гри:\n");
            RulesPage();
            Console.ReadKey(true);
        }

        void ShowGameRules()
        {
            Console.WriteLine("Два гравці по черзі створюють собі персонажів.");
            Console.WriteLine("Вибирають клас та імя персонажа.");
            Console.WriteLine("Та роприділяють вільні пункти характеристик.");
            Console.WriteLine("Після чого начинається покроковий бій між персонажами.");

            Console.WriteLine("\nУправління здійснюється за допомогою цифрових клавіш 1-6.");

        }
        void ShowStatsInfo()
        {
            Console.WriteLine("STA - Stamina - витриваліть, живуцість. Від цеї характеристики залежить кількість HP персонажа та його DEFF");
            Console.WriteLine("STR - Strength - сила. Від цеї характеристики залежить сила фізичної атаки персонажа ATK");
            Console.WriteLine("SGI - Agility - спритність. Від цеї характеристики залежить здібність персонажа ухилятися(Dodge) від фізичної атаки");
            Console.WriteLine("DEX - Dexterity - проворність. Від цеї характеристики залежить точніть(Accuracy) та шанс критичної(CriticalChance) атаки");
            Console.WriteLine("CON- Сonsciousness - свідомість. Від цеї характеристики залежить кількість MP персонажа та його магічний опір(MagicalResist)");
            Console.WriteLine("INT- Intellect - інтелект. Від цеї характеристики залежить сила магічної атаки персонажа MATK");
        }


        public bool ShowRulles()
        {
            Show();
            return false;
        }
    }
}
