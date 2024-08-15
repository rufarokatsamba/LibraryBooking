namespace Library.Domain.Books.GetBook;

public interface IBookSqlGateway
{
    Task<Book> GetBook(Guid bookId);
}