using System.Runtime.ConstrainedExecution;

using ControleEndereco.AppCore.Commands.CriarEndereco;

using FluentValidation;

namespace ControleEndereco.AppCore.Validations
{
    public class CriarEnderecoCommandValidation : AbstractValidator<CriarEnderecoCommand>
    {
        public CriarEnderecoCommandValidation()
        {
            RuleFor(x => x.Cep).NotNull().NotEmpty().Length(8);
            RuleFor(x => x.Logradouro).NotNull().NotEmpty();
            RuleFor(x => x.Complemento).NotNull().NotEmpty();
            RuleFor(x => x.Unidade).NotNull().NotEmpty();
            RuleFor(x => x.Bairro).NotNull().NotEmpty();
            RuleFor(x => x.Localidade).NotNull().NotEmpty();
            RuleFor(x => x.Uf).NotNull().NotEmpty();
            RuleFor(x => x.Ibge).NotNull().NotEmpty();

        }
    }
}
