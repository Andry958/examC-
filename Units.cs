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
        //x, y
        protected int x = 0;
        protected int y = 0;

        protected Units(int hP, int mana, int damage, string name, string type, int agility, int x, int y)
        {
            HP = hP;
            Mana = mana;
            Damage = damage;
            Name = name;
            Type = type;
            this.agility = agility;
            this.x = x;
            this.y = y;
        }
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
        protected void Print()
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
        public BigBoss(int armor) : base(300, 200, 50, "Dragon", "Enemy", 3, 5,5)
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
        public Monsters(int x, int y) : base(75, 25, 50, "Monsters", "Enemy", 5,x,y)
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
        public Animals(int x, int y) : base(25, 10, 50, "Animals", "Enemy", 1,x,y)
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
        private List<Thing> inventar;
        private int coins = 0;
        public Hero(List<Thing> inventar, int x, int y) : base(100, 30, 100, "You", "Hero", 2,x,y)
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
    }

}
