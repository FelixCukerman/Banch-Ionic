using AutoMapper;
using BookStore.BLL.Interfaces;
using BookStore.BLL.Providers;
using BookStore.BLL.Services;
using BookStore.DAL.Interfaces;
using BookStore.DAL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.BLL.Configurations
{
    public static class DependenciesConfig
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAuthorBooksRepository, AuthorBooksRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IDropBoxManager, DropBoxManager>();
            services.AddAutoMapper();
        }
    }
}
