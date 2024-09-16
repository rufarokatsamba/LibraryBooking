namespace Library.Domain.Books;

public interface IBookGateway
{
    Task<Book> GetBook(Guid bookId);
    Task AddBookAsync(Book book);
    Task<List<Book>> GetBooks(int pageNumber, int pageSize, int skip = 0);
}