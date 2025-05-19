namespace VotingSystem.API.Dto
{
    public class VoteOptionResponseDto
    {
        public int Id { get; init; }

        public string Title { get; init; }

        public byte[]? Image { get; init; }
    }
}
