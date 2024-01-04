using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.Products.Commands
{
    public abstract class ProductCommand : IRequest<Product>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; set; }
    }
}
