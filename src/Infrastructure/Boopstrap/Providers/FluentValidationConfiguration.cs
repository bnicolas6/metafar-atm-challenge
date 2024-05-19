using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Metafar.ATM.Challenge.Infrastructure.Boopstrap.Providers
{
    public static class FluentValidationConfiguration
    {
        public static IServiceCollection ConfigureFluentValidation(
          this IServiceCollection services, Assembly assembly)
        {
            //services.AddValidatorsFromAssembly(assembly);
            //ValidatorOptions.Global.DisplayNameResolver = (type, member, expression) =>
            //{
            //    if (member != null)
            //    {
            //        return member.Name;
            //    }
            //    return null;
            //};

            return services;
        }
    }
}
