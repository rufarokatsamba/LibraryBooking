using Library.Domain.Books.GetBook;

namespace Library.WebHost.Controllers.Book;

public interface IUseCaseExecutor
{
    Task Execute<TRequest,TPresenter>(IExecutableUseCase<TRequest,TPresenter> useCase, TRequest request, TPresenter presenter)
        where TPresenter : IErrorPresenter;
}