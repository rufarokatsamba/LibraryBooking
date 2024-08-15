namespace Library.Domain.Books.GetBook;

public class GetBookUseCase: IGetBookUseCase
{
    private readonly IBookSqlGateway _bookSqlGateway;
    
    public GetBookUseCase(IBookSqlGateway sqlGateway)
    {
        _bookSqlGateway = sqlGateway;
    }
    public Task<bool> CanExecute()
    {
        //TODO: Here we check business rules like validation like permissions to Execute, may also add validation
        throw new NotImplementedException();
    }

    public Task<GetBookResponse> Execute(GetBookRequest request)
    {
        //TODO: Here we execute business logic
        _bookSqlGateway.GetBook(request.BookId);
        return new Task<GetBookResponse>(new BookDto());
    }
}