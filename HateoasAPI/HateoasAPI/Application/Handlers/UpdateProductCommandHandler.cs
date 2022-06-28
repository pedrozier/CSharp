using Microsoft.EntityFrameworkCore;
using HateoasAPI.Application.Command;
using HateoasAPI.Application.Models;
using HateoasAPI.Data;
using MediatR;
using HateoasAPI.Application.Notifications;

namespace HateoasAPI.Application.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly ProductDbContext _context;
        public UpdateProductCommandHandler(IMediator mediator, ProductDbContext context)
        {
            this._mediator = mediator;
            this._context = context;
        }
    
public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product { Id = request.Id, ProductName = request.ProductName, ProductPrice = request.ProductPrice };

            try
            {
                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                await _mediator.Publish(new ProductUpdatedNotification { Id = product.Id, ProductName = product.ProductName, ProductPrice = product.ProductPrice });
            }
            catch(Exception ex)
            {
                await _mediator.Publish(new ProductUpdatedNotification { Id = product.Id, ProductName = product.ProductName, ProductPrice = product.ProductPrice });
                await _mediator.Publish(new ErrorNotification { ExceptionName = ex.Message, Stack = ex.StackTrace });
                return await Task.FromResult("An Error has Occurred");
            }

        }
    }
}
