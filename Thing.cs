using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace exam
{
    public class Thing
    {
        public string name = "noname";
        public int price = 50;
        public Thing(string name, int price)
        {
            this.name = name;
            this.price = price;
        }
        public void Print()
        {
/*            Console.WriteLine($"-------------Thing {name}-------------");
            Console.WriteLine($"\tPrice -> {price}");*/
            Console.WriteLine($" name -> {name}, price -> {price}");
        }
        public int Getprice()
        {
            return price;
        }
    }
   internal class Coins: Thing
    {
        public Coins() : base("Gold Coins", 25)
        {

        }
    }
    internal class Nuggets : Thing
    {
        public Nuggets() : base("Gold Nuggets", 5)
        {

        }
    }
    internal class Wood : Thing
    {
        public Wood() : base("Wood", 1)
        {

        }
    }

}
