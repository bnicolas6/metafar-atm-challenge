namespace Metafar.ATM.Challenge.Common.Utils
{
    public static class FormattingUtils
    {
        public static string FormatDecimal(this decimal value)
        {
            return value.ToString("F2");
        }
    }
}
