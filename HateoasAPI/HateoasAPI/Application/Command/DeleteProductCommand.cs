using MediatR;

namespace HateoasAPI.Application.Command
{
    public class DeleteProductCommand : IRequest<string>
    {
        public int Id { get; set; }

    }
}
