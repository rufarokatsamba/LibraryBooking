namespace Library.Domain.Books.GetBook;

public interface IUseCase<in TRequest, out TResponse> : IExecutableUseCase<TRequest, IPresenter<TResponse>>
{
    
}