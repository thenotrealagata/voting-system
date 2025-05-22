using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace VotingSystem.API.Model.Entities
{
    public class User : IdentityUser
    {

        [MaxLength(255)]
        public string Name { get; set; }

        public Guid? RefreshToken { get; set; }

        public virtual ICollection<Vote> Votes { get; set; } = [];
    }
}
