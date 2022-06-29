using MediatR;
using HateoasAPI.Application.Notifications;

namespace HateoasAPI.Application.EventHandlers
{
    public class LogEventHandler : INotificationHandler<ErrorNotification>, INotificationHandler<ProductDeletedNotification>, INotificationHandler<ProductRegisteredNotification>, INotificationHandler<ProductUpdatedNotification>
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
            return Task.Run(() =>
            {
                Console.WriteLine($"DELETED: '{notification.Id} - DELETED? {notification.isEffective}'");
            });
        }

        public Task Handle(ProductRegisteredNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CREATED: '{notification.Id} - {notification.ProductName} - {notification.ProductPrice}'");
            });
        }

        public Task Handle(ProductUpdatedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"UPDATED: '{notification.Id} - {notification.ProductName} - {notification.ProductPrice}'");
            });
        }
    }
}
