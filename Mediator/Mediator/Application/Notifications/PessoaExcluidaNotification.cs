using MediatR;

namespace Mediator.Application.Notifications
{
    public class PessoaExcluidaNotification : INotification
    {
        public int Id { get; set; }

        public bool IsEfetivado { get; set; }
    }

}
