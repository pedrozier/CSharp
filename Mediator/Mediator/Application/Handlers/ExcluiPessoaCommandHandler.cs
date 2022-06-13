using Mediator.Application.Commands;
using Mediator.Application.Models;
using Mediator.Application.Notifications;
using Mediator.Data;
using MediatR;

namespace Mediator.Application.Handlers
{
    public class ExcluiPessoaCommandHandler : IRequestHandler<ExcluiPessoaCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly PessoaDbContext _context;
        public ExcluiPessoaCommandHandler(IMediator mediator, PessoaDbContext context)
        {
            this._mediator = mediator;
            this._context = context;
        }

        public async Task<string> Handle(ExcluiPessoaCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var pessoa = await _context.Pessoas.FindAsync(request.Id);

                _context.Pessoas.Remove(pessoa);
                await _context.SaveChangesAsync();

                await _mediator.Publish(new PessoaExcluidaNotification { Id = request.Id, IsEfetivado = true });

                return await Task.FromResult("Pessoa excluída com sucesso");

            }
            catch (Exception ex)
            {

                await _mediator.Publish(new PessoaExcluidaNotification { Id = request.Id, IsEfetivado = false });
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da exclusão");

            }
        }
    }
}
