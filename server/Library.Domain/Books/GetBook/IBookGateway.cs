namespace Library.Domain.Books.GetBook;

public interface IBookGateway
{
    Task<Book> GetBook(Guid bookId);
    Task<List<Book>> GetBooks(int pageNumber, int pageSize, int skip = 0);
}