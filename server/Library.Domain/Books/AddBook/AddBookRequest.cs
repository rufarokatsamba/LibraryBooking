namespace Library.Domain.Books.AddBook;

public record AddBookRequest(string BookName, string Author, string Isbn, string Publisher, int Category, string Edition, int Available);