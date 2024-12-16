namespace HomeWork_3;
internal class Customer
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Address { get; set; }

    public List<Order> Orders { get; set; } = [];

    public override string ToString()
    {
        return $"{FirstName} {LastName},  Адреса: {Address}";
    }
}


public class Order
{
    /// <summary>
    /// Замовлення
    /// </summary>
    public required string Goods { get; set; }
    /// <summary>
    /// Сума замовлення
    /// </summary>
    public decimal Amount { get; set; }

    public DateTime OrderDate { get; set; }

    public override string ToString()
    {
        return $" {OrderDate:dd.MM.yyy} , Товар: \"{Goods}\",  На суму: {Amount}";
    }
}
