class Program
{
    static void Main(string[] args)
    {
        Water water = new Water(new LiquidWaterState());
        water.Heat();
        water.Frost();
        water.Frost();

        Console.Read();
    }
}
class Water
{
    public IWaterState State { get; set; }

    public Water(IWaterState ws)
    {
        State = ws;
    }

    public void Heat()
    {
        State.Heat(this);
    }
    public void Frost()
    {
        State.Frost(this);
    }
}

interface IWaterState
{
    void Heat(Water water);
    void Frost(Water water);
}

class SolidWaterState : IWaterState
{
    public void Heat(Water water)
    {
        Console.WriteLine("Turning ice into liquid");
        water.State = new LiquidWaterState();
    }

    public void Frost(Water water)
    {
        Console.WriteLine("Continue freezing ice");
    }
}
class LiquidWaterState : IWaterState
{
    public void Heat(Water water)
    {
        Console.WriteLine("Turn liquid into vapor");
        water.State = new GasWaterState();
    }

    public void Frost(Water water)
    {
        Console.WriteLine("Turn liquid into ice");
        water.State = new SolidWaterState();
    }
}
class GasWaterState : IWaterState
{
    public void Heat(Water water)
    {
        Console.WriteLine("Increasing the temperature of the water vapor");
    }

    public void Frost(Water water)
    {
        Console.WriteLine("Turning water vapor into liquid");
        water.State = new LiquidWaterState();
    }
}
