using Library.Domain.Books.GetBook;
using Library.WebHost.Controllers.Book;

namespace Library.WebHost.Extensions.Ioc
{

    public static class UseCaseRegistrations
    {
        public static IServiceCollection AddUseCases(
            this IServiceCollection services)
        {
            services.AddScoped(typeof(IActionResultPresenter<GetBookResponse>), typeof(ActionResultPresenter<GetBookResponse>));
            services.AddScoped<IGetBookUseCase,GetBookUseCase>();
            services.AddScoped<IUseCaseExecutor,UseCaseExecutor>();

            return services;
        }

    }
}