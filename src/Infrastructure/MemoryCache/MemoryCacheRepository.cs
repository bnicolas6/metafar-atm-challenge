using Metafar.ATM.Challenge.Domain.Interfaces;
using Metafar.ATM.Challenge.Domain.Settings;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Metafar.ATM.Challenge.Infrastructure.MemoryCache
{
    public class MemoryCacheRepository : IMemoryCacheRepository
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheEntryOptions MemoryCacheEntryOptions { get; }

        public MemoryCacheRepository(
            IMemoryCache memoryCache,
            IOptions<MemoryCacheSettings> options)
        {
            _memoryCache = memoryCache;
            var memoryCacheOptions = options.Value;

            MemoryCacheEntryOptions = new MemoryCacheEntryOptions();

            MemoryCacheEntryOptions.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(
                    memoryCacheOptions.AbsoluteExpirationRelativeToNowInSeconds);
        }

        public bool TryGetItem<T>(object key, out T value)
            where T : class
        {
            return _memoryCache.TryGetValue(key, out value);
        }

        public T Insert<T>(object key, T item)
            where T : class
        {
            return _memoryCache.Set(key, item, MemoryCacheEntryOptions);
        }

        public T Update<T>(object key, T item)
            where T : class
        {
            return Insert(key, item);
        }

        public void Delete(object key)
        {
            _memoryCache.Remove(key);
        }
    }
}
