using Metafar.ATM.Challenge.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Metafar.ATM.Challenge.Infrastructure.Boopstrap.Providers
{
    public static class SQLServerConfiguration
    {
        public static IServiceCollection ConfigureSQLServer(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<ATMDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("WritingConnection")));

            return services;
        }
    }
}
