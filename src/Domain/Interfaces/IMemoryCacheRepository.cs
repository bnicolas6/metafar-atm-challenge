namespace Metafar.ATM.Challenge.Domain.Interfaces
{
    public interface IMemoryCacheRepository
    {
        bool TryGetItem<T>(object key, out T value) where T : class;
        T Insert<T>(object key, T item) where T : class;
        T Update<T>(object key, T item) where T : class;
        void Delete(object key);
    }
}
