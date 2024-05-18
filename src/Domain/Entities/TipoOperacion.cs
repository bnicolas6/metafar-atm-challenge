namespace Metafar.ATM.Challenge.Domain.Entities
{
    public class TipoOperacion
    {
        public const string TABLE_NAME = "TiposOperaciones";

        public byte TipoOperacionId { get; set; }
        public string Descripcion { get; set; }

        public virtual IList<Operacion> OperacionesNavigation { get; set; }
    }
}
