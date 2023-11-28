namespace VemProFut.Domain.Options
{
    public record JwtConfiguration
    {
        public const string FieldName = "JwtConfiguration";

        public string PrivateKey { get; init; } = string.Empty;
        public string Audience { get; init; } = string.Empty;
        public string Issuer { get; init; } = string.Empty;
        public int TimeToLiveInMinutes { get; init; } = 0;
    }
}