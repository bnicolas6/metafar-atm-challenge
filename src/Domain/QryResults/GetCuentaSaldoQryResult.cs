namespace Metafar.ATM.Challenge.Domain.QryResults
{
    public class GetCuentaSaldoQryResult
    {
        public int CuentaId { get; set; }
        public string NumeroDeCuenta { get; set; }
        public decimal Saldo { get; set; }
        public DateTime FechaUltimaExtraccion { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
    }
}
