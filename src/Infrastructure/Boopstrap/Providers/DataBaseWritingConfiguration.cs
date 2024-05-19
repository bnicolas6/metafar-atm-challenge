using Metafar.ATM.Challenge.Domain.Interfaces.Commands;
using Metafar.ATM.Challenge.Persistence;
using Metafar.ATM.Challenge.Persistence.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Metafar.ATM.Challenge.Infrastructure.Boopstrap.Providers
{
    public static class DataBaseWritingConfiguration
    {
        public static IServiceCollection ConfigureDataBaseWriting(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<ATMDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("WritingConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
