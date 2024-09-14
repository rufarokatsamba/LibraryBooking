using AutoMapper;
using Library.Domain.Books;
using Library.Domain.Books.GetBook;
using Library.Integration.Books.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
namespace Library.Integration.Books;

public class BookGateway: IBookGateway
{
    private readonly BooksDbContext _context;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _cache;

    public BookGateway(BooksDbContext context, IMapper mapper, IMemoryCache cache)
    {
        _context = context;
        _mapper = mapper;
        _cache = cache;
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