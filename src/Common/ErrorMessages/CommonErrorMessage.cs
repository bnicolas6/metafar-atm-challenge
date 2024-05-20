namespace Metafar.ATM.Challenge.Common.ErrorMessages
{
    public class CommonErrorMessage
    {
        public const string IS_REQUIRED_STRING = "'{0}' no puede ser nulo, vacío ni contener solo espacios en blanco.";
        public const string IS_REQUIRED_VALUE = "'{0}' no puede ser nulo.";
        public const string INVALID_LENGTH = "'{0}' debe tener exactamente '{1}' caracteres. Se encontraron '{2}' caracteres.";
        public const string ONLY_NUMERIC_CHARACTERS = "'{0}' debe contener solo caracteres numéricos.";
        public const string INVALID_VALUE_SIZE = "'{0}' debe ser mayor a '{1}'.";
        public const string INVALID_DECIMAL_INTEGER_PART = "'{0}' debe tener una parte entera menor o igual a '{1}'";
    }
}
