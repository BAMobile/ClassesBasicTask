using System.Collections.Generic;

Console.WriteLine("Do you want to add a team? (type in 'yes' if you do)");
if (Console.ReadLine() == "yes")
{
    Team team1 = new Team();
    Console.WriteLine("Do you want to add workers to a team? (type in 'yes' if you do)");
    if (Console.ReadLine() == "yes")
    {
        Developer developer1 = new Developer();
        team1.AddEmployee(developer1);

        Developer developer2 = new Developer();
        team1.AddEmployee(developer2);

        Manager manager1 = new Manager();
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
    protected void Call() { Console.WriteLine("Calling...\n"); }
    protected void WriteCode() { Console.WriteLine("Writing code...\n"); }
    protected void Relax() { Console.WriteLine("Relaxing...\n"); }
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
        Console.WriteLine($"The name of a team is {this.Name}");
        Console.WriteLine("Team members: ");
        for (int i = 0; i < employees.Count; i++)
            Console.WriteLine($"{employees[i].Name}");
        }
    public void DisplayDetailedData()
        {
        Console.WriteLine($"Detailed team {this.Name} data:");
        for (int i = 0; i < employees.Count; i++)
        {
            Console.WriteLine($"{employees[i].Name} - {employees[i].Position}\n");
            employees[i].FillWorkDay();
        }
        }
    }
