class Program
{
    static void Main(string[] args)
    {
        Car auto = new Car(4, "Volvo", new PetrolMove());
        auto.Move();
        auto.Movable = new ElectricMove();
        auto.Move();

        Console.ReadLine();
    }
}
interface IMovable
{
    void Move();
}

class PetrolMove : IMovable
{
    public void Move()
    {
        Console.WriteLine("Moving using petrol");
    }
}

class ElectricMove : IMovable
{
    public void Move()
    {
        Console.WriteLine("Moving by electricity");
    }
}
class Car
{
    protected int passengers; // number of passengers
    protected string model; //model of auto

    public Car(int num, string model, IMovable mov)
    {
        this.passengers = num;
        this.model = model;
        Movable = mov;
    }
    public IMovable Movable { private get; set; }
    public void Move()
    {
        Movable.Move();
    }
}
