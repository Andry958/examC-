using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    internal class Sword_ : Thing
    {
        public int UpperDamage = 10;
        private string name = "Wood";
        int cool = 0;
        public Sword_(int UpperDamage, string name, int price,int cool) : base (name, price)
        {
            this.price = price;
            this.UpperDamage = UpperDamage;
            this.name = name;
            this.cool = cool;
        }
        public void PrintB()
        {
            Print();
            Console.WriteLine($"\tUpperDamage whit sword -> {UpperDamage}");
            Console.WriteLine($"\tthis -> {name}");
        }
    }
    internal class Armor : Thing
    {
        public int UpperArmor = 10;
        private string name = "Wood";
        int cool = 0;


        public Armor(int price, string name, int UpperArmor, int cool) : base(name, price)
        {
            this.price = price;
            this.UpperArmor = UpperArmor;
            this.name = name;
            this.cool = cool;
        }
        public void PrintB()
        {
            Print();
            Console.WriteLine($"\tUpperArmor whit armor -> {UpperArmor}");
            Console.WriteLine($"\tthis -> {name}");
        }
    }
}
