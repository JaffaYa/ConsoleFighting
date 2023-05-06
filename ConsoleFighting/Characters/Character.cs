using System;
using ConsoleFighting.Interfaces;

namespace ConsoleFighting.Characters
{
    enum CharacterProfesion
    {
        Warrior = 1,
        Scout,
        Mage,
    }
    internal abstract class Character : ICharacter
    {
        public string Name { get; set; }
        public CharacterProfesion Type { get; set; }
        public int UnsetPoints { get; set; }

        public static int hpMult = 75;
        public static int deffMult = 2;
        public static int atkMult = 10;
        public static int dodgeStart = 15;
        public static int dodgeMul = 10;
        public static int accMul = 10;
        public static int critChaStart = 5;
        public static int critChaMult = 1;
        public static int mpMult = 50;
        public static int magicResistMult = 3;
        public static int matkMult = 10;

        //character stats
        //виносливість
        private int stamina; 
        public int Stamina
        {
            get { return stamina;  }
            set
            {
                stamina = value;
                HealthPoints = hpMult * stamina;
                PhysicalDeffends = deffMult * stamina;
            }
        }

        //сила
        private int strength;
        public int Strength
        {
            get { return strength; }
            set
            {
                strength = value;
                PhysicalAttack = atkMult * strength;
            }
        }

        //спритність
        private int agility;
        public int Agility 
            {
            get { return agility;  }
            set
            {
                agility = value;
                Dodge = dodgeStart + dodgeMul * agility;
                //тут можна добавляти швидікість атаки коли буде така механіка
            }
        }

        //проворність
        private int dexterity;
        public int Dexterity 
            {
            get { return dexterity;  }
            set
            {
                dexterity = value;
                Accuracy = accMul * dexterity;
                CriticalChance = critChaStart + critChaMult*dexterity;
            }
        }

        //свідомість
        private int consciousness;
        public int Сonsciousness 
            {
            get { return consciousness;  }
            set
            {
                consciousness = value;
                MagicalPoins = mpMult * consciousness;
                MagicalResist = magicResistMult * consciousness;
            }
        }

        // інтелект
        private int intellect;
        public int Intellect 
            {
            get { return intellect;  }
            set
            {
                intellect = value;
                MagicalAttack = matkMult * intellect;
            }
        }


        //character characteristics
        public int HealthPoints { get; set; } //кількисть HP
        public int PhysicalDeffends { get; set; } //фізичнмий захист
        public int PhysicalAttack { get; set; } //фізична атака
        public int Dodge { get; set; } //промахи
        public int Accuracy { get; set; } //точність 
        public int CriticalChance { get; set; } //шанс критичного удару 
        public int MagicalResist { get; set; } //магічний опір
        public int MagicalPoins { get; set; } //кількість MP 
        public int MagicalAttack { get; set; } //сила магічної атаки + можна реалізувати змешення потребування мани

        public Character() //тут можна переписати шо не оприділяти переменні по 2 раза
        {
            Name = "";
            Stamina = 1;
            Strength = 1;
            Agility = 1;
            Dexterity = 1;
            Сonsciousness = 1;
            Intellect = 1;
            UnsetPoints = 10;
        }

        public void ShowInfo()
        {
            //Console.WriteLine("STA - {0}\t\tSTR - {1}\t\tAGI - {2}\t\tDEX - {3}\t\tCON - {4}\t\tINT - {5}", Stamina, Strength, Agility, Dexterity, Сonsciousness, Intellect);
            //Console.WriteLine("DEF - {0}\t\tATK - {1}\t\tDOD - {2}\t\tACC - {3}\t\tMRe - {4}\t\tMAtk - {5}", PhysicalDeffends, PhysicalAttack, Dodge, Accuracy, MagicalResist, MagicalAttack);
            //Console.WriteLine("HP - {0}\t\t\t\tCRI - {1}\t\tMP - {2}", HealthPoints, CriticalChance, MagicalPoins);
            Console.WriteLine("1. STA - {0} -> Deff = {1},\t\t\tHP = {2}", Stamina, PhysicalDeffends, HealthPoints);
            Console.WriteLine("2. STR - {0} -> ATK = {1}", Strength, PhysicalAttack);
            Console.WriteLine("3. AGI - {0} -> Dodge = {1}", Agility, Dodge);
            Console.WriteLine("4. DEX - {0} -> Accuracy = {1},\t\tCriticalChance = {2}%", Dexterity, Accuracy, CriticalChance);
            Console.WriteLine("5. CON - {0} -> MagicalResist = {1},\tMP = {2}", Сonsciousness, MagicalResist, MagicalPoins);
            Console.WriteLine("6. INT - {0} -> MATK = {1}", Intellect, MagicalAttack);
        }
        public void ShowShortInfo()
        {
            Console.WriteLine(Name);

            Console.Write("HP - ");
            DisplayBarRed(HealthPoints);
            DisplayBar(ConsoleColor.DarkGreen, HealthPoints);
            
            Console.WriteLine();

            Console.Write("MP - ");
            DisplayBarRed(MagicalPoins);
            DisplayBar(ConsoleColor.DarkBlue, MagicalPoins);
            Console.WriteLine();
        }

