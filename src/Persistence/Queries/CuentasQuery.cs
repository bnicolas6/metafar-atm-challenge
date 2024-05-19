using Dapper;
using Metafar.ATM.Challenge.Domain.Interfaces.Queries;
using System.Data;

namespace Metafar.ATM.Challenge.Persistence.Queries
{
    public class CuentasQuery : ICuentasQuery
    {
        private readonly IDbConnection _connection;

        public CuentasQuery(IDbConnection connection)
        {
            _connection = connection;
        }

        private const string NUMERO_DE_TARJETA_AND_PIN_MATCH = $@"
            SELECT 1
            FROM Cuentas
            WHERE NumeroDeTarjeta = @NumeroDeTarjeta AND Pin = @Pin
        ";

        public async Task<bool> ExistsMatchBetweenTarjetaAndPinAsync(
            string numeroDeTarjeta, 
            string pin)
        {
            return await _connection.QueryFirstOrDefaultAsync<bool>(
                NUMERO_DE_TARJETA_AND_PIN_MATCH,
                new
                {
                    NumeroDeTarjeta = numeroDeTarjeta,
                    Pin = pin
                });
        }
    }
}
