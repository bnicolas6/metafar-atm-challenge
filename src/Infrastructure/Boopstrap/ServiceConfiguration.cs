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
            services.ConfigureAuthentication(configuration);
            services.ConfigureMemoryCache(configuration);
            services.ConfigureSQLServer(configuration);
            services.ConfigureSwagger();
                      
            return services;
        }
    }
}
