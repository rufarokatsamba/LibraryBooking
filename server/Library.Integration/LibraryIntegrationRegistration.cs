using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Integration.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Integration
{
    public static class LibraryIntegrationRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            //register dbcontext and add repositories to our service collections
            services.AddDbContext<BooksDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("LibraryDatabase")));

            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            //addscopped allows  services to be created once per request within the scope and gets used in other calls
            //services.AddScoped<IMeetingItemRepository, MeetingItemRepository>();
            return services;
        }
    }
}
