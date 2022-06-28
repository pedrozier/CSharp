using MediatR;

namespace HateoasAPI.Application.Notifications
{
    public class ProductDeletedNotification : INotification
    {
        public int Id { get; set; }

        public bool isEffective { get; set; }
    }
}
