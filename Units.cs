using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    public class Units
    {
        protected int HP = 100;
        protected int Mana = 100;
        protected int agility = 1;
        protected int Damage = 15;
        protected string Name = "NoName";
        protected string Type = "Enemy";
        protected int coins = 100;

        //x, y
        protected int y = 0;
        protected int x = 0;

        protected Units(int hP, int mana, int damage, string name, string type, int agility, int y, int x, int coins)
        {
            HP = hP;
            Mana = mana;
            Damage = damage;
            Name = name;
            Type = type;
            this.agility = agility;
            this.y = y;
            this.x = x;
            this.coins = coins;
        }
        public int GetCois()
        {
            return coins;
        }
        public void SetCois(int coins)
        {
            this.coins = coins;
        }
        public string GetName()
        {
            return Name;
        }
        public void SetName(string Name)
        {
            this.Name = Name;
        }
        public int GetHP()
        {
            return HP;
        }
        public void SetHP(int HP)
        {
            this.HP = HP;
        }
        public int Getagility()
        {
            return agility;
        }
        public void Setagility(int agility)
        {
            this.agility = agility;
        }
        public int GetDamage()
        {
            return Damage;
        }
        public void SetDamage(int Damage)
        {
            this.Damage = Damage;
        }
        public int GetMana()
        {
            return Mana;
        }
        public void SetMana(int Mana)
        {
            this.Mana = Mana;        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
        public void SetX(int x)
        {
            this.x = x;

        }
        public void SetY(int y)
        {
            this.y = y;
        }
        public void Print()
        {
            Console.WriteLine($"-------------Unit {Name}, {Type}-------------");
            Console.WriteLine($"\tHP -> {HP}");
            Console.WriteLine($"\tDamage -> {Damage}");
            Console.WriteLine($"\tMana -> {Mana}");
            Console.WriteLine($"\tAgility -> {agility}");
        }
        public void PrintPos()
        {
            Console.WriteLine($"Name -> {Name}, Position x -> {x}, y -> {y}");
        }
    }
    internal class BigBoss : Units 
    {
        private int Armor = 100;
        public BigBoss(int armor) : base(300, 200, 50, "Dragon", "Enemy", 1, 5,5, 500)
        {
            Armor = armor;
        }
        public void PrintB()
        {
            Print();
            Console.WriteLine($"\tArmor -> {Armor}");

        }
    }
    internal class Monsters : Units
    {
        public Monsters(int x, int y) : base(75, 25, 50, "Monsters", "Enemy", 2,x,y, 50)
        {
            this.x = x;
            this.y = y;

        }
        public void PrintB()
        {
            Print();
        }
    }
    internal class Animals : Units
    {
        public Animals(int x, int y) : base(25, 10, 50, "Animals", "Enemy", 3,x,y, 15)
        {

        }
        public void PrintB()
        {
            Print();
        }
    }
    //-----------------hero
    internal class Hero : Units
    {
        public List<Thing> inventar;
        private int Armor = 100;

        public Hero(List<Thing> inventar, int y, int x) : base(100, 30, 100, "You", "Hero", 2,y,x, 100)
        {
            this.inventar = inventar;
        }

        public void PrintB()
        {
            Print();
            Console.WriteLine($"\tCoins -> {coins}");
            Console.Write("\tInventar:");
            foreach (Thing item in inventar)
            {
                if(inventar.Count == 1)
                {item.Print();                }
                else{item.Print();Console.Write(", ");}
            }
            Console.WriteLine();    
        }
        public void ChangeCh()
        {        }
        public void PrintIn()
        {
            Console.WriteLine("Invantar:");
            foreach (Thing item in inventar)
            {
                item.Print();
            }
        }
    }

}
