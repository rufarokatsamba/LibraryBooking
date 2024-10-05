using AutoMapper;
using Library.Domain.Books;
using Library.Domain.Books.GetBook;
using Library.Infrastructure;
using Library.Integration.Books.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
namespace Library.Integration.Books;

public class BookGateway: IBookGateway
{
    private readonly BooksDbContext _context;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _cache;
    private readonly IMediator _mediator;

    public BookGateway(BooksDbContext context, IMapper mapper, IMemoryCache cache, IMediator mediator)
    {
        _context = context;
        _mapper = mapper;
        _cache = cache;
        _mediator = mediator;
    }
    public Task<Book> GetBook(Guid bookId)
    {
        // Try to get the book from the cache
        if (_cache.TryGetValue($"Book_{bookId}", out Book cachedBook))
        {
            return Task.FromResult(cachedBook);
        }
        // If not cached, retrieve it from the database
        var bookModel = _context.Books
            .FirstOrDefault(b => b.Id == bookId);
        var book = _mapper.Map<Book>(bookModel);

        // Cache the result for future calls
        _cache.Set($"Book_{bookId}", book, TimeSpan.FromMinutes(10));

        return Task.FromResult(book);
    }

    public async Task AddBookAsync(Book book)
    {
        var sqlBookModel = _mapper.Map<SqlBookModel>(book);
        _context.Books.Add(sqlBookModel);
        // Dispatch Domain Events collection.
        // Choices:
        // A) Right BEFORE committing data (EF SaveChanges) into the DB. This makes
        // a single transaction including side effects from the domain event
        // handlers that are using the same DbContext with Scope lifetime
        // B) Right AFTER committing data (EF SaveChanges) into the DB. This makes
        // multiple transactions. You will need to handle eventual consistency and
        // compensatory actions in case of failures.
        await _mediator.DispatchDomainEventsAsync(_context);

        // After this line runs, all the changes (from the Command Handler and Domain
        // event handlers) performed through the DbContext will be committed
        await _context.SaveChangesAsync();
    }
    public async Task<List<Book>> GetBooks(int pageNumber, int pageSize, int skip = 0)
    {
        // Build a cache key based on page number and size
        var cacheKey = $"Books_Page_{pageNumber}_Size_{pageSize}";

        // Try to get the list from the cache
        if (_cache.TryGetValue(cacheKey, out List<Book> cachedBooks))
        {
            return cachedBooks;
        }

        // If not cached, retrieve from the database
        var data = await _context.Books.ToListAsync();
        var paginatedData = data.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        var result = _mapper.Map<List<Book>>(paginatedData);

        // Cache the result
        _cache.Set(cacheKey, result, TimeSpan.FromMinutes(10));

        return result;
    }
}