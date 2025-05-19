using System.Security.Cryptography.Xml;
using Microsoft.EntityFrameworkCore;
using VotingSystem.API.Exceptions;
using VotingSystem.API.Model.Entities;

namespace VotingSystem.API.Services
{
    public class VoteService : IVoteService
    {
        private VotingSystemDbContext _context;

        public VoteService(VotingSystemDbContext context) { 
            _context = context;
        }

        public async Task<IReadOnlyCollection<Vote>> GetAvailableVotesAsync()
        {
            return await _context.Votes
                .Where(v => v.StartTime < DateTime.Now && v.EndTime > DateTime.Now)
                .OrderByDescending(v => v.CreatedAt)
                .ToListAsync();
        }

        public async Task AddAsync(Vote vote)
        {
            if (vote.VoteOptions.Count < 2)
            {
                throw new ArgumentException("At least 2 vote options must be provided!");
            }

            User? user = _context.Users.Find(vote.UserId);
            if (user == null)
            {
                throw new EntityNotFoundException(nameof(User));
            }

            if (vote.StartTime.AddDays(1) > vote.EndTime)
            {
                throw new ArgumentException("Start time must be at least 1 day before the end time!");
            }

            _context.VoteOptions.AddRange(vote.VoteOptions);

            vote.CreatedAt = DateTime.Now;
            _context.Votes.Add(vote);

            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
