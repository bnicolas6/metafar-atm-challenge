using Dapper;
using Metafar.ATM.Challenge.Domain.Interfaces.Queries;
using Metafar.ATM.Challenge.Domain.QryResults;
using System.Data;

namespace Metafar.ATM.Challenge.Persistence.Queries
{
    public class OperacionesQuery : IOperacionesQuery
    {
        private readonly IDbConnection _connection;

        public OperacionesQuery(IDbConnection connection)
        {
            _connection = connection;
        }

        private const string GET_OPERACIONES_PAGINATED = $@"            
            SELECT 
                OperacionId AS Id,
                TipoOperacionId,
                Fecha,
                Monto
            FROM 
                Cuentas C
            INNER JOIN Operaciones O ON O.CuentaId = C.CuentaId
            WHERE 
                NumeroDeTarjeta = @NumeroDeTarjeta
            ORDER BY O.OperacionId
            OFFSET @Offset ROWS
            FETCH NEXT @FetchNext ROWS ONLY
        ";

        private const string GET_OPERACIONES_TOTAL = $@"        
            SELECT 
                COUNT(*) 
            FROM 
                Cuentas C
            INNER JOIN Operaciones O ON O.CuentaId = C.CuentaId
            WHERE 
                NumeroDeTarjeta = @NumeroDeTarjeta
        ";


        public async Task<(IEnumerable<GetOperacionQryResult>, int)> GetOperacionesAsync(
            string numeroDeTarjeta, 
            int pageSize, 
            int pageNumber)
        {
            try
            {
                int offset = checked((pageNumber - 1) * pageSize);
                int fetchNext = pageSize;

                var queries = GET_OPERACIONES_PAGINATED + ";" + GET_OPERACIONES_TOTAL;


                using (var multi = await _connection.QueryMultipleAsync(
                    queries,
                    new
                    {
                        NumeroDeTarjeta = numeroDeTarjeta,
                        Offset = offset,
                        FetchNext = fetchNext,
                    }))
                {
                    // Leer los resultados paginados
                    var operaciones = await multi.ReadAsync<GetOperacionQryResult>();

                    // Leer el total de registros
                    var totalRegistros = await multi.ReadSingleAsync<int>();

                    return (operaciones, totalRegistros);
                }
            }
            catch (OverflowException)
            {
                throw;
            }
        }
    }
}
