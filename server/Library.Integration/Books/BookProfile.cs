using Library.Domain.Books;
using Library.Integration.Books.Models;

namespace Library.Integration.Books;

using AutoMapper;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<SqlBookModel, Book>()
            .ConstructUsing(src =>  Book.CreateExistingBook(
            src.BookName,
            src.Author,
            src.Isbn,
            src.Publisher,
            (Category)src.Category,
            src.Edition,
            src.Id,
            src.Available == 1 ? Available.Yes : Available.No));
            

        CreateMap<Book, SqlBookModel>()
            .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.BookName))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
            .ForMember(dest => dest.Isbn, opt => opt.MapFrom(src => src.Isbn))
            .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.Publisher))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => (int)src.Category))
            .ForMember(dest => dest.Edition, opt => opt.MapFrom(src => src.Edition))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Available, opt => opt.MapFrom(src => src.Available == Available.Yes ? 1 : 0)); }
}
