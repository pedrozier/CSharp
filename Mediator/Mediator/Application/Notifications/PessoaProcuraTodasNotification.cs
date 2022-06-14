using MediatR;

namespace Mediator.Application.Notifications
{
    public class PessoaProcuraTodasNotification : INotification
    {
        public List<string> resultado { get; set; }
    }
}
