using Microsoft.AspNetCore.Identity;

namespace VotingSystem.API.Model.Entities
{
    public class UserRole : IdentityRole
    {
        public UserRole() { }
        public UserRole(string role) : base(role) { }
    }
}
