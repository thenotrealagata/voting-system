using VotingSystem.API.Model.Entities;

namespace VotingSystem.API.Services
{
    public interface IUserService
    {
        Task AddUserAsync(User user, string password);
    }
}
