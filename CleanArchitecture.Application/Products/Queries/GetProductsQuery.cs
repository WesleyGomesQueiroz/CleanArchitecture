using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Products.Queries
{
    public class GetProductsQuery:IRequest<IEnumerable<Product>>
    {
    }
}
