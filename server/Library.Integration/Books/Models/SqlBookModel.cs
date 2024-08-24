namespace Library.Integration.Books.Models;

public class SqlBookModel
{
    public Guid Id { get; set; }
    public string BookName { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public string Publisher { get; set; }
    public int Category { get; set; }
    public string Edition { get; set; }
    public int Available { get; set; }
}