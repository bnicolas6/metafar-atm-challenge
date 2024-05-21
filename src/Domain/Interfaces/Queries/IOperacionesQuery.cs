using Metafar.ATM.Challenge.Domain.QryResults;

namespace Metafar.ATM.Challenge.Domain.Interfaces.Queries
{
    public interface IOperacionesQuery
    {
        Task<(IEnumerable<GetOperacionQryResult>, int)> GetOperacionesAsync(
            string numeroDeTarjeta,
            int pageSize,
            int pageNumber);
    }
}
