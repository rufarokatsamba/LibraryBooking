using System.Reflection;
using Library.Integration.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Library.Integration
{
    public static class LibraryIntegrationRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();
            services.AddDbContext<BooksDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("LibraryDatabase")));
            // Register AutoMapper
            services.AddAutoMapper(typeof(BookProfile));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            //addscopped allows  services to be created once per request within the scope and gets used in other calls
            //services.AddScoped<IMeetingItemRepository, MeetingItemRepository>();
            return services;
        }
    }
}
