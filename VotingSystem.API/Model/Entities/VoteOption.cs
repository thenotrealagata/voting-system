using System.ComponentModel.DataAnnotations;

namespace VotingSystem.API.Model.Entities
{
    public class VoteOption
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public byte[] Image { get; set; }
    }
}
