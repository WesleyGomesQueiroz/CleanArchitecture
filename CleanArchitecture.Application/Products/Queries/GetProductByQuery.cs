using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Products.Queries
{
    public class GetProductByQuery : IRequest<Product>
    {
        public int Id { get; set; }
        
        public GetProductByQuery(int id)
        {
            Id = id;
        }
    }
}
