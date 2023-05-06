using System;


namespace ConsoleFighting.Characters
{
    internal class Mage : Character
    {
        public enum Skills
        {
            fireBall = 65, // вогняна куля
            iceArrow = 75, // крижана стріла
            lightningBall = 70, // шарова блискавиця
            deepFreeze = 90, // глибока заморозка
            meteorShower = 80, // метеоритний душ
            thunderstorm = 100, // гроза
        }
        public Mage() : base() //тут можна переписати шо не оприділяти переменні по 2 раза
        {
            Stamina = 3;
            Strength = 0;
            Agility = 1;
            Dexterity = 1;
            Сonsciousness = 2;
            Intellect = 4;
            Type = CharacterProfesion.Mage;
        }
        public override void MakeAttak(Character enemy)
        {
            Skills skill = RandomEnumValue<Skills>();

            int addCritChance;
            addCritChance = skill == Skills.lightningBall ? 4 : 0;

            Attack attack = new Attack();

            attack.MagicalAttack = CalculateMagicalAttack((int)skill);
            if(attack.MagicalAttack > 0)
            {
                attack.PhysicalAttack = 0;
                attack.isCritical = isCritical(CriticalChance + addCritChance);
                Console.WriteLine("{0} {1} вирішив атакувати умінням {2}.", Translations.__(Type), Name, Translations.__(skill));
            }
            else
            {
                attack.PhysicalAttack = CalculatePhisicalAttack(Attack.voidHandsAttack);
                attack.isCritical = isCritical(CriticalChance + 20);
                Console.WriteLine("У мага {0} закінчилась мана тому він пішов лупцювати посохом.", Name);
            }
            attack.Accuracy = Accuracy;

            //Console.WriteLine("І хоче нанести {0} шкоди.", attack.PhysicalAttack);
            //Console.WriteLine("Це кріт = {0}.", attack.isCritical);

            enemy.TakeAttak(attack);
        }
    }
}
