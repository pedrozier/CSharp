using Mediator.Application.Notifications;
using Mediator.Application.Query;
using Mediator.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mediator.Application.Handlers
{
    public class ProcuraTodasPessoasQueryHandler : IRequestHandler<ProcuraTodasPessoasQuery, List<string>>
    {
        private readonly IMediator _mediator;
        private readonly PessoaDbContext _context;
        public ProcuraTodasPessoasQueryHandler(IMediator mediator, PessoaDbContext context)
        {
            this._mediator = mediator;
            this._context = context;
        }

        public async Task<List<string>> Handle(ProcuraTodasPessoasQuery request, CancellationToken cancellationToken)
        {
            var pessoas = await _context.Pessoas.ToListAsync();

            List<string> result = new List<string>();

            foreach(var pessoa in pessoas)
            {
                result.Add("Id:" + pessoa.Id + " - Nome: " + pessoa.Nome + " - Idade: " + pessoa.Idade + " - Sexo: " + pessoa.Sexo);
            }

            await _mediator.Publish(new PessoaProcuraTodasNotification { resultado = result });

            return await Task.FromResult(result);
        }
    }
}
