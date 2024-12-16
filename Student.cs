namespace HomeWork_3;
internal class Student
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Grade { get; set; }

    public override string ToString()
    {
        return $"{LastName} {FirstName}, оцінка: {Grade}";
    }
}
