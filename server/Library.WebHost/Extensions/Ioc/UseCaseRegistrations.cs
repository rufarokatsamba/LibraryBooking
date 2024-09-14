using Library.Domain.Books.GetBook;
using Library.Domain.Books.ListBooks;
using Library.WebHost.Controllers.Book;

namespace Library.WebHost.Extensions.Ioc
{

    public static class UseCaseRegistrations
    {
        public static IServiceCollection AddUseCases(
            this IServiceCollection services)
        {
            services.AddScoped(typeof(IActionResultPresenter<GetBookResponse>), typeof(ActionResultPresenter<GetBookResponse>));
            services.AddScoped(typeof(IActionResultPresenter<ListBooksResponse>), typeof(ActionResultPresenter<ListBooksResponse>));
            services.AddScoped<IGetBookUseCase,GetBookUseCase>();
            services.AddScoped<IListBooksUseCase,ListBooksUseCase>();
            services.AddScoped<IUseCaseExecutor,UseCaseExecutor>();

            return services;
        }

    }
}