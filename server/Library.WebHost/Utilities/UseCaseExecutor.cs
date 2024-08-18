using Library.Domain.Books.GetBook;

namespace Library.WebHost.Controllers.Book;

public class UseCaseExecutor : IUseCaseExecutor
{
    public Task Execute<TRequest, TPresenter>(IExecutableUseCase<TRequest, TPresenter> useCase, TRequest request, TPresenter presenter) where TPresenter : IErrorPresenter
    {
        throw new NotImplementedException();
    }
}