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
        public List<VoteOption> VoteOptions { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
