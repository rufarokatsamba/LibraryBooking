using Library.Domain.Books.GetBook;

namespace Library.WebHost.Controllers.Book;

public class UseCaseExecutor : IUseCaseExecutor
{
    public async Task Execute<TRequest, TPresenter>(IExecutableUseCase<TRequest, TPresenter> useCase, TRequest request, TPresenter presenter) where TPresenter : IErrorPresenter
    {
        //Add business rules here
        useCase.Execute(presenter,request);
    }
}