namespace HomeWork_3;
internal class Employee : IConsoleOutput
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; }
    public DateTime EmploymentDate { get; set; }

    public void PrintInfo(string msg)
    {
        Console.WriteLine($"{msg} {LastName} {FirstName}, дата працевлаштування: {EmploymentDate:dd.MM.yyyy}");
    }
}
