class Memento
{
    static void Main(string[] args)
    {
        Hero hero = new Hero();
        hero.Shoot();
        GameHistory game = new GameHistory();

        game.History.Push(hero.SaveState()); 

        hero.Shoot(); 

        hero.RestoreState(game.History.Pop());

        hero.Shoot();

        Console.Read();
    }
}

// Originator
class Hero
{
    private int patrons = 10; 
    private int lives = 5; 

    public void Shoot()
    {
        if (patrons > 0)
        {
            patrons--;
            Console.WriteLine("We make a shot. {0} ammo left", patrons);
        }
        else
            Console.WriteLine("No more ammo");
    }
 
    public HeroMemento SaveState()
    {
        Console.WriteLine("Saving the game. Parameters: {0} ammo, {1} health", patrons, lives);
        return new HeroMemento(patrons, lives);
    }

    public void RestoreState(HeroMemento memento)
    {
        this.patrons = memento.Patrons;
        this.lives = memento.Lives;
        Console.WriteLine("Game recovery. Parameters: {0} ammo, {1} health", patrons, lives);
    }
}
// Memento
class HeroMemento
{
    public int Patrons { get; private set; }
    public int Lives { get; private set; }

    public HeroMemento(int patrons, int lives)
    {
        this.Patrons = patrons;
        this.Lives = lives;
    }
}

// Caretaker
class GameHistory
{
    public Stack<HeroMemento> History { get; private set; }
    public GameHistory()
    {
        History = new Stack<HeroMemento>();
    }
}
