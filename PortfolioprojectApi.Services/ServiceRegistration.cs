using Microsoft.Extensions.DependencyInjection;
using PortfolioProject.Services.Abstract;
using PortfolioProject.Services.Implementation;

namespace PortfolioProject.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailServices, EmailServices>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
