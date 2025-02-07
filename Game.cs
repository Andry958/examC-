using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace exam
{
    internal class Game
    {
        private const int Size = 15; 
        private string[,] grid = new string[Size, Size];
        private List<Units> units = new List<Units>(); 
        private List<Resources> resources = new List<Resources>(); 
        private Hero hero;
        private Random rand = new Random();

        public Game()
        {
            InitializeGrid();
            PlaceObjects();
            Menu();
        }
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine($"----------------------Menu----------------------");

                Console.Write(@"    1. Print deck 
    2. Information
    3. Move
        Enter -> ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        PrintGrid();
                        break;
                    case 2:
                        Information();
                        break;
                    case 3:
                        Move();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }

        }
        private void Move()
        {
            Console.WriteLine($"----------------------Move----------------------");
            Console.Write(@"    1. up
    2. right
    3. down
    4. left
        Enter -> ");
            int choice = int.Parse(Console.ReadLine());
            grid[hero.GetX(), hero.GetY()] = ".";
            switch (choice)
            {
                case 1:
                    if (hero.GetY() < Size - 1 && grid[hero.GetX(), hero.GetY() + 1] == ".")
                        hero.SetY(hero.GetY() + 1);
                    break;
                case 2:
                    if (hero.GetX() < Size - 1 && grid[hero.GetX() + 1, hero.GetY()] == ".")
                        hero.SetX(hero.GetX() + 1);
                    break;
                case 3:
                    if (hero.GetY() > 0 && grid[hero.GetX(), hero.GetY() - 1] == ".")
                        hero.SetY(hero.GetY() - 1);
                    break;
                case 4:
                    if (hero.GetX() > 0 && grid[hero.GetX() - 1, hero.GetY()] == ".")
                        hero.SetX(hero.GetX() - 1);
                    break;
                default:
                    break;
            }
            grid[hero.GetX(), hero.GetY()] = "H";

        }
        private void Information()
        {
            Console.WriteLine($"----------------------Information----------------------");
            Console.WriteLine("\tH -> You");
            Console.WriteLine("\tB -> Boss");
            Console.WriteLine("\tM -> Monstr");
            Console.WriteLine("\tA -> Animal");
            Console.WriteLine("\tB -> Boss");
            Console.WriteLine("\tT -> Tree");

        }
        private void InitializeGrid()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    grid[i, j] = "";
        }

        private void PlaceObjects()
        {
            hero = new Hero(new List<Thing>(), 7, 7);
            units.Add(hero);
            grid[7, 7] = "H";

            AddUnit(new BigBoss(50), "B");


            for (int i = 0; i < 3; i++)
                AddUnit(new Monsters(rand.Next(Size), rand.Next(Size)), "M");

            for (int i = 0; i < 3; i++)
                AddUnit(new Animals(rand.Next(Size), rand.Next(Size)), "A");

            for (int i = 0; i < 3; i++)
                AddResource(new Gold(rand.Next(Size), rand.Next(Size)), "G");

            for (int i = 0; i < 3; i++)
                AddResource(new Tree(rand.Next(Size), rand.Next(Size)), "T");
        }

        private void AddUnit(Units unit, string symbol)
        {
            while (true)
            {
                int x = rand.Next(Size);
                int y = rand.Next(Size);
                if (grid[x, y] == " . ")
                {
                    units.Add(unit);
                    grid[x, y] = symbol;
                    break;
                }
            }
        }

        private void AddResource(Resources resource, string symbol)
        {
            while (true)
            {
                int x = rand.Next(Size);
                int y = rand.Next(Size);
                if (grid[x, y] == ".")
                {
                    resources.Add(resource);
                    grid[x, y] = symbol;
                    break;
                }
            }
        }

        public void PrintGrid()
        {
            //Console.Clear();
            Console.WriteLine($"----------------------Menu----------------------");
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(grid[i, j]+ " ");
                }
                Console.WriteLine();
            }
        }
        
    }
}

