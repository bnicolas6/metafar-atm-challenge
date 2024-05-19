namespace Metafar.ATM.Challenge.Domain.Interfaces.Queries
{
    public interface ICuentasQuery
    {
        Task<bool> ExistsMatchBetweenTarjetaAndPinAsync(
            string numeroDeTarjeta, 
            string pin);
    }
}

