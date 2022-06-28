using MediatR;

namespace HateoasAPI.Application.Command
{
    public class UpdateProductCommand : IRequest<string>
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }
    }
}
