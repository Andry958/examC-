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
            Console.Write($" name -> {name}, price -> {price}");
        }
    }
    
}
