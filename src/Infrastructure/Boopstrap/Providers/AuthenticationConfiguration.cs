using Metafar.ATM.Challenge.Application.Services;
using Metafar.ATM.Challenge.Domain.Interfaces;
using Metafar.ATM.Challenge.Domain.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Metafar.ATM.Challenge.Infrastructure.Boopstrap.Providers
{
    public static class AuthenticationConfiguration
    {
        public static IServiceCollection ConfigureAuthentication(
            this IServiceCollection services, 
            IConfiguration configuration) 
        {
            var optionSection = configuration.GetSection(key: nameof(JwtTokenSettings));
            var jwtTokenSettings = optionSection.Get<JwtTokenSettings>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
               {
                   var key = Encoding.ASCII.GetBytes(jwtTokenSettings.SecurityKey);

                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = jwtTokenSettings.Issuer,
                       ValidAudience = jwtTokenSettings.Audience,
                       IssuerSigningKey = new SymmetricSecurityKey(key),
                   };
               });

            services.Configure<JwtTokenSettings>(optionSection);
            services.AddScoped<ITokenGenerator, JwtTokenGenerator>();

            return services;
        }
    }
}
/*
             var parameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["JwtTokenSettings:Issuer"],
                ValidAudience = _configuration["JwtTokenSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
 
 */