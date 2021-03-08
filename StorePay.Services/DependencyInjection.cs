using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StorePay.Services.Configuration;

namespace StorePay.Services
{
    public static class DependencyInjection
    {   
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
