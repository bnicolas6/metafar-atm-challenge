using Metafar.ATM.Challenge.Domain.QryResults;

namespace Metafar.ATM.Challenge.Application.UseCase.GetSaldo.Response
{
    public class GetSaldoQryResponse
    {
        public int Id { get; set; }
        public string NumeroDeCuenta { get; set; }
        public decimal Saldo { get; set; }
        public DateTime? FechaUltimaExtraccion { get; set; }
        public GetUsuarioQryResponse Usuario { get; set; }

        public static explicit operator GetSaldoQryResponse(GetCuentaSaldoQryResult @object)
        {
            if (@object == null)
                throw new ArgumentNullException(nameof(@object));

            return new GetSaldoQryResponse
            {
                Id = @object.CuentaId,
                NumeroDeCuenta = @object.NumeroDeCuenta,
                Saldo = @object.Saldo,
                FechaUltimaExtraccion = @object.FechaUltimaExtraccion != default
                ? @object.FechaUltimaExtraccion :
                null,
                Usuario = (GetUsuarioQryResponse)@object
            };
        }
    }
}
