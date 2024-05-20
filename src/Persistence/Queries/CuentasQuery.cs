using Dapper;
using Metafar.ATM.Challenge.Domain.Enums;
using Metafar.ATM.Challenge.Domain.Interfaces.Queries;
using Metafar.ATM.Challenge.Domain.QryResults;
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

        private const string GET_SALDO = $@"
            SELECT 
                C.CuentaId,
	            C.NumeroDeCuenta,
	            C.Saldo,
                O.FechaUltimaExtraccion,
	            U.UsuarioId,
	            U.Nombre
            FROM 
                Cuentas C
            INNER JOIN Usuarios U
             ON C.UsuarioId = U.UsuarioId
            LEFT JOIN 
                (
                    SELECT
			            O.CuentaId,
                        MAX(Fecha) AS FechaUltimaExtraccion			
                    FROM 
                        Operaciones O
                    WHERE 
                        TipoOperacionId = @TipoOperacionId
                    GROUP BY 
                        O.CuentaId
                ) o ON C.CuentaId = O.CuentaId
            WHERE 
                C.NumeroDeTarjeta = @NumeroDeTarjeta
        ";

        public async Task<GetCuentaSaldoQryResult> GetSaldoAsync(
            string numeroDeTarjeta, 
            ETipoOperacion tipoOperacion)
        {
            return await _connection.QueryFirstOrDefaultAsync<GetCuentaSaldoQryResult>(
                GET_SALDO,
                new
                {
                    NumeroDeTarjeta = numeroDeTarjeta,
                    TipoOperacionId = (byte)tipoOperacion
                });
        }
    }
}
