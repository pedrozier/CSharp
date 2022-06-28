using MediatR;

namespace HateoasAPI.Application.Notifications
{
    public class ErrorNotification : INotification
    {
        public string ExceptionName { get; set; }

        public string Stack { get; set; }
    }
}
