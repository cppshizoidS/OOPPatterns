class Program
{
    static void Main(string[] args)
    {
        // programmer с++
        Programmer freelancer = new FreelanceProgrammer(new CPPLanguage());
        freelancer.DoWork();
        freelancer.EarnMoney();
        // new order on c#
        freelancer.Language = new CSharpLanguage();
        freelancer.DoWork();
        freelancer.EarnMoney();

        Console.Read();
    }
}

interface ILanguage
{
    void Build();
    void Execute();
}

class CPPLanguage : ILanguage
{
    public void Build()
    {
        Console.WriteLine("Using the C++ compiler, we compile the program into binary code");
    }

    public void Execute()
    {
        Console.WriteLine("Run the program executable");
    }
}

class CSharpLanguage : ILanguage
{
    public void Build()
    {
        Console.WriteLine("Using the Roslyn compiler, we compile the source code into an exe file");
    }

    public void Execute()
    {
        Console.WriteLine("JIT compiles the program to binary code");
        Console.WriteLine("CLR run comiled binary code");
    }
}

abstract class Programmer
{
    protected ILanguage language;
    public ILanguage Language
    {
        set { language = value; }
    }
    public Programmer(ILanguage lang)
    {
        language = lang;
    }
    public virtual void DoWork()
    {
        language.Build();
        language.Execute();
    }
    public abstract void EarnMoney();
}

class FreelanceProgrammer : Programmer
{
    public FreelanceProgrammer(ILanguage lang) : base(lang)
    {
    }
    public override void EarnMoney()
    {
        Console.WriteLine("Receive payment for the completed order");
    }
}
class CorporateProgrammer : Programmer
{
    public CorporateProgrammer(ILanguage lang)
        : base(lang)
    {
    }
    public override void EarnMoney()
    {
        Console.WriteLine("Get paid at the end of the month");
    }
}
