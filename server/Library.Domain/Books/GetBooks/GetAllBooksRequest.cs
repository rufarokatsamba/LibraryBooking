namespace Library.Domain.Books.GetBooks;

public record GetAllBooksRequest(int pageNumber, int pageSize, int skip = 0);