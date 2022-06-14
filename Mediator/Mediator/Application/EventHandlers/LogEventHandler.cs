using Mediator.Application.Notifications;
using MediatR;

namespace Mediator.Application.EventHandlers
{
    public class LogEventHandler : INotificationHandler<PessoaCriadaNotification>, INotificationHandler<PessoaAlteradaNotification>, INotificationHandler<PessoaExcluidaNotification>, INotificationHandler<ErroNotification>, INotificationHandler<PessoaProcuradaNotification>, INotificationHandler<PessoaProcuraTodasNotification>
    {
        public Task Handle(PessoaCriadaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} - {notification.Nome} - {notification.Idade} - {notification.Sexo}'");
            });
        }

        public Task Handle(PessoaAlteradaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ALTERACAO: '{notification.Id} - {notification.Nome} - {notification.Idade} - {notification.Sexo} - {notification.IsEfetivado}'");
            });
        }

        public Task Handle(PessoaExcluidaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"EXCLUSAO: '{notification.Id} - {notification.IsEfetivado}'");
            });
        }

        public Task Handle(ErroNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERRO: '{notification.Excecao} \n {notification.PilhaErro}'");
            });
        }

        public Task Handle(PessoaProcuradaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"PROCURA: '{notification.Id}'");
            });
        }

        public Task Handle(PessoaProcuraTodasNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"PROCURATODOS: \n");
                foreach(string item in notification.resultado)
                {
                    Console.WriteLine(item);
                }
            });
        }
    }
}
