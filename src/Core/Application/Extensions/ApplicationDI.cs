using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Application.Extensions
{
    public static class ApplicationDI
    {
        public static IServiceCollection AddJwtBearer(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? "your-super-long-secret-key-here-32-characters-min"))
                };
            });

            return serviceCollection;
        }

        public static IServiceCollection AddAuthServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<TokenService>();
            serviceCollection.AddScoped<UserService>();

            return serviceCollection;
        }
    }
}
