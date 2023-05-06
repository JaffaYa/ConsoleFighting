using System;

namespace ConsoleFighting.Characters
{
    internal class Warrior : Character
    {
        public enum Weapons
        {
            spear = 45, // спис
            ax = 60, // сокира
            sword = 50, // меч
            spit = 55, // коса
            hammer = 40, // молот
        }
        public Warrior() : base() //тут можна переписати шо не оприділяти переменні по 2 раза
        {
            Stamina = 4;
            Strength = 3;
            Agility = 1;
            Dexterity = 2;
            Сonsciousness = 1;
            Intellect = 0;
            Type = CharacterProfesion.Warrior;
        }
        public override void MakeAttak(Character enemy)
        {
            Weapons weapon = RandomEnumValue<Weapons>();

            int addCritChance;
            addCritChance = weapon == Weapons.spit ? 5 : weapon == Weapons.ax ? 4 : 0;

            Attack attack = new Attack();

            attack.PhysicalAttack = CalculatePhisicalAttack((int)weapon);
            attack.Accuracy = Accuracy;
            attack.MagicalAttack = 0;
            attack.isCritical = isCritical(CriticalChance + addCritChance);

            Console.WriteLine("{0} {1} вирішив атакувати зброєю {2}.", Translations.__(Type), Name, Translations.__(weapon));
            //Console.WriteLine("І хоче нанести {0} шкоди.", attack.PhysicalAttack);
            //Console.WriteLine("Це кріт = {0}.", attack.isCritical);

            enemy.TakeAttak(attack);
        }

        
    }
}
