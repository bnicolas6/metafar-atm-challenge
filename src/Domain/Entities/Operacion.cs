namespace Metafar.ATM.Challenge.Domain.Entities
{
    public class Operacion
    {
        public const string TABLE_NAME = "Operaciones";

        public int OperacionId { get; set; }
        public int CuentaId { get; set; }
        public byte TipoOperacionId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public int ActualizadoPor { get; set; }
        public DateTime ActualizadoEn { get; set; }

        public virtual Cuenta CuentaNavigation { get; set; }
        public virtual TipoOperacion TipoOperacionNavigation { get; set;}
        public virtual Usuario ActualizadoPorNavigation { get; set;}

    }
}
