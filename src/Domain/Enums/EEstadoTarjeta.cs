using System.ComponentModel;

namespace Metafar.ATM.Challenge.Domain.Enums
{
    public enum EEstadoTarjeta
    {
        [Description("Activo")]
        Activo = 1,
        [Description("Bloqueado")]
        Bloqueado = 2
    }
}

