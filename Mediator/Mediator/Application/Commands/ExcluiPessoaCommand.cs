using MediatR;

namespace Mediator.Application.Commands
{
    public class ExcluiPessoaCommand : IRequest<string>
    {
        public int Id { get; set; }

    }
}
