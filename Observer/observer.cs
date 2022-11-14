class Program
{
    static void Main(string[] args)
    {
        Stock stock = new Stock();
        Bank bank = new Bank("UnitBank", stock);
        Broker broker = new Broker("Ivan Ivanovich", stock);
        stock.Market();
        broker.StopTrade();
        stock.Market();

        Console.Read();
    }
}

interface IObserver
{
    void Update(Object ob);
}

interface IObservable
{
    void RegisterObserver(IObserver o);
    void RemoveObserver(IObserver o);
    void NotifyObservers();
}

class Stock : IObservable
{
    StockInfo sInfo; // информация о торгах

    List<IObserver> observers;
    public Stock()
    {
        observers = new List<IObserver>();
        sInfo = new StockInfo();
    }
    public void RegisterObserver(IObserver o)
    {
        observers.Add(o);
    }

    public void RemoveObserver(IObserver o)
    {
        observers.Remove(o);
    }

    public void NotifyObservers()
    {
        foreach (IObserver o in observers)
        {
            o.Update(sInfo);
        }
    }

    public void Market()
    {
        Random rnd = new Random();
        sInfo.USD = rnd.Next(20, 40);
        sInfo.Euro = rnd.Next(30, 50);
        NotifyObservers();
    }
}

class StockInfo
{
    public int USD { get; set; }
    public int Euro { get; set; }
}

class Broker : IObserver
{
    public string Name { get; set; }
    IObservable stock;
    public Broker(string name, IObservable obs)
    {
        this.Name = name;
        stock = obs;
        stock.RegisterObserver(this);
    }
    public void Update(object ob)
    {
        StockInfo sInfo = (StockInfo)ob;

        if (sInfo.USD > 30)
            Console.WriteLine("Broker {0} sells dollars;  Dollar exchange rate: {1}", this.Name, sInfo.USD);
        else
            Console.WriteLine("Broker {0} buy dollars;  Dollar exchange rate: {1}", this.Name, sInfo.USD);
    }
    public void StopTrade()
    {
        stock.RemoveObserver(this);
        stock = null;
    }
}

class Bank : IObserver
{
    public string Name { get; set; }
    IObservable stock;
    public Bank(string name, IObservable obs)
    {
        this.Name = name;
        stock = obs;
        stock.RegisterObserver(this);
    }
    public void Update(object ob)
    {
        StockInfo sInfo = (StockInfo)ob;

        if (sInfo.Euro > 40)
            Console.WriteLine("Bank {0} sells euro; Euro exchange rate: {1}", this.Name, sInfo.Euro);
        else
            Console.WriteLine("Bank {0} buy euro; Euro exchange rate: {1}", this.Name, sInfo.Euro);
    }
}
