using System;
using ConsoleFighting.Scenes;
using ConsoleFighting.Characters;

namespace ConsoleFighting
{
    internal static class Translations
    {
        public static string __(string str)
        {
            switch (str)
            {
                case "Console Fighting":
                    return "Консольні Бої";
                default:
                    return str;
            }
        }
        public static string __(MainMenu.MenuItems item)
        {
            switch (item)
            {
                case MainMenu.MenuItems.StartGame:
                    return "Початок ігри";
                case MainMenu.MenuItems.Rules:
                    return "Правила";
                case MainMenu.MenuItems.Exit:
                    return "Вихід";
                default:
                    return item.ToString();
            }
        }
        public static string __(Rules.RulesMenuItems item)
        {
            switch (item)
            {
                case Rules.RulesMenuItems.Game:
                    return "Ігровий процес";
                case Rules.RulesMenuItems.Stats:
                    return "Характеристики";
                case Rules.RulesMenuItems.Back:
                    return "Назад";
                default:
                    return item.ToString();
            }
        }
        public static string __(CharacterProfesion item)
        {
            switch (item)
            {
                case CharacterProfesion.Warrior:
                    return "Воїн";
                case CharacterProfesion.Scout:
                    return "Спритник";
                case CharacterProfesion.Mage:
                    return "Маг";
                default:
                    return item.ToString();
            }
        }
        public static string __(Warrior.Weapons item)
        {
            switch (item)
            {
                case Warrior.Weapons.spear:
                    return "спис";
                case Warrior.Weapons.ax:
                    return "сокира";
                case Warrior.Weapons.sword:
                    return "меч";
                case Warrior.Weapons.spit:
                    return "коса";
                case Warrior.Weapons.hammer:
                    return "молот";
                default:
                    return item.ToString();
            }
        }
        public static string __(Scout.Weapons item)
        {
            switch (item)
            {
                case Scout.Weapons.bow:
                    return "лук";
                case Scout.Weapons.knif:
                    return "ніж";
                case Scout.Weapons.claws:
                    return "кігті";
                case Scout.Weapons.arbalest:
                    return "арбалет";
                default:
                    return item.ToString();
            }
        }
        public static string __(Mage.Skills skill)
        {
            switch (skill)
            {
                case Mage.Skills.fireBall:
                    return "вогняна куля";
                case Mage.Skills.iceArrow:
                    return "крижана стріла";
                case Mage.Skills.lightningBall:
                    return "шарова блискавиця";
                case Mage.Skills.deepFreeze:
                    return "глибока заморозка";
                case Mage.Skills.meteorShower:
                    return "метеоритний душ";
                case Mage.Skills.thunderstorm:
                    return "гроза";
                default:
                    return skill.ToString();
            }
        }
    }
}
