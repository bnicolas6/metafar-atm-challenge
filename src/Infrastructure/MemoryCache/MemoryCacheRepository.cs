using Metafar.ATM.Challenge.Domain.Interfaces;
using Metafar.ATM.Challenge.Domain.Settings;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Metafar.ATM.Challenge.Infrastructure.MemoryCache
{
    public class MemoryCacheRepository : IMemoryCacheRepository
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheEntryOptions _insertOptions { get; }
        public MemoryCacheEntryOptions _updateOptions { get; }

        public MemoryCacheRepository(
            IMemoryCache memoryCache, 
            IOptions<MemoryCacheSettings> options)
        {
            _memoryCache = memoryCache;
            var memoryCacheOptions = options.Value;

            _insertOptions = CreateInsertOptionsWithExpiration(memoryCacheOptions);
            _updateOptions = CreateUpdateOptionsWithoutExpiration();
        }

        #region -- PUBLIC METHODS --

        public bool TryGetItem<T>(object key, out T value)
            where T : class
        {
            return _memoryCache.TryGetValue(key, out value);
        }

        public T Insert<T>(object key, T item)
            where T : class
        {
            return _memoryCache.Set(key, item, _insertOptions);
        }

        public T Update<T>(object key, T item)
            where T : class
        {
            if (TryGetItem<T>(key, out T findedItem))
            {
                _memoryCache.Set(key, item, _updateOptions);
                return findedItem;
            }
            else
            {
                return _memoryCache.Set(key, item, _insertOptions);
            }
        }

        public void Delete(object key)
        {
            _memoryCache.Remove(key);
        }


        #endregion

        #region -- PRIVATE METHODS --

        private MemoryCacheEntryOptions CreateInsertOptionsWithExpiration(
            MemoryCacheSettings memoryCacheOptions)
        {
            var insertOptions = new MemoryCacheEntryOptions();
            insertOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(
                memoryCacheOptions.AbsoluteExpirationRelativeToNowInHours);

            return insertOptions;
        }

        private MemoryCacheEntryOptions CreateUpdateOptionsWithoutExpiration()
        {
            return new MemoryCacheEntryOptions();
        }

        #endregion
    }
}
