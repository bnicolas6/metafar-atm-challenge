using Metafar.ATM.Challenge.Domain.QryResults;

namespace Metafar.ATM.Challenge.Application.UseCase.GetSaldo
{
    public class GetSaldoQryResponse
    {
        public int Id { get; set; }
        public string NumeroDeCuenta { get; set; }
        public DateTime? FechaUltimaExtraccion { get; set; }
        public GetUsuarioQryResponse Usuario { get; set; }

        public static explicit operator GetSaldoQryResponse(GetCuentaSaldoQryResult @object)
        {
            if (@object == null) 
                return null;

            return new GetSaldoQryResponse
            {
                Id = @object.CuentaId,
                NumeroDeCuenta = @object.NumeroDeCuenta,
                FechaUltimaExtraccion = @object.FechaUltimaExtraccion != default 
                ? @object.FechaUltimaExtraccion : 
                null,
                Usuario = (GetUsuarioQryResponse)@object
            };
        }
    }
}
