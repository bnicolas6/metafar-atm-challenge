namespace Metafar.ATM.Challenge.Domain.Settings
{
    public class JwtTokenSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int TokenExpirationHours { get; set; }
        public string SecurityKey { get; set; }
    }
}
