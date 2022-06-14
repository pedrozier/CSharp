using MediatR;

namespace Mediator.Application.Query
{
    public class ProcuraPessoaIdQuery : IRequest<string>
    {
        public int Id { get; set; }

    }
}
