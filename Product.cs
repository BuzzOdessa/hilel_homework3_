namespace HomeWork_3;
internal class Product
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Category { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"Категорія: {Category} Продукт: {Name} Ціна: {Price}";
    }

}
