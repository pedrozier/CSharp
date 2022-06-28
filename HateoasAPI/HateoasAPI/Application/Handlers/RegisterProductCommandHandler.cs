using HateoasAPI.Application.Command;
using HateoasAPI.Application.Models;
using HateoasAPI.Application.Notifications;
using HateoasAPI.Data;
using MediatR;

namespace HateoasAPI.Application.Handlers
{
    public class RegisterProductCommandHandler : IRequestHandler<RegisterProductCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly ProductDbContext _context;
        public RegisterProductCommandHandler(IMediator mediator, ProductDbContext context)
        {
            this._mediator = mediator;
            this._context = context;
        }

        public async Task<string> Handle(RegisterProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product { ProductName = request.ProductName, ProductPrice = request.ProductPrice };

            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                await _mediator.Publish(new ProductRegisteredNotification { Id = product.Id, ProductName = product.ProductName, ProductPrice = product.ProductPrice });

                return await Task.FromResult("Product Registered with Success");
            }
            catch(Exception ex)
            {
                await _mediator.Publish(new ProductRegisteredNotification { Id = product.Id, ProductName = product.ProductName, ProductPrice = product.ProductPrice });
                await _mediator.Publish(new ErrorNotification { ExceptionName = ex.Message, Stack = ex.StackTrace });
                return await Task.FromResult("An Error has Occurred");
            }
        }
    }
}
