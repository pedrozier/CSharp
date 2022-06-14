using Mediator.Application.Notifications;
using Mediator.Application.Query;
using Mediator.Data;
using MediatR;

namespace Mediator.Application.Handlers
{
    public class ProcuraPessoaIdQueryHandler : IRequestHandler<ProcuraPessoaIdQuery, string>
    {
        private readonly IMediator _mediator;
        private readonly PessoaDbContext _context;
        public ProcuraPessoaIdQueryHandler(IMediator mediator, PessoaDbContext context)
        {
            this._mediator = mediator;
            this._context = context;
        }

        public async Task<string> Handle(ProcuraPessoaIdQuery request, CancellationToken cancellationToken)
        {

            var pessoa = await _context.Pessoas.FindAsync(request.Id);

            await _mediator.Publish(new PessoaProcuradaNotification { Id = request.Id });

            string result = (pessoa != null) ? "Id:" + pessoa.Id + " - Nome: " + pessoa.Nome + " - Idade: " + pessoa.Idade + " - Sexo: " + pessoa.Sexo  : "Nao foi encontrado";

            return await Task.FromResult(result);

        }
    }
}
