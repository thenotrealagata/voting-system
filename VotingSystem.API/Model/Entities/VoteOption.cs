using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VotingSystem.API.Model.Entities
{
    public class VoteOption
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public byte[]? Image { get; set; }

        [ForeignKey("Vote")]
        public int VoteId { get; set; }

        public virtual Vote Vote { get; set; } = null!;
    }
}
