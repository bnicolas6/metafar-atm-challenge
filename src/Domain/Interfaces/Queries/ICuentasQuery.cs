using Metafar.ATM.Challenge.Domain.Enums;
using Metafar.ATM.Challenge.Domain.QryResults;

namespace Metafar.ATM.Challenge.Domain.Interfaces.Queries
{
    public interface ICuentasQuery
    {
        Task<GetCuentaSaldoQryResult> GetSaldoAsync(
            string numeroDeTarjeta,
            ETipoOperacion tipoOperacion);
    }
}

