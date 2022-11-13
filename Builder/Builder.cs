using System.Text;
using System.Threading;

// мука
class Flour
{
    // какого сорта мука
    public string Sort { get; set; }
}
// соль
class Salt
{ }
// пищевые добавки
class Additives
{
    public string Name { get; set; }
}

class Bread
{
    // мука
    public Flour Flour { get; set; }
    // соль
    public Salt Salt { get; set; }
    // пищевые добавки
    public Additives Additives { get; set; }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        if (Flour != null)
            sb.Append(Flour.Sort + "\n");
        if (Salt != null)
            sb.Append("Salt \n");
        if (Additives != null)
            sb.Append("Additives: " + Additives.Name + " \n");
        return sb.ToString();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // содаем объект пекаря
        Baker baker = new Baker();
        // создаем билдер для ржаного хлеба
        BreadBuilder builder = new RyeBreadBuilder();
        // выпекаем
        Bread ryeBread = baker.Bake(builder);
        Console.WriteLine(ryeBread.ToString());
        // оздаем билдер для пшеничного хлеба
        builder = new WheatBreadBuilder();
        Bread wheatBread = baker.Bake(builder);
        Console.WriteLine(wheatBread.ToString());

        Console.Read();
    }
}
// абстрактный класс строителя
abstract class BreadBuilder
{
    public Bread Bread { get; private set; }
    public void CreateBread()
    {
        Bread = new Bread();
    }
    public abstract void SetFlour();
    public abstract void SetSalt();
    public abstract void SetAdditives();
}
// пекарь
class Baker
{
    public Bread Bake(BreadBuilder breadBuilder)
    {
        breadBuilder.CreateBread();
        breadBuilder.SetFlour();
        breadBuilder.SetSalt();
        breadBuilder.SetAdditives();
        return breadBuilder.Bread;
    }
}
// строитель для ржаного хлеба
class RyeBreadBuilder : BreadBuilder
{
    public override void SetFlour() => Bread.Flour = new Flour { Sort = "Rye flour fist sort" };

    public override void SetSalt() => Bread.Salt = new Salt();

    public override void SetAdditives()
    {
        // не используется
    }
}
// строитель для пшеничного хлеба
class WheatBreadBuilder : BreadBuilder
{
    public override void SetFlour() => this.Bread.Flour = new Flour { Sort = "Wheat flour highest sort" };

    public override void SetSalt() => this.Bread.Salt = new Salt();

    public override void SetAdditives() => this.Bread.Additives = new Additives { Name = "bakery improver" };
}
