public interface IClient
{
    string GetData();
}


public class RealClient : IClient
{
    string Data;
    public RealClient()
    {
        Console.WriteLine("Real Client: Initialized");
        Data = "Amogus";
    }

    public string GetData()
    {
        return Data;
    }
}


public class ProxyClient : IClient
{
    RealClient client = new RealClient();
    public ProxyClient()
    {
        Console.WriteLine("ProxyClient: Initialized");
    }

    public string GetData()
    {
        return client.GetData();
    }
}


class Program
{
    static void Main(string[] args)
    {
        ProxyClient proxy = new ProxyClient();
        Console.WriteLine("Data from Proxy Client = {0}", proxy.GetData());

        Console.ReadKey();
    }
}
