//Console.WriteLine("Do you want to add a team? (type in 'yes' if you do)");
// TODO - доречне тільки для циклів
//if (Console.ReadLine() == "yes")
//{
	Team team1 = new Team();
// TODO - кщо б було розгалудження, тоді доречно, інакше просто код заради кода
//Console.WriteLine("Do you want to add workers to a team? (type in 'yes' if you do)");
	//if (Console.ReadLine() == "yes")
	//{
		Developer developer1 = new Developer();
		team1.AddEmployee(developer1);

		Developer developer2 = new Developer();
		team1.AddEmployee(developer2);

		Manager manager1 = new Manager();
		team1.AddEmployee(manager1);

		team1.DisplayTeamData();
// TODO - WriteLine це вже виведення на новому рядку, + "\n" це відступ у 2 рядки
Console.WriteLine("\n");
		team1.DisplayDetailedData();
	//}
//}

abstract class Worker
{
	public string Name;
	public string Position;
	public string WorkDay;
	// TODO - "конструктор, який приймає на вхід ім'я", у Вашій реалізації він його не приймає
	public Worker()
	{
		Console.WriteLine("Type in worker's name");
		Name = Console.ReadLine();
	}
	protected void Call() { Console.WriteLine("Calling..."); }
	protected void WriteCode() { Console.WriteLine("Writing code..."); }
	protected void Relax() { Console.WriteLine("Relaxing..."); }
	public abstract void FillWorkDay();
}

class Developer : Worker
{
	public Developer()
	{
		Position = "Developer";
	}
	override public void FillWorkDay() { WriteCode(); Call(); Relax(); WriteCode(); }
}

class Manager : Worker
{
	public Manager()
	{
		Position = "Manager";
		_random = new Random();
	}
	Random _random;
	override public void FillWorkDay()
	{
		for (int j = 0; j < _random.Next(1, 11); j++)
			Call();
		Relax();
		for (int j = 0; j < _random.Next(1, 6); j++)
			Call();
	}
}

class Team
{
	// TODO - у Вашій реалізації це приватне поле, отже має бути дотримано стиль оформлення:
	// або з маленької літери або як глобальну приватну змінну з _
	string _name;
	public Team()
	{
		Console.WriteLine("Type in a name for your team");
		_name = Console.ReadLine();
	}
	List<Worker> employees = new List<Worker>();
	public void AddEmployee(Worker worker)
	{
		employees.Add(worker);
	}
	public void DisplayTeamData()
	{
		Console.WriteLine($"The name of a team is {_name}");
		// TODO - що буде виведено за відсутності працівнеиків у команді?
		Console.WriteLine("Team members: ");
		for (int i = 0; i < employees.Count; i++)
			Console.WriteLine($"{employees[i].Name}");
	}
	public void DisplayDetailedData()
	{
		Console.WriteLine($"Detailed team {_name} data:");
		for (int i = 0; i < employees.Count; i++)
		{
			Console.WriteLine($"{employees[i].Name} - {employees[i].Position}\n");
			employees[i].FillWorkDay();
		}
	}
}
