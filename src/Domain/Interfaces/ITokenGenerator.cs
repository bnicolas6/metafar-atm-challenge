namespace Metafar.ATM.Challenge.Domain.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateToken(Dictionary<string, string> parameters);
    }
}
