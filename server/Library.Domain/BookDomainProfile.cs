using AutoMapper;
using Library.Domain.Books;

namespace Library.Domain;

public class BookDomainProfile : Profile
{
    public BookDomainProfile()
    {
        CreateMap<Book, BookDto>(); 
    }
}
