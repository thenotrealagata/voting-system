using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VotingSystem.API.Model.Entities;
using VotingSystem.API.Services;

namespace VotingSystem.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration config)
        {
            // Database
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<VotingSystemDbContext>(options => options
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies()
            );

            // Services
            services.AddScoped<IVoteService, VoteService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

            services.AddIdentity<User, UserRole>(options =>
            {
                // Password settings.
                options.Password.RequiredLength = 6;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                options.User.RequireUniqueEmail = true;
            })
               .AddEntityFrameworkStores<VotingSystemDbContext>()
               .AddDefaultTokenProviders();

            return services;
        }
    }
}
