class Template
{
    static void Main(string[] args)
    {
        School school = new School();
        University university = new University();

        school.Learn();
        university.Learn();

        Console.Read();
    }
}
abstract class Education
{
    public void Learn()
    {
        Enter();
        Study();
        PassExams();
        GetDocument();
    }
    public abstract void Enter();
    public abstract void Study();
    public virtual void PassExams()
    {
        Console.WriteLine("Passing final exams");
    }
    public abstract void GetDocument();
}

class School : Education
{
    public override void Enter()
    {
        Console.WriteLine("Going to first class");
    }

    public override void Study()
    {
        Console.WriteLine("Attending classes, doing homework");
    }

    public override void GetDocument()
    {
        Console.WriteLine("Getting a high school diploma");
    }
}

class University : Education
{
    public override void Enter()
    {
        Console.WriteLine("Pass entrance exams and enter the university");
    }

    public override void Study()
    {
        Console.WriteLine("Attend lectures");
        Console.WriteLine("Go through practice");
    }

    public override void PassExams()
    {
        Console.WriteLine("Pass the exam in the specialty");
    }

    public override void GetDocument()
    {
        Console.WriteLine("Receive a diploma of higher education");
    }
}
