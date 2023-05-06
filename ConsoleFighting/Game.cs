using System.Text;
using ConsoleFighting.Scenes;
using ConsoleFighting.Characters;

namespace ConsoleFighting
{
    internal class Game
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Console.WriteLine(Console.OutputEncoding);
            //Console.ReadKey(true);

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

        static bool Exit()
        {
            Environment.Exit(0);
            return true;
        }
    }
}