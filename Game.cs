using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private static int countStep = 0;
        private List<Thing> magazine = new List<Thing>();

        public Game()
        {
            InitializeGrid();
            PlaceObjects();
            InitializeMag();
            //Menu();
        }
        private void InitializeMag()
        {
            magazine.Add(new Sword_(10, "Wood sword", 10,1));
            magazine.Add(new Sword_(25, "Iron sword", 20, 2));
            magazine.Add(new Sword_(50, "Gold sword", 30,3));
            magazine.Add(new Sword_(100, "Dimond sword", 50,4));
            magazine.Add(new Armor(10, "Wood armor", 10,1));
            magazine.Add(new Armor(25, "Iron armor", 40,2));
        }
        private void InMagazine()
        {
            Console.WriteLine($"----------------------Shop----------------------");
            Console.WriteLine("All item:");
            int i = 0;
            foreach (Thing thing in magazine)
            {
                Console.WriteLine($"name -> {thing.name}, price -> {thing.price}, num -> {i}");i++;
            }
            Console.Write("Enter num for buy -> "); int choice = int.Parse(Console.ReadLine());
            i = 0;

            foreach (Thing thing in magazine)
            {
                if(choice == i)
                {
                    if(hero.GetCois() > thing.price)
                    {
                        var Haveitem = hero.inventar.FirstOrDefault(item => item.GetType() == thing.GetType());
                        if (Haveitem != null)
                        {
                            hero.inventar.Remove(Haveitem); 
                        }
                        hero.inventar.Add(thing);
                        hero.SetCois(hero.GetCois() - thing.price);
                        Console.WriteLine("You buy!");
                        magazine.Remove(thing);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("you didn't have enough money! ");
                    }
                }
                 i++;
            }
        }
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine($"----------------------Menu----------------------");

                Console.Write(@"    1. Print deck 
    2. Information
    3. Game
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
                        Game_();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }

        }
        private void InfAboutMe()
        {
            hero.PrintB();
        }
        private void rest()
        {
            if (hero.GetMana() >= 100)
            {
                Console.WriteLine("Your mana full!");
                return;
            }
            Console.WriteLine($"----------------------You rest----------------------");
            Console.WriteLine("Zzz...");

            hero.SetMana(hero.GetMana() + 10);
            Console.WriteLine($"Your mana -> {hero.GetMana()}");
        }
        private void Move()
        {
            Console.WriteLine($"----------------------Move----------------------");
            Console.WriteLine("Use arrow(q - exit)");

            while (true)
            {

                int newY = hero.GetY();
                int newX = hero.GetX();

                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow: 
                        if (newY > 0 && grid[newY - 1, newX] == ".")
                            newY--;
                        break;
                    case ConsoleKey.RightArrow: 
                        if (newX < grid.GetLength(1) - 1 && grid[newY, newX + 1] == ".")
                            newX++;
                        break;
                    case ConsoleKey.DownArrow:
                        if (newY < grid.GetLength(0) - 1 && grid[newY + 1, newX] == ".")
                            newY++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (newX > 0 && grid[newY, newX - 1] == ".")
                            newX--;
                        break;
                    case ConsoleKey.Q:
                        return;
                    default:
                        continue; 
                }

                if (newY == hero.GetY() && newX == hero.GetX())
                {
                    Console.WriteLine("You need to choose mine or attack!");
                    return;
                }

                grid[hero.GetY(), hero.GetX()] = "."; 
                hero.SetX(newX);
                hero.SetY(newY);
                grid[hero.GetY(), hero.GetX()] = "H"; 

                countStep += 1;
                PrintGrid();
                break;
            }
        }

    private void Mine()
        {
            Console.WriteLine($"----------------------Mine----------------------");

            Console.Write(@"    1. up
    2. right
    3. down
    4. left
        Enter -> ");
            int choice = int.Parse(Console.ReadLine());
            int newY = hero.GetY();
            int newX = hero.GetX();

            switch (choice)
            {
                case 1: // Up
                    newY--;
                    break;
                case 2: // Right
                    newX++;
                    break;
                case 3: // Down
                    newY++;
                    break;
                case 4: // Left
                    newX--;
                    break;
                default:
                    break;
            }
            if (newY < 0 || newY >= Size || newX < 0 || newX >= Size)
            {
                Console.WriteLine("Out of range");
                return;
            }
            
            if (grid[newY, newX] == "G" || grid[newY, newX] == "T" || grid[newY, newX] == "S")
            {
                Resources item = FoundResour(newY, newX);
                item.Setfortress(item.Getfortress() - 1);
                hero.SetMana(hero.GetMana() - 5);

                if (item.Getfortress() >= 1)
                    Console.WriteLine($"You mine -> fortress res({item.Getfortress()}), your mana -> {hero.GetMana()}");
                else
                {
                    Console.WriteLine($"You destroy {item.GetName()}");
                    grid[newY, newX] = ".";
                    if(item is Gold)
                    {
                        int rand_ = rand.Next(10);
                        if (rand_ <= 3)
                        {
                            hero.inventar.Add(new Nuggets());
                            Console.WriteLine("You get nuggets! ");
                            return;
                        }
                        else
                        {
                            hero.inventar.Add(new Coins());
                            hero.inventar.Add(new Coins());
                            hero.inventar.Add(new Coins());
                            Console.WriteLine("You get 3 coins! ");
                            return;
                        }
                    }
                    else if(item is Treasures)
                    {
                        Console.WriteLine("You get Treasures! ");
                        int CoinsInTr = rand.Next(74);
                        Console.WriteLine($"In Treasures was {CoinsInTr}");
                        hero.SetCois(hero.GetCois() + CoinsInTr);
                    }
                    else
                    {
                        int rand_ = rand.Next(15);
                        for (int i = 0;i < rand_; i++)
                        {
                            hero.inventar.Add(new Wood());
                        }
                        Console.WriteLine($"You get {rand_} wood! ");return;
                    }
                }
                return;
            }
            else
            {
                Console.WriteLine("resource not found!");
            }
        }
        private Resources FoundResour(int y, int x)
        {
            //Console.WriteLine($"{x}x, {y}y");
            foreach (Resources item in resources)
            {
                //item.PrintPos();
                if (item.GetY() == y && item.GetX() == x) return item;
            }
            return null;
        }
        private void  Atack()
        {
            Console.WriteLine($"----------------------Atack----------------------");



            Console.Write(@"    1. up
    2. right
    3. down
    4. left
        Enter -> ");
            int choice = int.Parse(Console.ReadLine());
            int newY = hero.GetY();
            int newX = hero.GetX();

            switch (choice)
            {
                case 1: // Up
                    newY--;
                    break;
                case 2: // Right
                    newX++;
                    break;
                case 3: // Down
                    newY++;
                    break;
                case 4: // Left
                    newX--;
                    break;
                default:
                    break;
            }
            if (newY < 0 || newY >= Size || newX < 0 || newX >= Size)
            {
                Console.WriteLine("Out of range");
                return;
            }
            if (grid[newY, newX] == "B" || grid[newY, newX] == "M" || grid[newY, newX] == "A")
            {
                Units item = FoundEn(newY, newX);
                Fight(item);
            }

        }
        private void Fight(Units enemy)
        {
            Console.WriteLine($"You: ");
            hero.PrintB();
            Console.WriteLine($"Enemy: ");
            enemy.Print();
            int DefForArmor = FindArmor();
            Console.WriteLine("-----------------Batle-----------");//можна зробить набагато краще якщо зробить баланс ітд але сама бойовко працює
            while (enemy.GetHP() > 0 && hero.GetHP() > 0)
            {
                int randPowerEnemy = rand.Next(enemy.GetDamage());
                int randPowerMy = rand.Next(hero.GetDamage()) + FindSword();
                Console.WriteLine($"Your damge -> {randPowerMy}");
                Console.WriteLine($"Your HP -> {hero.GetHP()}");
                Console.WriteLine($"Your armor -> {DefForArmor}");
                Console.WriteLine($"Enemy HP -> {enemy.GetHP()}");
                Console.WriteLine($"Enemy damge -> {randPowerEnemy}");
                enemy.SetHP(enemy.GetHP() - (randPowerMy) * hero.Getagility());
                if (enemy.GetHP() <= 0) {
                    Console.WriteLine("Enemy Died!");
                    hero.SetX(enemy.GetX());
                    hero.SetY(enemy.GetY());
                    grid[enemy.GetY(), enemy.GetX()] = "H";
                    grid[hero.GetY(), hero.GetX()] = ".";
                    hero.SetCois(hero.GetCois() + enemy.GetCois());
                    Console.WriteLine($"you took {enemy.GetCois()} coins");
                    return;
                }
                hero.SetHP(hero.GetHP() - (randPowerEnemy) * enemy.Getagility() + DefForArmor);
                if (DefForArmor > 0)
                {
                    hero.SetHP(hero.GetHP() - (randPowerEnemy) * enemy.Getagility() + DefForArmor);
                    DefForArmor -= (randPowerEnemy) * enemy.Getagility();
                }
                else
                    hero.SetHP(hero.GetHP() - (randPowerEnemy) * enemy.Getagility());
                if (hero.GetHP() <= 0)
                {
                    Console.WriteLine("You Died!");
                    enemy.SetX(enemy.GetX());
                    enemy.SetY(enemy.GetY());
                    grid[enemy.GetY(), enemy.GetX()] = ".";
                    grid[enemy.GetY(), enemy.GetX()] = enemy.GetName()[0].ToString();
                    Console.WriteLine($"----------------------Print----------------------");
                    for (int i = 0; i < Size; i++)
                    {
                        for (int j = 0; j < Size; j++)
                        {
                            Console.Write(" " + grid[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("Count steps -> " + countStep);
                    Environment.Exit(0);
                    return;
                }
                Console.WriteLine($"You: ");
                hero.PrintB();
                if (DefForArmor <= 0)
                {
                    Console.WriteLine($"Armor is destroy! But We fix armor before starting a new battle");
                    hero.SetCois(hero.GetCois() - 10);
                }
                Console.WriteLine($"Enemy: ");
                enemy.Print();

            }

        }
        private int FindArmor()
        {
            for (int index = 0; index < hero.inventar.Count; index++)
            {
                if (hero.inventar[index] is Armor armor)
                {
                    return armor.UpperArmor;
                }
            }
            return 0;
        }
        private int FindSword()
        {
            for (int index = 0; index < hero.inventar.Count; index++)
            {
                if (hero.inventar[index] is Sword_ sword)
                {
                    return sword.UpperDamage; 
                }
            }
            return 0;
        }
        private Units FoundEn(int y, int x)
        {
           // Console.WriteLine("");
            foreach (Units item in units)
            {
                //item.PrintPos();
                if (item.GetY() == y && item.GetX() == x) return item;
            }
            return null;
        }
        private void Game_()
        {
            while (true)
            {

            Console.WriteLine($"----------------------Game----------------------");
                Console.Write(@"    1. Print deck
    2. information about hero
    3. Move
    4. Mine
    5. Rest
    6. Check ininventarv
    7. In shop
    8. Atack
    0. Menu
        Enter -> ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        PrintGrid();
                        break;
                    case 2:
                        InfAboutMe();
                        break;
                    case 3:
                        Move();
                        break;
                    case 4:
                        Mine();
                        break;
                    case 5:
                        rest();
                        break;
                    case 6:
                        hero.PrintIn();
                        break;
                    case 7:
                        InMagazine();
                        break;
                    case 8:
                        Atack();
                        break;
                    case 0:
                        Menu();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        private void SellAllThighs()
        {
            Console.WriteLine($"----------------------SellAllThighs----------------------");
            Console.WriteLine("You sell:");
            foreach (Thing item in hero.inventar)
            {
                item.Print();
            }
            foreach (Thing item in hero.inventar)
            {
                hero.SetCois(item.Getprice() + hero.GetCois());
            }
            hero.inventar.Clear();
            Console.WriteLine($"You sell thighs and your balance -> {hero.GetCois()}");
        }
        private void Information()
        {
            Console.WriteLine($"----------------------Information----------------------");
            Console.WriteLine("\tH -> You");
            Console.WriteLine("\tB -> Boss");
            Console.WriteLine("\tM -> Monstr");
            Console.WriteLine("\tA -> Animal");
            Console.WriteLine("\tT -> Tree");

        }
        private void InitializeGrid()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    grid[i, j] = ".";
        }

        private void PlaceObjects()
        {
            hero = new Hero(new List<Thing>(), 7, 7);
            units.Add(hero);
            grid[7, 7] = "H";

            AddUnit(new BigBoss(50), "B");
            AddResource(new Gold(rand.Next(Size), rand.Next(Size)), "S");


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
                int x = unit.GetX();
                int y = unit.GetY();
                if (grid[y, x] == ".")
                {
                    units.Add(unit);
                    grid[y, x] = symbol;
                    break;
                }
            }
        }

        private void AddResource(Resources resource, string symbol)
        {
            while (true)
            {
                if (grid[resource.GetY(),resource.GetX()] == ".")
                {
                    resources.Add(resource);
                    grid[resource.GetY(), resource.GetX()] = symbol;
                    break;
                }
            }
        }

        public void PrintGrid()
        {
            Console.Clear();
            Console.WriteLine($"----------------------Print----------------------");
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(" " + grid[i, j]+ " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Count steps -> " + countStep);
        }
        
    }
}

