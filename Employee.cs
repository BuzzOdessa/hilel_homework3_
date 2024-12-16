namespace HomeWork_3;
internal class Employee
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public DateTime BirthDate { get; set; }
    public DateTime EmploymentDate { get; set; }

    public override string ToString()
    {
        return $"{LastName} {FirstName}, дата працевлаштування: {EmploymentDate:dd.MM.yyyy}";
    }
}
