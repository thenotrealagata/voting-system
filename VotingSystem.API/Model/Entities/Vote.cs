using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace VotingSystem.API.Model.Entities
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public List<VoteOption> Options { get; set; }

    }
}
