namespace Library.Domain.Books.GetBook;

public class GetBookUseCase: IGetBookUseCase
{
    private readonly IBookGateway _bookGateway;
    
    public GetBookUseCase(IBookGateway gateway)
    {
        _bookGateway = gateway;
    }

    public Task Execute(IPresenter<GetBookResponse> presenter, GetBookRequest request)
    {
        presenter.SuccessFull(new GetBookResponse("Hello World!"));
        return Task.CompletedTask;
    }

    public Task<bool> CanExecute(IErrorPresenter presenter, GetBookRequest request)
    {
        return Task.FromResult(true);
    }
}
