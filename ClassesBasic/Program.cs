using System.Collections.Generic;

Console.WriteLine("Do you want to add a team? (type in 'yes' if you do)");
if (Console.ReadLine() == "yes")
{
    Team team1 = new Team();
    Console.WriteLine("Do you want to add workers to a team? (type in 'yes' if you do)");
    if (Console.ReadLine() == "yes")
    {
        Developer developer1 = new Developer();
        Console.WriteLine("Type in developer's workday");
        developer1.WorkDay=Console.ReadLine();
        team1.AddEmployee(developer1);

        Developer developer2 = new Developer();
        Console.WriteLine("Type in developer's workday");
        developer2.WorkDay = Console.ReadLine();
        team1.AddEmployee(developer2);

        Manager manager1 = new Manager();
        Console.WriteLine("Type in manager's workday");
        manager1.WorkDay = Console.ReadLine();
        team1.AddEmployee(manager1);

        team1.DisplayTeamData();
        Console.WriteLine("\n");
        team1.DisplayDetailedData();
    }
}

abstract class Worker
{
    public string Name;
    public string Position;
    public string WorkDay;
    public Worker()
    {
        Console.WriteLine("Type in worker's name");
        this.Name = Console.ReadLine();
    }
    protected void Call() { }
    protected void WriteCode() { }
    protected void Relax() { }
    public abstract void FillWorkDay();
}

class Developer : Worker
{
    public Developer()
    {
        this.Position = "Developer";
    }
   override public void FillWorkDay() { WriteCode(); Call(); Relax(); WriteCode(); }
}

class Manager : Worker
{
    public Manager()
    {
        this.Position = "Manager";
    }
    Random r = new Random();
    override public void FillWorkDay()
    {
        int i = r.Next(1, 11);
        for (int j = 0; j < i; j++)
            Call();
        Relax();
        i = r.Next(1, 6);
        for (int j = 0; j < i; j++)
            Call();
    }
}

class Team
{
    string Name;
    public Team()
    {
        Console.WriteLine("Type in a name for your team");
        this.Name = Console.ReadLine();
    }
    List<Worker> employees = new List<Worker>();
    public void AddEmployee(Worker worker)
    {
        employees.Add(worker);
    }
    public void DisplayTeamData() {
        Console.WriteLine(this.Name);
        for (int i = 0; i < employees.Count; i++)
            Console.WriteLine($"{employees[i].Name}\n");
        }
    public void DisplayDetailedData()
        {
            Console.WriteLine(this.Name);
            for (int i = 0; i < employees.Count; i++)
                Console.WriteLine($"{employees[i].Name} - {employees[i].Position} - {employees[i].WorkDay}\n");
        }
    }




