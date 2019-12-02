using BookStore.DAL;
using BookStore.EL.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BLL.Configurations
{
    public static class IdentityDependenciesConfig
    {
        public static void InjectApplicationIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<User, Role>((options =>
            {
                options.User.RequireUniqueEmail = true;

                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
            }))
            .AddEntityFrameworkStores<StoreContext>()
            .AddDefaultTokenProviders()
            .AddUserManager<UserManager<User>>()
            .AddSignInManager<SignInManager<User>>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
           .AddCookie(options =>
           {
               int expireHours = Convert.ToInt32(configuration["Authentication:Cookie:ExpireHours"]);
               options.ExpireTimeSpan = TimeSpan.FromHours(expireHours);

               options.AccessDeniedPath = configuration["Authentication:Cookie:AccessDeniedPath"];
               options.SlidingExpiration = Convert.ToBoolean(configuration["Authentication:Cookie:SlidingExpiration"]);
               options.LoginPath = configuration["Authentication:Cookie:LoginPath"];
               options.LogoutPath = configuration["Authentication:Cookie:LogoutPath"];
           });
        }
    }
}
