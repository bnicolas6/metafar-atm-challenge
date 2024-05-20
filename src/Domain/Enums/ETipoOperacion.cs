using System.ComponentModel;

namespace Metafar.ATM.Challenge.Domain.Enums
{
    public enum ETipoOperacion
    {
        [Description("Extraccion")]
        Extraccion = 1,
        [Description("Deposito")]
        Deposito = 2
    }
}
