class Program   //Factory Method
{
    static void Main(string[] args)
    {
        Developer dev = new PanelDeveloper("OOO ComapanyABOBA");
        House house2 = dev.Create();

        dev = new WoodDeveloper("PrivateDeveloper");
        House house = dev.Create();

        Console.ReadLine();
    }
}
// abstract class build company
abstract class Developer
{
    public string Name { get; set; }

    public Developer(string n)
    {
        Name = n;
    }
    // Factory Method
    abstract public House Create();
}

// build panel houses
internal class PanelDeveloper : Developer
{
    public PanelDeveloper(string n) : base(n)
    { }

    public override House Create()
    {
        return new PanelHouse();
    }
}

// build wooden houses
internal class WoodDeveloper : Developer
{
    public WoodDeveloper(string n) : base(n)
    { }

    public override House Create()
    {
        return new WoodHouse();
    }
}

abstract class House
{ }

internal class PanelHouse : House
{
    public PanelHouse()
    {
        Console.WriteLine("Panel house is builded");
    }
}

internal class WoodHouse : House
{
    public WoodHouse()
    {
        Console.WriteLine("Wooden house is builded");
    }
}
