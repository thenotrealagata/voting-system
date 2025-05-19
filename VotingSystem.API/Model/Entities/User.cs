using System.ComponentModel.DataAnnotations;

namespace VotingSystem.API.Model.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Vote> Votes { get; set; } = [];
    }
}
