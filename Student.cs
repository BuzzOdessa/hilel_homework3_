namespace HomeWork_3;
internal class Student : IConsoleOutput
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Grade { get; set; }

    public void PrintInfo(string msg)
    {
        Console.WriteLine($"{msg} {LastName} {FirstName}, оцінка: {Grade}");
    }
}
