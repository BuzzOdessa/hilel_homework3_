namespace HomeWork_3;
internal class Book
{
    /// <summary>
    /// Назва
    /// </summary>
    public required string Title { get; set; }
    public required string Author { get; set; }
    /// <summary>
    /// Рік видання
    /// </summary>
    ///
    public int PublishYear { get; set; }
    /// <summary>
    /// Жанр
    /// </summary>
    public required string Genre { get; set; }

    public override string ToString()
    {
        return $"Назва: \"{Title}\", Автор: {Author},  Жанр: {Genre}, Рік видання: {PublishYear}";
    }
}
