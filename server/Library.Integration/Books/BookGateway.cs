using AutoMapper;
using Library.Domain.Books;
using Library.Domain.Books.GetBook;
using Microsoft.EntityFrameworkCore;

namespace Library.Integration.Books;

public class BookGateway: IBookGateway
{
    private readonly BooksDbContext _context;
    private readonly IMapper _mapper;

    public BookGateway(BooksDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public Task<Book> GetBook(Guid bookId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Book>> GetBooks(int pageNumber, int pageSize, int skip = 0)
    {
        var data = await _context.Books
            .ToListAsync();
            
        var paginatedData = data   
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        var result = _mapper.Map<List<Book>>(paginatedData);
        return result;
    }
}