using Metafar.ATM.Challenge.Domain.Entities;

namespace Metafar.ATM.Challenge.Application.UseCase.ExtractSaldo
{
    public class ExtractSaldoCmdResponse
    {
        public int OperacionId { get; set; }
        public CuentaCmdResponse Cuenta { get; set; }
        public TipoOperacionCmdResponse TipoOperacion { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }

        public static explicit operator ExtractSaldoCmdResponse(Operacion @object)
        {
            if (@object == null)
                throw new ArgumentNullException(nameof(@object));

            return new ExtractSaldoCmdResponse
            {
                OperacionId = @object.OperacionId,
                TipoOperacion = (TipoOperacionCmdResponse)@object,
                Fecha = @object.Fecha,
                Monto = @object.Monto
            };
        }
    }
}
