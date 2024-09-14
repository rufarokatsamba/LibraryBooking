namespace Library.Domain.Books.ListBooks;

public record ListBooksRequest(int pageNumber, int pageSize, int skip = 0);