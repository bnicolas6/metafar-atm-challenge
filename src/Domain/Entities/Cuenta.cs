namespace Metafar.ATM.Challenge.Domain.Entities
{
    public class Cuenta
    {
        public const string TABLE_NAME = "Cuentas";

        public int CuentaId { get; set; }
        public string NumeroDeCuenta { get; set; }
        public int UsuarioId { get; set; }
        public decimal Saldo { get; set; }
        public string NumeroDeTarjeta { get; set; }
        public string Pin { get; set; }
        public byte EstadoTarjetaId { get; set; }
        public int ActualizadoPor { get; set; }
        public DateTime ActualizadoEn { get; set; }


        public virtual Usuario UsuarioNavigation { get; set; }
        public virtual EstadoTarjeta EstadoTarjetaNavigation { get; set; }
        public virtual Usuario ActualizadoPorNavigation { get; set; }
        public virtual IList<Operacion> OperacionesNavigation { get; set; }
    }
}
