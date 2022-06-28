using HateoasAPI.Application.Command;
using HateoasAPI.Application.Notifications;
using HateoasAPI.Data;
using MediatR;

namespace HateoasAPI.Application.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, string>
    {

        private readonly IMediator _mediator;
        private readonly ProductDbContext _context;
        public DeleteProductCommandHandler(IMediator mediator, ProductDbContext context)
        {
            this._mediator = mediator;
            this._context = context;
        }

        public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var product = await _context.Products.FindAsync(request.Id);

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                await _mediator.Publish(new ProductDeletedNotification { Id = request.Id, isEffective = true });

                return await Task.FromResult("Product Deleted");

            } 
            catch(Exception ex)
            {
                await _mediator.Publish(new ProductDeletedNotification { Id = request.Id, isEffective = false });
                await _mediator.Publish(new ErrorNotification { ExceptionName = ex.Message, Stack = ex.StackTrace });
                return await Task.FromResult("An Error has Occurred");
            }

        }
    }
}
