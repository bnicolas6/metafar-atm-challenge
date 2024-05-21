using Metafar.ATM.Challenge.Domain.Interfaces.Queries;
using Metafar.ATM.Challenge.Persistence.Queries;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Metafar.ATM.Challenge.Infrastructure.Boopstrap.Providers
{
    public static class DatabaseReadonlyConfiguration
    {
        public static IServiceCollection ConfigureDataBaseReadOnly(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("ReadOnlyConnection");

            services.AddSingleton<IDbConnection>(new SqlConnection(connectionString));

            services.AddScoped<ICuentasQuery, CuentasQuery>();
            services.AddScoped<IOperacionesQuery, OperacionesQuery>();

            return services;
        }
    }
}
