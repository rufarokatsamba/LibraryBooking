using Library.Domain.Books;
using Library.Domain.Books.GetBook;

namespace Library.Integration.Books;

public class BookSqlGateway: IBookSqlGateway
{
    public Task<Book> GetBook(Guid bookId)
    {
        throw new NotImplementedException();
    }
}