using System;

namespace ConsoleFighting.Characters
{
    internal class Attack
    {
        public static int scatter = 10;
        public static int absoluteDodge = 121;
        public static int critMult = 3;
        public static int magicCritMult = 2;
        public static int voidHandsAttack = 20;
        public int PhysicalAttack { get; set; }
        public int Accuracy { get; set; }
        public int MagicalAttack { get; set; }
        public bool isCritical { get; set; }

        public static int CalScatter(int damage)
        {
            int rand = Character._R.Next(-scatter, scatter);
            //Console.WriteLine("scatter = {0}", rand);
            return (rand * damage) / 100 + damage;
        }
    }
}
