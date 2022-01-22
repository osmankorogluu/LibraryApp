using LibraryApp.Persistence.Repositories;
using LibraryApp.Persistence.Repositories.Entityframework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection LoadRepository(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped<IBookRepository, EfBookRepository>();
            serviceCollection.AddScoped<ICategoryRepository, EfCategoryRepository>();
            serviceCollection.AddScoped<IUserRepository, EfUserRepository>();

            return serviceCollection;
        }
    }
}


