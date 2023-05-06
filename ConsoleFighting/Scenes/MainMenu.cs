using System;
using ConsoleFighting;
using ConsoleFighting.Interfaces;

namespace ConsoleFighting.Scenes
{
    internal class MainMenu : Scene, IMainMenu
    {
        internal enum MenuItems
        {
            StartGame = 1,
            Rules,
            Exit,
        }

        public delegate bool MenuChoiseDelegate();

        private MenuChoiseDelegate[] menuHooks;

        public MainMenu()
        {
            InitMenuHooks();
        }

        public override void Show()
        {
            do
            {
                Clear();
                ShowTitle();
                ShowMenu();
            } while (!MakeChoise());
            
        }
        public void ShowMenu()
        {
            foreach (MenuItems item in Enum.GetValues(typeof(MenuItems)))
            {
                Console.WriteLine("{0}. {1}",(int)item, Translations.__(item));
            }
        }

        private void ShowTitle()
        {
            Console.WriteLine(Translations.__("Console Fighting")+"\n");
        }

        public bool MakeChoise()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            //int num = int.Parse(key.KeyChar.ToString());
            int num;
            if(int.TryParse(key.KeyChar.ToString(),out num))
            {
                foreach (MenuItems item in Enum.GetValues(typeof(MenuItems)))
                {
                    if((int)item == num)
                    {
                        return DoMenuHook(item);
                    }
                }
            }
            //Console.ReadKey(true);
            return false;
        }

        public bool DoMenuHook(MenuItems item)
        {
            if(menuHooks[(int)item] != null) 
                return menuHooks[(int)item]();
            return false;
        }

        private void InitMenuHooks() {
            Array menuItems = Enum.GetValues(typeof(MenuItems));
            menuHooks = new MenuChoiseDelegate[menuItems.Length+1];
            foreach (MenuItems item in menuItems)
            {
                menuHooks[(int)item] = () => false;
            }
        }

        public void AddMenuHook(MenuItems item, MenuChoiseDelegate func)
        {
            menuHooks[(int)item] += func;
        }

    }
}
