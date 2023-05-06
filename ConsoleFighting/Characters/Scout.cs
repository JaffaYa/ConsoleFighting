using System;


namespace ConsoleFighting.Characters
{
    internal class Scout : Character
    {
        public enum Weapons
        {
            bow = 65, // лук
            knif = 55, // ніж
            claws = 60, // кігті
            arbalest = 70, // арбалет
        }
        public Scout() : base() //тут можна переписати шо не оприділяти переменні по 2 раза
        {
            Stamina = 4;
            Strength = 1;
            Agility = 2;
            Dexterity = 3;
            Сonsciousness = 1;
            Intellect = 0;
            Type = CharacterProfesion.Scout;
        }
        public override void MakeAttak(Character enemy)
        {
            Weapons weapon = RandomEnumValue<Weapons>();

            int addCritChance;
            addCritChance = weapon == Weapons.knif ? 5 : weapon == Weapons.arbalest ? 4 : 0;

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
