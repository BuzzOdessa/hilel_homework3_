namespace HomeWork_3;
internal class Product : IConsoleOutput
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Category { get; set; } = string.Empty;

    public void PrintInfo(string msg)
    {
        Console.WriteLine($"{msg} Категорія: {Category} Продукт: {Name} Ціна: {Price} ");
    }
}
