namespace Library.Domain.Books.GetBook;

public interface IGetBookUseCase
{
    Task<bool> CanExecute();
    Task<GetBookResponse> Execute(GetBookRequest request);
}
    
    
    



