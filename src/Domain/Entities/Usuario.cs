namespace Metafar.ATM.Challenge.Domain.Entities
{
    public class Usuario
    {
        public const string TABLE_NAME = "Usuarios";

        public int UsuarioId { get; set; }
        public string Nombre { get; set; }

        public virtual Cuenta CuentaPropietarioNavigation { get; set; }
        public virtual  IList<Cuenta> CuentasActualizadasNavigation{ get; set; }
        public virtual  IList<Operacion> OperacionesActualizadasNavigation{ get; set; }
    }
}
