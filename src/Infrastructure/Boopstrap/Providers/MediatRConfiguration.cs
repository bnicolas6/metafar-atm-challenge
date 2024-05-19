using MediatR;
using Metafar.ATM.Challenge.Infrastructure.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation.AspNetCore;
using FluentValidation;
using Metafar.ATM.Challenge.Application.UseCase.Login;
using Metafar.ATM.Challenge.Common.Http.Response;

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

            //services.AddValidatorsFromAssemblyContaining<LoginCmdValidator>();
            //services.AddValidatorsFromAssembly(applicationAssembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(applicationAssembly);
            return services;
        }
    }
}
