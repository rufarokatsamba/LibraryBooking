using AutoMapper;
using Library.Domain.Books.GetBook;

namespace Library.Domain.Books.ListBooks;

public class ListBooksUseCase: IListBooksUseCase
{
    private readonly IBookGateway _bookGateway;
    private readonly IMapper _mapper;
    public ListBooksUseCase(IBookGateway gateway, IMapper mapper)
    {
        _bookGateway = gateway;
        _mapper = mapper;
    }

    public async Task Execute(IPresenter<ListBooksResponse> presenter, ListBooksRequest request)
    {
        var books = await _bookGateway
            .GetBooks(request.pageNumber,request.pageSize,request.skip);
        
        var bookDtos = _mapper.Map<List<BookDto>>(books);

        presenter.SuccessFull(new ListBooksResponse(bookDtos));
    }
 
    public Task<bool> CanExecute(IErrorPresenter presenter, ListBooksRequest request)
    {
        return Task.FromResult(true);
    }
}