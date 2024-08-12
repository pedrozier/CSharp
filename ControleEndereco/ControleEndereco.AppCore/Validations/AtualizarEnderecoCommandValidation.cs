using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ControleEndereco.AppCore.Commands.AtualizarEndereco;

using FluentValidation;

namespace ControleEndereco.AppCore.Validations
{
    public class AtualizarEnderecoCommandValidation : AbstractValidator<AtualizarEnderecoCommand>
    {
        public AtualizarEnderecoCommandValidation()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
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
