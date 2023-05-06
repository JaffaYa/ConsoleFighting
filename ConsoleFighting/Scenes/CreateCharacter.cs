using System;
using ConsoleFighting.Interfaces;
using ConsoleFighting.Characters;


namespace ConsoleFighting.Scenes
{
    internal class CreateCharacter : Scene, ISetUpCharacter
    {
        private static string title; 

        public override void Show()
        {
            Clear();

            ShowTitle();
            Console.WriteLine("");
        }

        public Character Create(string title)
        {
            CreateCharacter.title = title;

            Character? character = null;
            
            do
            {
                Show();
                //вибір класа
                Console.WriteLine("Виберіть клас персонажа:\n");
                foreach (CharacterProfesion item in Enum.GetValues(typeof(CharacterProfesion)))
                {
                    Console.WriteLine("{0}. {1}", (int)item, Translations.__(item));
                }

                ConsoleKeyInfo key = Console.ReadKey(true);
                int num;
                if (int.TryParse(key.KeyChar.ToString(), out num))
                {
                    foreach (CharacterProfesion item in Enum.GetValues(typeof(CharacterProfesion)))
                    {
                        if ((int)item == num)
                        {
                            switch (item)
                            {
                                case CharacterProfesion.Warrior:
                                    character = new Warrior();
                                    break;
                                case CharacterProfesion.Scout:
                                    character = new Scout();
                                    break;
                                case CharacterProfesion.Mage:
                                    character = new Mage();
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            } while (character == null);

            //вибор імені
            Show();
            Console.WriteLine("Введіть імя персонажа:");
            character.Name = Console.ReadLine();

            //return character;
            return SetUpCharacter(character);
        }

        public Character SetUpCharacter(Character character)
        {
            // прокачка лвлів
            while (character.UnsetPoints > 0)
            {
                Show();
                Console.WriteLine("Розприділіть вільні очки характеристик:\n");
                character.ShowInfo();

                Console.WriteLine("\nНе розподілених очків характеристик {0}", character.UnsetPoints);

                ConsoleKeyInfo key = Console.ReadKey(true);
                int num;
                if (int.TryParse(key.KeyChar.ToString(), out num))
                {
                    switch (num)
                    {
                        case 1:
                            character.Stamina += 1;
                            character.UnsetPoints--;
                            break;
                        case 2:
                            character.Strength += 1;
                            character.UnsetPoints--;
                            break;
                        case 3:
                            character.Agility += 1;
                            character.UnsetPoints--;
                            break;
                        case 4:
                            character.Dexterity += 1;
                            character.UnsetPoints--;
                            break;
                        case 5:
                            character.Сonsciousness += 1;
                            character.UnsetPoints--;
                            break;
                        case 6:
                            character.Intellect += 1;
                            character.UnsetPoints--;
                            break;
                        default:
                            break;
                    }
                }
            }
            return character;
        }

        static void ShowTitle()
        {
            Console.WriteLine("{0} строює персонажа", title);
        }
    }
}
