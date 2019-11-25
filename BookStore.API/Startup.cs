using AutoMapper;
using BookStore.BLL.Interfaces;
using BookStore.BLL.Providers;
using BookStore.BLL.Services;
using BookStore.DAL;
using BookStore.DAL.Interfaces;
using BookStore.DAL.Repositories;
using BookStore.Shared.Configuration;
using BookStore.Shared.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        private void AddApplicationConfiguration(IServiceCollection services)
        {
            IConfigurationSection apiOptions = Configuration.GetSection(nameof(ApplicationConfiguration));

            string dropBoxAppKey = apiOptions[nameof(ApplicationConfiguration.DropBoxAppKey)];
            string dropBoxAppSecret = apiOptions[nameof(ApplicationConfiguration.DropBoxAppSecret)];
            string dropBoxAccessToken = apiOptions[nameof(ApplicationConfiguration.DropBoxAccessToken)];

            services.AddTransient<IApplicationConfiguration, ApplicationConfiguration>(options => new ApplicationConfiguration
            (
                dropBoxAppKey, 
                dropBoxAppSecret, 
                dropBoxAccessToken));
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            AddApplicationConfiguration(services);

            services.AddAutoMapper();
            services.AddDbContext<StoreContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=bookstore;Trusted_Connection=True;"));

            services.AddTransient<IPrintingEditionRepository, PrintingEditionRepository>();
            services.AddTransient<IAuthorBooksRepository, AuthorBooksRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IPrintingEditionService, PrintingEditionService>();
            services.AddTransient<IDropBoxManager, DropBoxManager>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
