using Microsoft.EntityFrameworkCore;
using VotingSystem.API.Model.Entities;

namespace VotingSystem.API.Services
{
    public class VoteService : IVoteService
    {
        private VotingSystemDbContext _context;

        public VoteService(VotingSystemDbContext context) { 
            _context = context;
        }

        public async Task<IReadOnlyCollection<Vote>> GetLatestVotes()
        {
            return await _context.Votes.ToListAsync();
        }
    }
}
