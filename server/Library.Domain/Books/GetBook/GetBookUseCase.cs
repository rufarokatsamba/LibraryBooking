using AutoMapper;

namespace Library.Domain.Books.GetBook;

public class GetBookUseCase: IGetBookUseCase
{
    private readonly IBookGateway _bookGateway;
    private readonly IMapper _mapper;
    public GetBookUseCase(IBookGateway gateway, IMapper mapper)
    {
        _bookGateway = gateway;
        _mapper = mapper;
    }

    public async Task Execute(IPresenter<GetBookResponse> presenter, GetBookRequest request)
    {
        //var book = await _bookGateway.GetBook(request.BookId);
        var book = await _bookGateway.GetBook(request.BookId);
        var bookDto = _mapper.Map<BookDto>(book);
        presenter.SuccessFull(new GetBookResponse(bookDto));
    }

    public Task<bool> CanExecute(IErrorPresenter presenter, GetBookRequest request)
    {
        return Task.FromResult(true);
    }
}
