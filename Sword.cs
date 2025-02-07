using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    internal class Sword : Thing
    {
        private int UpperDamage = 10;
        private string Material = "Wood";
        public Sword(int UpperDamage, string Material) : base ("Noname", 25)
        {
            this.UpperDamage = UpperDamage;
            this.Material = Material;
        }
        public void PrintB()
        {
            Print();
            Console.WriteLine($"\tUpperDamage whit sword -> {UpperDamage}");
            Console.WriteLine($"\tMaterial sword -> {Material}");
        }
    }
}
