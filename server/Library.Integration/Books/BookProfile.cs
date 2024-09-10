using Library.Domain.Books;
using Library.Integration.Books.Models;

namespace Library.Integration.Books;

using AutoMapper;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<SqlBookModel, Book>();
        CreateMap<Book, SqlBookModel>(); 
    }
}
