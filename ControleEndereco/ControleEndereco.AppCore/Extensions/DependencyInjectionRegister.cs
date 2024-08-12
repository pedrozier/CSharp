using ControleEndereco.AppCore.Validations;

using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

namespace ControleEndereco.AppCore.Extensions
{
    public static class DependencyInjectionRegister
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddValidatorsFromAssembly(typeof(DependencyInjectionExtensions).Assembly); // TODO verificar
            services.AddValidatorsFromAssemblyContaining<CriarEnderecoCommandValidation>();
            services.AddValidatorsFromAssemblyContaining<AtualizarEnderecoCommandValidation>();

            return services;
        }
    }
}
