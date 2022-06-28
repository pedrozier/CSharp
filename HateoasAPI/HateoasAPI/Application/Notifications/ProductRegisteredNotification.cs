using MediatR;

namespace HateoasAPI.Application.Notifications
{
    public class ProductRegisteredNotification : INotification
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

    }
}
