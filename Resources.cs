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


        public Resources(string name, int fortress, int y, int x)
        {
            this.name = name;
            this.fortress = fortress;
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
        public int Getfortress()
        {
            return fortress;
        }
        public void Setfortress(int fortress)
        {
            this.fortress = fortress;
        }
        public string GetName()
        {
            return name;
        }
        public void SetName(string Name)
        {
            this.name = Name;
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
    internal class Treasures : Resources
    {
        public Treasures(int y, int x) : base("Treasures", 1, y, x)
        {

        }
    }
        internal class Gold : Resources
    {
        public Gold(int y,int x) :base("Gold", 10,y,x)
        {

        }
    }
    internal class Tree : Resources
    {
        public Tree(int y,int x ) : base("Wood", 5, y, x)
        {

        }
    }
}
