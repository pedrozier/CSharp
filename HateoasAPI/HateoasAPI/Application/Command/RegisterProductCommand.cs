using MediatR;

namespace HateoasAPI.Application.Command
{
    public class RegisterProductCommand : IRequest<string>
    {
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

    }
}