        private void DisplayBar(ConsoleColor color, int value)
        {
            int step = 25;
            ConsoleColor defCol = Console.BackgroundColor;
            Console.BackgroundColor = color;
            //string bar = value > 0 && value < step? "#" : "";
            string bar = "";
            for (int i = 0; i < value; i += step)
            {
                bar += "#";
            }
            Console.Write(bar);
            Console.BackgroundColor = defCol;
        }

        private void DisplayBarRed(int value)
        {
            ConsoleColor defCol = Console.BackgroundColor;
            if (value <= 0) Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(value);
            if (value <= 0) Console.BackgroundColor = defCol;
            Console.Write("  \t");
        }

        public abstract void MakeAttak(Character enemy);

        public void TakeAttak(Attack attack)
        {
            int sumaryDamage = 0;
            bool isPhisicalAttac = attack.PhysicalAttack != 0;
            if (isPhisicalAttac)
            {
                int rand = Character._R.Next(Attack.absoluteDodge);
                bool isMiss = attack.isCritical ? false : (Dodge - attack.Accuracy) > rand;
                if (isMiss)
                {
                    sumaryDamage = 0;
                    Console.WriteLine("Але промахнувся!");
                }
                else
                {
                    sumaryDamage = attack.PhysicalAttack;
                    if (attack.isCritical)
                    {
                        sumaryDamage *= Attack.critMult;
                        Console.WriteLine("Критична атака!!!");
                    }
                    else
                    {
                        // - deff
                        sumaryDamage -= (PhysicalDeffends * sumaryDamage) / 100;
                    }

                }
            }
            else //magic attac
            {
                sumaryDamage = attack.MagicalAttack;
                if (attack.isCritical)
                {
                    sumaryDamage *= Attack.magicCritMult;
                    Console.WriteLine("Критична атака!!!");
                }
                else
                {
                    // - MagicalResist
                    sumaryDamage -= (MagicalResist * sumaryDamage) / 100;
                }
            }
            Console.WriteLine("І наніс {0} шкоди.", sumaryDamage);
            HealthPoints -= sumaryDamage;
            //Console.WriteLine("HealthPoints - "+ HealthPoints);
            //Console.WriteLine("MagicalPoins - " + MagicalPoins);
        }

        public virtual int CalculatePhisicalAttack(int weaponDamage)
        {
            int StaticReinforcement = (weaponDamage * PhysicalAttack) / 100;
            return Attack.CalScatter(weaponDamage + StaticReinforcement);
        }
        public virtual int CalculateMagicalAttack(int skillDamage)
        {
            int tempMana = MagicalPoins;
            tempMana -= skillDamage/2;
            if(tempMana > 0)
            {
                MagicalPoins = tempMana;
                int StaticReinforcement = (skillDamage * MagicalAttack) / 100;
                return Attack.CalScatter(skillDamage + StaticReinforcement);
            }
            else
            {
                return 0;
            }
        }

        public static bool isCritical(int critChance)
        {
            int rand = Character._R.Next(100);
            //Console.WriteLine("Шанс кріта = {0}, випало = {1}", critChance, rand);
            return critChance > rand;
        }

        public static Random _R = new Random();
        public static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(_R.Next(v.Length));
        }
    }
}
