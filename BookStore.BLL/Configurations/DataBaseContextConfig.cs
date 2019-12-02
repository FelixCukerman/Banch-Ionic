using BookStore.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookStore.BLL.Configurations
{
    public static class DataBaseContextConfig
    {
        public static void InjectDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<StoreDbInitializer>();
        }
        public static void UseDataBase(this IApplicationBuilder app, IServiceProvider serviceProvider)
        {

            StoreContext storeContext = serviceProvider.GetRequiredService<StoreContext>();
            storeContext.Database.Migrate();

            StoreDbInitializer applicationDbInitializer = serviceProvider.GetRequiredService<StoreDbInitializer>();
            applicationDbInitializer.Initialize().Wait();
        }
    }
}
