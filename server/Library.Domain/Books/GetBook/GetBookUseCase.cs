namespace Library.Domain.Books.GetBook;

public class GetBookUseCase: IGetBookUseCase
{
    private readonly IBookSqlGateway _bookSqlGateway;
    
    public GetBookUseCase(IBookSqlGateway sqlGateway)
    {
        _bookSqlGateway = sqlGateway;
    }

    public Task Execute(IPresenter<GetBookResponse> presenter, GetBookRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CanExecute(IErrorPresenter presenter, GetBookRequest request)
    {
        throw new NotImplementedException();
    }
}