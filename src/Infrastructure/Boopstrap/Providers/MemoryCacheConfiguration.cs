using Metafar.ATM.Challenge.Domain.Interfaces;
using Metafar.ATM.Challenge.Domain.Settings;
using Metafar.ATM.Challenge.Infrastructure.MemoryCache;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Metafar.ATM.Challenge.Infrastructure.Boopstrap.Providers
{
    public static class MemoryCacheConfiguration
    {
        public static IServiceCollection ConfigureMemoryCache(
            this IServiceCollection services, 
            IConfiguration configuration) 
        {
            services.AddMemoryCache();

            //Instalar nuget package: Microsoft.Extensions.Options.ConfigurationExtensions
            services.Configure<MemoryCacheSettings>(configuration.GetSection(key: nameof(MemoryCacheSettings)));

            services.AddSingleton<IMemoryCacheRepository, MemoryCacheRepository>();

            return services;
        }
    }
}
