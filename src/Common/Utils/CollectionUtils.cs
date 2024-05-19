namespace Metafar.ATM.Challenge.Common.Utils
{
    public static class CollectionUtils
    {
        public static bool IsNullOrEmpty<T>(this List<T> list)
        {
            return list == null || !list.Any();
        }
    }
}
