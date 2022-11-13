class Client
{
    public void Operation()
    {
        Prototype prototype = new ConcretePrototype1(7);
        Prototype clone = prototype.ClonePrototype();
        Console.WriteLine(prototype.Id);
        Console.WriteLine(clone.Id);

        prototype = new ConcretePrototype2(13);
        clone = prototype.ClonePrototype();
        Console.WriteLine(prototype.Id);
        Console.WriteLine(clone.Id);
    }
}
abstract record Prototype(int Id)
{
    public abstract Prototype ClonePrototype();
}
record ConcretePrototype1 : Prototype
{
    public ConcretePrototype1(int id) : base(id) { }
    public override Prototype ClonePrototype()
        => new ConcretePrototype1(Id);
}
record ConcretePrototype2 : Prototype
{
    public ConcretePrototype2(int id) : base(id) { }
    public override Prototype ClonePrototype()
        => new ConcretePrototype2(Id);
}
