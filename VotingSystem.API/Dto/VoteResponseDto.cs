namespace VotingSystem.API.Dto
{
    public class VoteResponseDto
    {
        public int Id { get; init; }

        public string Title { get; init; }

        public List<VoteOptionResponseDto> Options { get; init; }

        public DateTime StartTime { get; init; }

        public DateTime EndTime { get; init; }

        public DateTime CreatedAt { get; init; }

        public UserResponseDto User { get; init; }
    }
}
