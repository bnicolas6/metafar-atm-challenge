using Metafar.ATM.Challenge.Infrastructure.Boopstrap.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Metafar.ATM.Challenge.Infrastructure.Boopstrap
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, 
            IConfiguration configuration) 
        {
            services.ConfigureSQLServer(configuration);
            services.ConfigureMemoryCache(configuration);

            return services;
        }
    }
}
