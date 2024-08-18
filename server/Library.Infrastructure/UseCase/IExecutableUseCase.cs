namespace Library.Domain.Books.GetBook;

public interface IExecutableUseCase<in TRequest,in TPresenter>
{
    Task Execute(TPresenter presenter,TRequest request);
    Task<bool> CanExecute(IErrorPresenter presenter, TRequest request);
}