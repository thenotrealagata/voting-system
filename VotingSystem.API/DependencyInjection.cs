using Microsoft.EntityFrameworkCore;
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
            );

            // Services
            services.AddScoped<IVoteService, VoteService>();

            return services;
        }
    }
}
