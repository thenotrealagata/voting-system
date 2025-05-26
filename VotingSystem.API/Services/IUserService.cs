using VotingSystem.API.Model.Entities;

namespace VotingSystem.API.Services
{
    public interface IUserService
    {
        Task AddUserAsync(User user, string password);
        Task<(string authToken, string refreshToken, string userId)> LoginAsync(string email, string password);
        Task LogoutAsync();
        Task<User> GetUserByIdAsync(string id);
    }
}
