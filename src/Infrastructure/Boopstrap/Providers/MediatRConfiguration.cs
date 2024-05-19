using FluentValidation;
using MediatR;
using Metafar.ATM.Challenge.Infrastructure.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Metafar.ATM.Challenge.Infrastructure.Boopstrap.Providers
{
    public static class MediatRConfiguration
    {
        public static IServiceCollection ConfigureMediatR(
            this IServiceCollection services, 
            Assembly applicationAssembly)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(applicationAssembly);
            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(applicationAssembly);

            ValidatorOptions.Global.DisplayNameResolver = (type, member, expression) =>
            {
                if (member != null)
                {
                    return member.Name;
                }
                return null;
            };

            return services;
        }
    }
}
