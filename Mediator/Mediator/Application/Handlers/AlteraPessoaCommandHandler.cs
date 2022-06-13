using Mediator.Application.Commands;
using Mediator.Application.Models;
using Mediator.Application.Notifications;
using Mediator.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mediator.Application.Handlers
{
    public class AlteraPessoaCommandHandler : IRequestHandler<AlteraPessoaCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly PessoaDbContext _context;
        public AlteraPessoaCommandHandler(IMediator mediator, PessoaDbContext context)
        {
            this._mediator = mediator;
            this._context = context;
        }

        public async Task<string> Handle(AlteraPessoaCommand request, CancellationToken cancellationToken)
        {
            var pessoa = new Pessoa { Id = request.Id, Nome = request.Nome, Idade = request.Idade, Sexo = request.Sexo };

            try
            {

                _context.Entry(pessoa).State = EntityState.Modified;
                await _context.SaveChangesAsync();


                await _mediator.Publish(new PessoaAlteradaNotification { Id = pessoa.Id, Nome = pessoa.Nome, Idade = pessoa.Idade, Sexo = pessoa.Sexo, IsEfetivado = true });

                return await Task.FromResult("Pessoa alterada com sucesso");

            }
            catch (Exception ex)
            {

                await _mediator.Publish(new PessoaAlteradaNotification { Id = pessoa.Id, Nome = pessoa.Nome, Idade = pessoa.Idade, Sexo = pessoa.Sexo, IsEfetivado = false });
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da alteração");

            }
        }
    }
}
