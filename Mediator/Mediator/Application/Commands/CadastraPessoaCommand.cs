using MediatR;

namespace Mediator.Application.Commands
{
    public class CadastraPessoaCommand : IRequest<string>
    {
        public string Nome { get; set; }

        public int Idade { get; set; }

        public char Sexo { get; set; }
    }
}
