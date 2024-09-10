using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Domain;

public static class LibraryIntegrationRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Register AutoMapper
        services.AddAutoMapper(typeof(BookDomainProfile));
        //services.AddScoped<IUnitOfWork, UnitOfWork>();

        //addscopped allows  services to be created once per request within the scope and gets used in other calls
        //services.AddScoped<IMeetingItemRepository, MeetingItemRepository>();
        return services;
    }
}

