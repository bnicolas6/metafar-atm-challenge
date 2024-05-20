namespace Metafar.ATM.Challenge.Common.Utils
{
    public static class DecimalUtils
    {
        public static decimal GetRoundDecimal(this decimal value)
        {
            return Math.Round(value, Constants.DECIMAL_PRECISION_VALUE);
        }

        public static bool IsValidIntegerPart(this decimal value)
        {
            int integerPartLength = (int)Math.Floor(Math.Log10(Math.Abs((double)value)) + 1);
            return integerPartLength <= Constants.DECIMAL_INTEGER_VALUE;
        }
    }
}
