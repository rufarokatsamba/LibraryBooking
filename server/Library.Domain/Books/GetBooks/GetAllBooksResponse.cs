using Library.Domain.Books.GetBook;

namespace Library.Domain.Books.GetBooks;

public record GetAllBooksResponse(List<BookDto> Books);