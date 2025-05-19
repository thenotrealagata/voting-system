using VotingSystem.API.Model.Entities;

namespace VotingSystem.API.Services
{
    public interface IVoteService
    {
        Task<IReadOnlyCollection<Vote>> GetAvailableVotesAsync();

        Task AddAsync(Vote vote);

        Task DeleteAsync();
    }
}
