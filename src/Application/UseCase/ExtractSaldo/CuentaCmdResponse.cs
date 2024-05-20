using Metafar.ATM.Challenge.Domain.Entities;

namespace Metafar.ATM.Challenge.Application.UseCase.ExtractSaldo
{
    public class CuentaCmdResponse
    {
        public int CuentaId { get; set; }
        public string NumeroDeCuenta { get; set; }
        public decimal Saldo { get; set; }

        public static explicit operator CuentaCmdResponse(Cuenta @object)
        {
            if (@object == null) 
                throw new ArgumentNullException(nameof(@object));

            return new CuentaCmdResponse
            {
                CuentaId = @object.CuentaId,
                NumeroDeCuenta = @object.NumeroDeCuenta,
                Saldo = @object.Saldo,
            };
        }
    }
}
