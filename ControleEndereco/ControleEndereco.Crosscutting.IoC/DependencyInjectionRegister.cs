using ControleEndereco.AppCore.Extensions;
using ControleEndereco.Infrastructure.Extensions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControleEndereco.Crosscutting.IoC
{
    public static class DependencyInjectionRegister
    {
        public static IServiceCollection ConfigureContainer(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .ConfigureApplication()
                .ConfigureInfrastructure(configuration);

            return services;
        }
    }
}
