using AutoMapper;
using Library.Domain.Books;

namespace Library.Domain;

public class BookDomainProfile : Profile
{
    public BookDomainProfile()
    {
        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.BookName))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
            .ForMember(dest => dest.Isbn, opt => opt.MapFrom(src => src.Isbn))
            .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Publisher))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.Edition, opt => opt.MapFrom(src => src.Edition))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Available, opt => opt.MapFrom(src => src.Available));
    }
}
