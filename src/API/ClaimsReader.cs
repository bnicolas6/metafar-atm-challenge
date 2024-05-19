using System.Linq;
using System.Security.Claims;

namespace Metafar.ATM.Challenge.API
{
    public static class ClaimsReader
    {
        public static string? GetNumeroDeTarjetaClaim(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(c => c.Type == "NumeroDeTarjeta")?.Value;
        }
    }
}
