namespace VotingSystem.API.Dto
{
    public class VoteRequestDto
    {
        public int Id { get; init; }

        public string Title { get; init; }

        public List<VoteOptionResponseDto> Options { get; init; }

        public DateTime StartTime { get; init; }

        public DateTime EndTime { get; init; }

        public int UserId { get; init; }
    }
}
