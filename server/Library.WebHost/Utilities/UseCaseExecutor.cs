using Library.Domain.Books.GetBook;

namespace Library.WebHost.Controllers.Book;

public class UseCaseExecutor : IUseCaseExecutor
{
    public async Task Execute<TRequest, TPresenter>(IExecutableUseCase<TRequest, TPresenter> useCase, TRequest request, TPresenter presenter) where TPresenter : IErrorPresenter
    {
        //Add business rules here
        var canExecute = await useCase.CanExecute(presenter, request);
        if (canExecute)
        {
            await useCase.Execute(presenter, request);
        }
    }
}