using Mediator.Application.Commands;
using Mediator.Application.Models;
using Mediator.Application.Notifications;
using Mediator.Data;
using MediatR;

namespace Mediator.Application.Handlers
{
    public class CadastraPessoaCommandHandler : IRequestHandler<CadastraPessoaCommand, string>
    {

        private readonly IMediator _mediator;
        private readonly PessoaDbContext _context;

        public CadastraPessoaCommandHandler(IMediator mediator, PessoaDbContext context)
        {
            this._mediator = mediator;
            this._context = context;
        }

        public async Task<string> Handle(CadastraPessoaCommand request, CancellationToken cancellationToken)
        {
            var pessoa = new Pessoa { Nome = request.Nome, Idade = request.Idade, Sexo = request.Sexo };

            try {

                await _context.Pessoas.AddAsync(pessoa);
                await _context.SaveChangesAsync();

                await _mediator.Publish(new PessoaCriadaNotification { Id = pessoa.Id, Nome = pessoa.Nome, Idade = pessoa.Idade, Sexo = pessoa.Sexo });

                return await Task.FromResult("Pessoa criada com sucesso");

            } catch (Exception ex) {

                await _mediator.Publish(new PessoaCriadaNotification { Id = pessoa.Id, Nome = pessoa.Nome, Idade = pessoa.Idade, Sexo = pessoa.Sexo });
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da criação");

            }

        }
    }
}
