using AutoMapper;
using Library.Domain.Books.GetBook;

namespace Library.Domain.Books.AddBook;

public class AddBookUseCase: IAddBookUseCase
{
    private readonly IBookGateway _bookGateway;
    private readonly IMapper _mapper;
    public AddBookUseCase(IBookGateway gateway, IMapper mapper)
    {
        _bookGateway = gateway;
        _mapper = mapper;
    }

    public async Task Execute(IPresenter<AddBookResponse> presenter, AddBookRequest request)
    {
        var book = Book.CreateNewBook(request.BookName,request.Author, request.Isbn,(Category)request.Category ,request.Publisher, request.Edition);
        await _bookGateway.AddBookAsync(book);
        
        presenter.SuccessFull(new AddBookResponse("Successfully added book"));
    }

    public Task<bool> CanExecute(IErrorPresenter presenter, AddBookRequest request)
    {
        return Task.FromResult(true);
    }
}
