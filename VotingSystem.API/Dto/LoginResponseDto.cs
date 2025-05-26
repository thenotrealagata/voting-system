namespace VotingSystem.API.Dto
{
    public class LoginResponseDto
    {
        public string AuthToken { get; init; }
        public string RefreshToken { get; init; }
        public string UserId { get; init; }
    }
}
