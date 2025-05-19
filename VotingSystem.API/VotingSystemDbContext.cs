using Microsoft.EntityFrameworkCore;
using VotingSystem.API.Model.Entities;

namespace VotingSystem.API
{
    public class VotingSystemDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<VoteOption> VoteOptions { get; set; } = null!;
        public DbSet<Vote> Votes { get; set; } = null!;

        public VotingSystemDbContext(DbContextOptions<VotingSystemDbContext> contextOptions) : base(contextOptions)
        { }
    }
}
