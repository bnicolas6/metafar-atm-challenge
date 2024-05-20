namespace Metafar.ATM.Challenge.Common.ErrorMessages
{
    public class CuentaErrorMessage
    {
        public const string TARJETA_WAS_BLOCKED = "La tarjeta asociada al número proporcionado se encuentra bloqueada. Por favor, contacte al servicio de atención al cliente.";
        public const string TARJETA_IS_BLOCKED = "La tarjeta asociada al número proporcionado ha sido bloqueada. Por favor, contacte al servicio de atención al cliente.";
        public const string TARJETA_FAIL_ATTEMPT = "El PIN proporcionado es incorrecto. Por favor, vuelva a intentarlo.";
        public const string CUENTA_NOT_FOUND = "No se ha podido encontrar una cuenta relacionada al número de tarjeta proporcionado. Por favor, contacte al servicio de atención al cliente.";
        public const string CUENTA_INVALID_EXTRACT = "No es posible realizar una extraccion de su cuenta. El saldo disponible es de {0}";
    }
}
