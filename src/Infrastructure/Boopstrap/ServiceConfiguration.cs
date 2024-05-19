using Metafar.ATM.Challenge.Application.UseCase.Login;
using Metafar.ATM.Challenge.Domain.Settings;
using Metafar.ATM.Challenge.Infrastructure.Boopstrap.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Metafar.ATM.Challenge.Infrastructure.Boopstrap
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, 
            IConfiguration configuration) 
        {
            services.Configure<LoginSettings>(configuration.GetSection(key: nameof(LoginSettings)));



            var applicationAssembly = typeof(LoginCmd).Assembly;

            services.ConfigureMediatR(applicationAssembly);
            services.ConfigureDataBaseWriting(configuration);
            services.ConfigureDataBaseReadOnly(configuration);
            services.ConfigureAuthentication(configuration);
            services.ConfigureMemoryCache(configuration);
            services.ConfigureSwagger();
                      
            return services;
        }
    }
}
