namespace Library.Domain.Books;

public class BookDto
{
    public string BookName { get; set; } = null!;
    public string Author { get; set; }= null!;
    public string Isbn { get; set; }= null!;
    public string Publisher { get; init; }= null!;
    public Category Category { get; init; }
    public string Edition { get; init; }= null!;
    public Guid Id { get; init; }
    public Available Available { get; set; }
}