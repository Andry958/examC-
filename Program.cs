using exam;

internal class Program
{
    private static void Main(string[] args)
    {
        /*        BigBoss Dragon = new BigBoss(50);
                Dragon.PrintB();
                Monsters Monsters = new Monsters();
                Monsters.PrintB();
                Animals Animals = new Animals();
                Animals.PrintB();
                Sword wood = new Sword(10,"Wood");
                List<Thing> th = new List<Thing> { wood };
                //th.Append(wood);
                Hero me = new Hero(th);
                me.PrintB();*/
        Game game = new Game();
        game.Menu();
        //game.PrintGrid();
    }
}