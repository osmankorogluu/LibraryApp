using LibraryApp.Application.Interfaces;
using LibraryApp.Application.Interfaces.Manager;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application
{
   public static class ServiceRegistration
    {
        public static IServiceCollection LoadServices(this IServiceCollection serviceCollection)
        {
            
            serviceCollection.AddScoped<IBookService, BookManager>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IUserService, UserManager>();
           
            return serviceCollection;
        }
    }
}
