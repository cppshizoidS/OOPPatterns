class Program
{
    static void Main(string[] args)
    {
        ManagerMediator mediator = new ManagerMediator();
        Colleague customer = new CustomerColleague(mediator);
        Colleague programmer = new ProgrammerColleague(mediator);
        Colleague tester = new TesterColleague(mediator);
        mediator.Customer = customer;
        mediator.Programmer = programmer;
        mediator.Tester = tester;
        customer.Send("There is an order, it is necessary to make a program");
        programmer.Send("The program is ready, it is necessary to test");
        tester.Send("The program has been tested and is ready for sale");

        Console.Read();
    }
}

abstract class Mediator
{
    public abstract void Send(string msg, Colleague colleague);
}
abstract class Colleague
{
    protected Mediator mediator;

    public Colleague(Mediator mediator)
    {
        this.mediator = mediator;
    }

    public virtual void Send(string message)
    {
        mediator.Send(message, this);
    }
    public abstract void Notify(string message);
}
class CustomerColleague : Colleague
{
    public CustomerColleague(Mediator mediator)
        : base(mediator)
    { }

    public override void Notify(string message)
    {
        Console.WriteLine("Message to the customer: " + message);
    }
}
class ProgrammerColleague : Colleague
{
    public ProgrammerColleague(Mediator mediator)
        : base(mediator)
    { }

    public override void Notify(string message)
    {
        Console.WriteLine("Message to the programmer: " + message);
    }
}
class TesterColleague : Colleague
{
    public TesterColleague(Mediator mediator)
        : base(mediator)
    { }

    public override void Notify(string message)
    {
        Console.WriteLine("Message to tester: " + message);
    }
}

class ManagerMediator : Mediator
{
    public Colleague Customer { get; set; }
    public Colleague Programmer { get; set; }
    public Colleague Tester { get; set; }
    public override void Send(string msg, Colleague colleague)
    {

        if (Customer == colleague)
            Programmer.Notify(msg);

        else if (Programmer == colleague)
            Tester.Notify(msg);

        else if (Tester == colleague)
            Customer.Notify(msg);
    }
}
