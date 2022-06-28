using MediatR;
using HateoasAPI.Application.Notifications;

namespace HateoasAPI.Application.EventHandlers
{
    public class LogEventHandler : INotificationHandler<ErrorNotification>, INotificationHandler<ProductDeletedNotification>, INotificationHandler<ProductRegisteredNotification>, INotificationHandler<ProductUdatedNotification>
    {
        public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"EROOR: '{notification.ExceptionName} - {notification.Stack}'");
            });
        }

        public Task Handle(ProductDeletedNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(ProductRegisteredNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Handle(ProductUdatedNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
