namespace Metafar.ATM.Challenge.Domain.Entities
{
    public class EstadoTarjeta
    {
        public const string TABLE_NAME = "EstadosTarjetas";

        public byte EstadoTarjetaId { get; set; }
        public string Descripcion { get; set; }

        public virtual IList<Cuenta> CuentasNavigation { get; set; }
    }
}
