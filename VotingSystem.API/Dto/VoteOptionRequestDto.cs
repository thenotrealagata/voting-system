namespace VotingSystem.API.Dto
{
    public class VoteOptionRequestDto
    {
        public string Title { get; init; }

        public byte[]? Image { get; init; }
    }
}
