namespace VotingSystem.API.Infrastructure
{
    public record JwtSettings (string SecretKey, string Audience, string Issuer, int AccessTokenExpirationMinutes);
}
