using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace exam
{
    public class Resources
    {
        protected string name = "Noname";
        protected int fortress = 3;
        protected int x = 0;
        protected int y = 0;


        public Resources(string name, int fortress, int x, int y)
        {
            this.name = name;
            this.fortress = fortress;
            this.x = x;
            this.y = y;
        }
        public void Print()
        {
            Console.WriteLine($"-------------Resources {name}-------------");
            Console.WriteLine($"\tfortress -> {fortress}");
        }
        public void PrintPos()
        {
            Console.WriteLine($"Name -> {name}, Position x -> {x}, y -> {y}");
        }
    }
    internal class Gold : Resources
    {
        public Gold(int x, int y) :base("Gold", 10,x,y)
        {

        }
    }
    internal class Tree : Resources
    {
        public Tree(int x, int y) : base("Wood", 5, x, y)
        {

        }
    }
}
