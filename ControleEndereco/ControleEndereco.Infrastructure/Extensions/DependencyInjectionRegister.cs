using ControleEndereco.Domain.Interfaces.Repositories;
using ControleEndereco.Domain.Interfaces.Services;
using ControleEndereco.Domain.Interfaces.Transactions;
using ControleEndereco.Infrastructure.Data.Context;
using ControleEndereco.Infrastructure.Data.Repositories;
using ControleEndereco.Infrastructure.Data.Transactions;
using ControleEndereco.Infrastructure.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Polly;
using Polly.Extensions.Http;

namespace ControleEndereco.Infrastructure.Extensions
{
    public static class DependencyInjectionRegister
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DbSession>(_ => new DbSession(configuration.GetConnectionString("Default")));
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            services.AddHttpClient<IConsultaEnderecoService, ConsultaEnderecoService>().AddPolicyHandler(GetRetryPolicy());

            return services;
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                    .HandleTransientHttpError()
                    .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}
