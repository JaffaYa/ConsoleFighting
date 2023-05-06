using System;
using System.Text;
using System.Diagnostics;
using ConsoleFighting.Scenes;
using ConsoleFighting.Characters;

namespace ConsoleFighting
{
    internal class Game
    {
        static void Main(string[] args)
        {
            //Debug.WriteLine("llala");
            //Console.ReadKey(true);
            SetEcoding();

            MainMenu menuScene = Init();
            menuScene.Show();


        }

        static MainMenu Init()
        {
            MainMenu menuScene = new MainMenu();
            Rules rulesScene = new Rules();

            //initialize menu scene
            menuScene.AddMenuHook(MainMenu.MenuItems.StartGame, StartGame );
            menuScene.AddMenuHook(MainMenu.MenuItems.Rules,rulesScene.ShowRulles);
            menuScene.AddMenuHook(MainMenu.MenuItems.Exit, Exit);

            //initialize rules scene
            //rulesScene.ExitFromRules += menuScene.Show;

            return menuScene;
        }

        static bool StartGame()
        {
            //підготовка персонажів
            CreateCharacter createScene = new CreateCharacter();
            Character player1 = createScene.Create("Гравець 1");
            Character player2 = createScene.Create("Гравець 2");

            //сам файт
            while (player1.HealthPoints > 0 && player2.HealthPoints > 0)
            {
                Console.Clear();
                Console.WriteLine("Бій:\n");
                player1.MakeAttak(player2);
                Console.WriteLine();
                player2.MakeAttak(player1);
                Console.WriteLine();
                player1.ShowShortInfo();
                Console.WriteLine();
                player2.ShowShortInfo();
                Console.ReadKey(true);
            }


            return false;
        }

        static void SetEcoding()
        {
            // check if UTF-8 is supported
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding utf8 = Encoding.GetEncoding("UTF-8");
            Encoding defaultEncoding = Encoding.GetEncoding(1251);
            Encoding consoleEncoding = Console.OutputEncoding;

            if (consoleEncoding == utf8)
            {
                //Debug.WriteLine("llala");
                //Console.WriteLine("UTF-8 is supported.");
            }
            else
            {
                Console.OutputEncoding = defaultEncoding;
                //Console.WriteLine("UTF-8 is not supported. Switching to 1251.");
            }
        }

        static bool Exit()
        {
            Environment.Exit(0);
            return true;
        }
    }
}